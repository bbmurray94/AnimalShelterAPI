using AnimalShelter.Domain.Entities;

namespace AnimalShelter.Data.Interfaces
{
    public interface IWalkersBackend
    {
        Task<Walker?> GetWalker(int id);
        Task<IEnumerable<Walker>> GetWalkerList();
        Task<Walker?> AddWalker(Walker walker);
        Task<Walker?> UpdateWalker(int id, Walker walker);
        Task<bool> DeleteWalker(int id);
    }
}
