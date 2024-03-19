using AnimalShelter.API.Models.Interfaces;

namespace AnimalShelter.API.Models
{
    public class DogActivityModel : IActivityModel
    {
        public int Id { get; set; }
        public DogModel? Dog { get; set; }
        public WalkerModel? Walker { get; set; }
        public string? Date { get; set; }
        public string? Timeslot { get; set; }
        public string Type { get; set; }
    }
}
