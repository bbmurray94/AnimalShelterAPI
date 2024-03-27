using AnimalShelter.Domain.Entities;

namespace AnimalShelter.Data.Interfaces
{
    public interface IDogsBackend
    {
        Task<Dog?> GetDog(int id);
        Task<IEnumerable<Dog>> GetDogList();
        Task<Dog?> AddDog(Dog dog);
        Task<Dog?> UpdateDog(int id, Dog dog);
        Task<bool> DeleteDog(int id);
        Task<DogNote?> GetNoteForDog(int dogId, int noteId);
        Task<IEnumerable<DogNote>> GetNoteListForDog(int id);
        Task<IEnumerable<DogActivity>> GetActivitiesForDog(int id);
        Task<DogNote?> AddNote(DogNote dogNote);
        Task<DogNote?> UpdateNote(int dogId, int noteId, DogNote dogNote);
        Task<bool> DeleteNote(int dogId, int noteId);
    }
}
