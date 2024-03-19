using AnimalShelter.Domain.Enums;
using AnimalShelter.Domain.Interfaces;

namespace AnimalShelter.Domain.Entities
{
    public class DogActivity : IActivity
    {
        public int Id { get; set; }
        public Dog? Dog { get; set; }
        public Walker? Walker { get; set; }
        public DateTime Date { get; set; }
        public Timeslot Timeslot { get; set; }
        public DogActivityType Type { get; set; }
    }
}
