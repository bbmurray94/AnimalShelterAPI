using AnimalShelter.Domain.Entities;

namespace AnimalShelter.Data.Interfaces
{
    public interface IActivitiesBackend
    {
        Task<IEnumerable<DogActivity>> GetDogActivityList();
        Task<DogActivity> GetDogActivity(int id);
        Task<DogActivity?> AddDogActivity(DogActivity activity);
        Task<DogActivity?> UpdateDogActivity(int id, DogActivity activity);
        Task<bool> DeleteDogActivity(int id);
    }
}
