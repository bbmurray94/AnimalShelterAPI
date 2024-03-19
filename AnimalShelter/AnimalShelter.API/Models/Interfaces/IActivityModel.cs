namespace AnimalShelter.API.Models.Interfaces
{
    public interface IActivityModel
    {
        int Id { get; set;  }
        string? Date { get; set; }
        string? Timeslot { get; set; }
    }
}
