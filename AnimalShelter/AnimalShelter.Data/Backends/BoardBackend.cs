using AnimalShelter.Data.Data;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Domain.Common;
using AnimalShelter.Domain.Entities;
using AnimalShelter.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace AnimalShelter.Data.Backends
{
    public class BoardBackend : IBoardBackend
    {
        private readonly AnimalShelterContext _context;
        private string[] formats = { "yyyy-MM-dd" };

        public BoardBackend(AnimalShelterContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BoardDogItem>> GetBoard(string? selectedDate)
        {
            if (selectedDate == null || !DateTime.TryParseExact(selectedDate, formats, CultureInfo.InvariantCulture
                , DateTimeStyles.None, out DateTime date)) 
            {
                selectedDate = DateTime.Today.ToString(formats[0]);
            }
            IEnumerable<BoardEntry?> entries = _context.BoardEntries.FromSql($"Call GetBoard({selectedDate})");
            List<BoardDogItem> result = new List<BoardDogItem>();

            foreach (BoardEntry b in entries) 
            {
                BoardDogItem newItem = result.FirstOrDefault(x => b?.Id == x?.DogId);

                if (newItem == null) 
                {
                    newItem = new BoardDogItem
                    {
                        DogId = b.Id,
                        Name = b.Name,
                        Location = b.Location,
                        KennelNumber = b.KennelNumber,
                        Level = b.Level,
                        IsHouseBroken = b.IsHouseBroken,
                        UnderHumaneInvestigation = b.UnderHumaneInvestigation,
                    };
                    result.Add(newItem);
                }
                BoardDogActivityItem dogActivityItem = new BoardDogActivityItem
                {
                    Date = b.Date,
                    Type = b.Type,
                    Timeslot = b.Timeslot,
                    FirstName = b.FirstName,
                    LastName = b.LastName,
                };
                switch (dogActivityItem.Timeslot) 
                {
                    case Timeslot.Morning:
                        newItem.Morning = dogActivityItem;
                        break;
                    case Timeslot.Afternoon:
                        newItem.Afternoon = dogActivityItem;
                        break;
                    case Timeslot.Evening:
                        newItem.Evening = dogActivityItem;
                        break;
                    default:
                        break;
                }               
            }
            return result;
        }
    }
}
