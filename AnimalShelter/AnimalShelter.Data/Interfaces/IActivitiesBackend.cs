using AnimalShelter.Domain.Entities;

namespace AnimalShelter.Data.Interfaces
{
    public interface IActivitiesBackend
    {
        Task<IEnumerable<DogActivity>> GetDogActivityList();
        Task<DogActivity> GetDogActivity(int id);
    }
}
