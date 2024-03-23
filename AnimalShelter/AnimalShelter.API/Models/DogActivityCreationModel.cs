using AnimalShelter.API.Models.Interfaces;

namespace AnimalShelter.API.Models
{
    public class DogActivityCreationModel : IActivityModel
    {
        public int Id { get; set; }
        public int DogId { get; set; }
        public int WalkerId { get; set; }
        public string? Date { get; set; }
        public string? Timeslot { get; set; }
        public string? Type { get; set; }
    }
}
