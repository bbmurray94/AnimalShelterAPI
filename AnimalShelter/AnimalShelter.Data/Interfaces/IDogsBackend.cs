using AnimalShelter.Domain.Entities;

namespace AnimalShelter.Data.Interfaces
{
    public interface IDogsBackend
    {
        Task<Dog?> GetDog(int id);

        Task<IEnumerable<Dog>> GetDogList();

        Task<Dog?> AddDog(Dog dog);

        Task<Dog?> UpdateDog(int id, Dog dog);
    }
}
