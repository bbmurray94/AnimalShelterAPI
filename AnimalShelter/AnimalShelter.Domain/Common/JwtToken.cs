using Microsoft.Win32.SafeHandles;

namespace AnimalShelter.Domain.Common
{
    public class JwtToken
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
