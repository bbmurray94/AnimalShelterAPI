using AnimalShelter.API.Models.Interfaces;
using AnimalShelter.Domain.Enums;

namespace AnimalShelter.API.Models
{
    public class WalkerModel : IVolunteerModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Level { get; set; }
    }
}
