namespace AnimalShelter.API.Models
{
    public class JwtTokenModel
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
    }
}
