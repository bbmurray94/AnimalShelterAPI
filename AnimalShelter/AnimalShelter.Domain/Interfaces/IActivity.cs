using AnimalShelter.Domain.Enums;

namespace AnimalShelter.Domain.Interfaces
{
    internal interface IActivity
    {
        int Id { get; set; }
        DateTime Date { get; set; }
        Timeslot Timeslot { get; set; }
    }
}
