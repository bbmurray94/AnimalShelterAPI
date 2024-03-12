namespace AnimalShelter.API.Models.Interfaces
{
    public interface IVolunteerModel
    {
        int Id { get; set; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
    }
}
