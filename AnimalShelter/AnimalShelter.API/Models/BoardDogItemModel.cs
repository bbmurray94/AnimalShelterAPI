namespace AnimalShelter.API.Models
{
    public class BoardDogItemModel
    {
        public int DogId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string KennelNumber { get; set; }
        public string Level { get; set; }
        public bool IsHouseBroken { get; set; }
        public bool UnderHumaneInvestigation { get; set; }
        public BoardDogActivityItemModel? Morning { get; set; }
        public BoardDogActivityItemModel? Afternoon { get; set; }
        public BoardDogActivityItemModel? Evening { get; set; }
    }
}
