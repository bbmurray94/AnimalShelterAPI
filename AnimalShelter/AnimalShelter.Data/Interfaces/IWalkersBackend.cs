using AnimalShelter.Domain.Entities;

namespace AnimalShelter.Data.Interfaces
{
    public interface IWalkersBackend
    {
        Task<Walker?> GetWalker(int id);
        Task<IEnumerable<Walker>> GetWalkerList();
    }
}
