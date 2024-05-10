using AnimalShelter.API.Models;
using AnimalShelter.Domain.Common;

namespace AnimalShelter.API.Exchange
{
    public class BoardExchange : IBoardExchange
    {
        public IEnumerable<BoardDogItemModel?> Pack(IEnumerable<BoardDogItem?> boardDogItems)
        {
            List<BoardDogItemModel> models = new List<BoardDogItemModel>();
            if (boardDogItems == null) 
            {
                return models;
            }

            foreach(BoardDogItem? item in boardDogItems) 
            {
                models.Add(Pack(item));
            }
            return models;
        }

        public BoardDogItemModel? Pack(BoardDogItem? boardDogItem)
        {
            if (boardDogItem == null) 
            {
                return null;
            }

            return new BoardDogItemModel 
            {
                DogId = boardDogItem.DogId,
                Name = boardDogItem.Name,
                Location = boardDogItem.Location,
                KennelNumber = boardDogItem.KennelNumber,
                Level = boardDogItem.Level.ToString(),
                IsHouseBroken = boardDogItem.IsHouseBroken,
                UnderHumaneInvestigation = boardDogItem.UnderHumaneInvestigation,
                Morning = Pack(boardDogItem.Morning),
                Afternoon = Pack(boardDogItem.Afternoon),
                Evening = Pack(boardDogItem.Evening)
            };
        }

        public BoardDogActivityItemModel? Pack(BoardDogActivityItem boardDogActivityItem)
        {
            if (boardDogActivityItem == null) 
            {
                return null;
            }
            return new BoardDogActivityItemModel
            { 
                 Date = boardDogActivityItem.Date.ToString("yyyy-MM-dd"),
                 Timeslot = boardDogActivityItem.Timeslot.ToString(),
                 Type = boardDogActivityItem.Type.ToString(),
                 FirstName = boardDogActivityItem.FirstName.ToString(),
                 LastName = boardDogActivityItem.LastName.ToString(),
            };
        }
    }
}
