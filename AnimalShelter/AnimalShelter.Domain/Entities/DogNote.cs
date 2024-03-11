using AnimalShelter.Domain.Interfaces;

namespace AnimalShelter.Domain.Entities
{
    public class DogNote : INote
    {
        public int Id { get; set;  }
        public string? Note { get; set; }
        public int DogId { get; set; }
    }
}
