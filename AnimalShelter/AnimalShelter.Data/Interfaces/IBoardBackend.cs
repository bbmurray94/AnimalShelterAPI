using AnimalShelter.Domain.Common;

namespace AnimalShelter.Data.Interfaces
{
    public interface IBoardBackend
    {
        Task<IEnumerable<BoardDogItem>> GetBoard(string? selectedDate);
    }
}
