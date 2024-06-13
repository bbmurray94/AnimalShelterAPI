using AnimalShelter.Domain.Enums;

namespace AnimalShelter.Domain.Common
{
    public class BoardDogActivityItem
    {
        public DateTime? Date { get; set; }
        public Timeslot? Timeslot { get; set; }
        public DogActivityType? Type { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
