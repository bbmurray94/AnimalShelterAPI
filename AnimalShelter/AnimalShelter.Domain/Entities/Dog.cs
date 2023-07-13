using AnimalShelter.Domain.Enums;
using AnimalShelter.Domain.Interfaces;

namespace AnimalShelter.Domain.Entities
{
    public class Dog : IAnimal
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public bool HumaneInvestigation { get; set; }

        public string? Breed { get; set; }
        public Level Level { get; set; }

        public string? Location { get; set; }
        public bool IsHouseBroken { get; set; }
    }
}
