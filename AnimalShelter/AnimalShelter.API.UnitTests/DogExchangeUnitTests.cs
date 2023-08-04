using AnimalShelter.API.Exchange;
using AnimalShelter.API.Models;
using AnimalShelter.Domain.Entities;
using AnimalShelter.Domain.Enums;
using NUnit.Framework;
using System.Diagnostics;
using System.Reflection;

namespace AnimalShelter.API.UnitTests
{
    internal class DogExchangeUnitTests
    {
        private readonly int AValidId = 1;
        private readonly int AValidId2 = 2;
        private readonly string? AValidName = "Bubby";
        private readonly string? AValidName2 = "Hero";
        private readonly string? AValidDescription = "Needs harness";
        private readonly string? AValidDescription2 = "Bring treats";
        private readonly int AValidAge = 5;
        private readonly int AValidAge2 = 2;
        private readonly bool AValidHumaneInvestigation = false;
        private readonly bool AValidHumaneInvestigation2 = false;
        private readonly Sex AValidSex = Sex.Male;
        private readonly Sex AValidSex2 = Sex.Female;
        private readonly Level AValidLevel = Level.Green;
        private readonly Level AValidLevel2 = Level.Yellow;
        private readonly string? AValidLocation = "Dog Hold A";
        private readonly string? AValidLocation2 = "Dog Hold B";
        private readonly string? AValidKennelNumber = "13";
        private readonly string? AValidKennelNumber2 = "12";
        private readonly bool AValidIsHouseBroken = true;
        private readonly bool AValidIsHouseBroken2 = true;
        private readonly string? AValidBreed = "Pit Bull mix";
        private readonly string? AValidBreed2 = "Terror mix";

        [Test]
        public void DogsExchange__ValidObject_ReturnsAValidModel() 
        {
            Dog dog = new Dog
            {
                Id = AValidId,
                Name = AValidName,
                Description = AValidDescription,
                Age = AValidAge,
                HumaneInvestigation = AValidHumaneInvestigation,
                Sex = AValidSex,
                Level = AValidLevel,
                Location = AValidLocation,
                KennelNumber = AValidKennelNumber,
                IsHouseBroken = AValidIsHouseBroken,
                Breed = AValidBreed,              
            };

            DogsExchange dogExchange = new DogsExchange();
            DogModel? model = dogExchange.Pack(dog);

            Assert.IsNotNull(model);
            Assert.That(model?.Id, Is.EqualTo(AValidId));
            Assert.That(model?.Name, Is.EqualTo(AValidName));
            Assert.That(model?.Description, Is.EqualTo(AValidDescription));
            Assert.That(model?.Age, Is.EqualTo(AValidAge));
            Assert.That(model?.HumaneInvestigation, Is.EqualTo(AValidHumaneInvestigation));
            Assert.That(model?.Sex, Is.EqualTo(AValidSex));
            Assert.That(model?.Level, Is.EqualTo(AValidLevel.ToString()));
            Assert.That(model?.Location, Is.EqualTo(AValidLocation));
            Assert.That(model?.KennelNumber, Is.EqualTo(AValidKennelNumber));
            Assert.That(model?.IsHouseBroken, Is.EqualTo(AValidIsHouseBroken));
            Assert.That(model?.Breed, Is.EqualTo(AValidBreed));
        }

        [Test]
        public void DogsExchange__EmptyObject_ReturnsNullObject() 
        {
            Dog dog = new Dog();

            DogsExchange dogExchange = new DogsExchange();
            DogModel? model = dogExchange.Pack(dog);

            Assert.IsNotNull(model);
            Assert.That(model?.Id, Is.EqualTo(0));
            Assert.That(model?.Name, Is.Null);
            Assert.That(model?.Description, Is.Null);
            Assert.That(model?.Age, Is.EqualTo(0));
            Assert.That(model?.HumaneInvestigation, Is.False);
            Assert.That(model?.Sex, Is.EqualTo(Sex.Unknown));
            Assert.That(model?.Level, Is.EqualTo(Level.Blue.ToString()));
            Assert.That(model?.Location, Is.Null);
            Assert.That(model?.KennelNumber, Is.Null);
            Assert.That(model?.IsHouseBroken, Is.False);
            Assert.That(model?.Breed, Is.Null);
        }

        [Test]
        public void DogsExchange__NullObject_ReturnsNullObject()
        {
            Dog? dog = null;

            DogsExchange dogExchange = new DogsExchange();
            DogModel? model = dogExchange.Pack(dog);

            Assert.IsNull(model);
        }

        [Test]
        public void DogsExchange__List_ValidList_ReturnsAValidModelList() 
        {
            List<Dog> dogList = new List<Dog>()
            {
                new Dog
                {
                    Id = AValidId,
                    Name = AValidName,
                    Description = AValidDescription,
                    Age = AValidAge,
                    HumaneInvestigation = AValidHumaneInvestigation,
                    Sex = AValidSex,
                    Level = AValidLevel,
                    Location = AValidLocation,
                    KennelNumber = AValidKennelNumber,
                    IsHouseBroken = AValidIsHouseBroken,
                    Breed = AValidBreed,
                },
                new Dog
                {
                    Id = AValidId2,
                    Name = AValidName2,
                    Description = AValidDescription2,
                    Age = AValidAge2,
                    HumaneInvestigation = AValidHumaneInvestigation2,
                    Sex = AValidSex2,
                    Level = AValidLevel2,
                    Location = AValidLocation2,
                    KennelNumber = AValidKennelNumber2,
                    IsHouseBroken = AValidIsHouseBroken2,
                    Breed = AValidBreed2,
                }
            };
            
            DogsExchange dogsExchange = new DogsExchange();
            List<DogModel?> modelList = dogsExchange.Pack(dogList).ToList();

            Assert.That(modelList, Is.Not.Empty);
            Assert.That(modelList[0]?.Id, Is.EqualTo(AValidId));
            Assert.That(modelList[0]?.Name, Is.EqualTo(AValidName));
            Assert.That(modelList[1]?.Id, Is.EqualTo(AValidId2));
            Assert.That(modelList[1]?.Name, Is.EqualTo(AValidName2));
        }

        [Test]
        public void DogsExchange__List_EmptyList_ReturnsNullObjectList() 
        {
            List<Dog> dogList = new List<Dog>();

            DogsExchange dogsExchange = new DogsExchange();
            List<DogModel?> modelList = dogsExchange.Pack(dogList).ToList();

            Assert.That(modelList, Is.Empty);
        }

    }
}
