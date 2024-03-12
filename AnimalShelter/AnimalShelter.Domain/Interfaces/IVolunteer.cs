namespace AnimalShelter.Domain.Interfaces
{
    internal interface IVolunteer
    {
        int Id { get; set; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
    }
}
