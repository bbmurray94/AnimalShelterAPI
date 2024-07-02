using AnimalShelter.Data.Data;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Domain.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using static Org.BouncyCastle.Math.EC.ECCurve;
using AnimalShelter.Domain.Common;

namespace AnimalShelter.Data.Backends
{
    public class UsersBackend : IUsersBackend
    {
        private AnimalShelterContext Context { get; set; }
        private IConfiguration Configuration { get; set; }

        public UsersBackend(AnimalShelterContext context, IConfiguration configuration) 
        {
            Context = context;
            Configuration = configuration;
        }

        public async Task<User?> CreateUserAsync(User user)
        {
            EntityEntry<User> created = null;

            user.Password = HashPassword(user.Password);

            created = Context.Users.Add(user);
            Context.SaveChanges();
            
            if (created == null) 
            {
                return null;
            }
            Context.SaveChanges();
            return created.Entity;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await Context.Users.Include(u => u.UserRole).ToListAsync();
        }

        public async Task<JwtToken> LogIn(string username, string password) 
        {
            User user = Context.Users.Include(user => user.UserRole).FirstOrDefault(u => u.Username.Equals(username));
            if (user == null) 
            {
                return null;
            }
            if (!IsPasswordCorrect(password, user.Password)) 
            {
                return null;
            }

            JwtToken jwtToken = GenerateJwtToken(user.Id, user.Username, user.UserRole.Name);

            return jwtToken;
        }

        public async Task<ClaimsPrincipal?> ValidateTokenAsync(string token) 
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Jwt:Secret").Value!);
                var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                    ValidateLifetime = true
                }, out _);

                return claimsPrincipal;
            }
            catch
            {
                return null;
            }
        } 

        private JwtToken GenerateJwtToken(int userId, string username, string role) 
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Jwt:Secret").Value!);
            var accessTokenExpiration = int.Parse(Configuration.GetSection("Jwt:AccessTokenExpirationInDays").Value!);
            var refreshTokenExpiration = int.Parse(Configuration.GetSection("Jwt:RefreshTokenExpirationInDays").Value!);

            // Access Toke
            var tokenDescriptor = new SecurityTokenDescriptor 
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new(ClaimTypes.NameIdentifier, userId.ToString()),
                    new(ClaimTypes.Name, username),
                    new(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddDays(accessTokenExpiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var accessToken = tokenHandler.CreateToken(tokenDescriptor);
            var refreshToken = GenerateRefreshToken();
            var refreshExpirationDate = DateTime.UtcNow.AddDays(refreshTokenExpiration);

            return new JwtToken 
            {
                AccessToken = tokenHandler.WriteToken(accessToken),
                AccessTokenExpiration = tokenDescriptor.Expires.Value,
                RefreshToken = refreshToken,
                RefreshTokenExpiration = refreshExpirationDate
            };
        }

        public Task<User> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        private string HashPassword(string password) 
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: Encoding.ASCII.GetBytes(Configuration.GetSection("Jwt:Salt").Value!),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private bool IsPasswordCorrect(string password, string hashPassword) 
        {
            return hashPassword.Equals(HashPassword(password));
        }
    }
}
