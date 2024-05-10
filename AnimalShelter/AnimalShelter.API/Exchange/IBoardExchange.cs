using AnimalShelter.API.Models;
using AnimalShelter.Domain.Common;

namespace AnimalShelter.API.Exchange
{
    public interface IBoardExchange
    {
        IEnumerable<BoardDogItemModel?> Pack(IEnumerable<BoardDogItem?> boardDogItems);
        BoardDogItemModel? Pack(BoardDogItem? boardDogItem);
        BoardDogActivityItemModel Pack(BoardDogActivityItem boardDogActivityItem);
    }
}
