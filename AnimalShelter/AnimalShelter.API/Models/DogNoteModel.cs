using AnimalShelter.API.Models.Interfaces;

namespace AnimalShelter.API.Models
{
    public class DogNoteModel : INoteModel
    {
        public int Id { get; set; }
        public string? Note { get; set; }
        public int DogId { get; set; }
    }
}
