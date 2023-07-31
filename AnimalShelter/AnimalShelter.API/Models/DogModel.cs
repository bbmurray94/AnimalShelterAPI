using AnimalShelter.API.Models.Interfaces;
using AnimalShelter.Domain.Enums;

namespace AnimalShelter.API.Models
{
    public class DogModel : IAnimalModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public bool HumaneInvestigation { get; set; }

        public string? Breed { get; set; }
        public string Level { get; set; }

        public string? Location { get; set; }
        public bool IsHouseBroken { get; set; }
    }
}
