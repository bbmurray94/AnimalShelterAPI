using AnimalShelter.Domain.Common;
using AnimalShelter.Domain.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnimalShelter.Data.Interfaces
{
    public interface IUsersBackend
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> GetUserAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<JwtToken> LogIn(string username, string password);

        Task<ClaimsPrincipal?> ValidateTokenAsync(string? token); 
    }
}
