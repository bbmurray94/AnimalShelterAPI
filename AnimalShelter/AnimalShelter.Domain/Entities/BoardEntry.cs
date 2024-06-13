using AnimalShelter.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Domain.Entities
{
    [Keyless]
    public class BoardEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string KennelNumber { get; set; }
        public Level Level { get; set; }
        public bool IsHouseBroken { get; set; }
        public bool UnderHumaneInvestigation { get; set; }
        public DateTime? Date {  get; set; }
        public DogActivityType? Type { get; set; }
        public Timeslot? Timeslot { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
