﻿namespace AnimalShelter.API.Models.Interfaces
{
    public interface IAnimalModel
    {
        int Id { get; set; }
        string? Name { get; set; }
        string? Description { get; set; }
        int Age { get; set; }
        string Sex { get; set; }
        bool UnderHumaneInvestigation { get; set; }
    }
}
