using AnimalShelter.Domain.Enums;

namespace AnimalShelter.Domain.Common
{
    public class BoardDogItem
    {
        public int DogId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string KennelNumber { get; set; }
        public Level Level { get; set; }
        public bool IsHouseBroken { get; set; }
        public bool UnderHumaneInvestigation { get; set; }
        public BoardDogActivityItem? Morning { get; set; }
        public BoardDogActivityItem? Afternoon { get; set; }
        public BoardDogActivityItem? Evening { get; set; }
    }
}
