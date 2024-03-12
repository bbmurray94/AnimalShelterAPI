using AnimalShelter.Domain.Enums;
using AnimalShelter.Domain.Interfaces;

namespace AnimalShelter.Domain.Entities
{
    public class Walker : IVolunteer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Level Level { get; set; }
    }
}
