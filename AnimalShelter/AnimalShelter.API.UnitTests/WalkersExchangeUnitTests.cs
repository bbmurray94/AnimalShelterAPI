using AnimalShelter.API.Exchange;
using AnimalShelter.API.Models;
using AnimalShelter.Domain.Entities;
using AnimalShelter.Domain.Enums;
using NUnit.Framework;

namespace AnimalShelter.API.UnitTests
{
    internal class WalkersExchangeUnitTests
    {
        private readonly int AValidId = 1;
        private readonly int AValidId2 = 2;
        private readonly string? AValidFirstName = "John";
        private readonly string? AValidFirstName2 = "Sarah";
        private readonly string? AValidLastName = "Smith";
        private readonly string? AValidLastName2 = "Baker";
        private readonly Level AValidLevel = Level.Green;
        private readonly Level AValidLevel2 = Level.Yellow;

        [Test]
        public void WalkersExchange__Walker_Pack_ValidObject_ReturnsAValidModel()
        {
            Walker walker = new Walker
            {
                Id = AValidId,
                FirstName = AValidFirstName,
                LastName = AValidLastName,
                Level = AValidLevel,
            };

            WalkersExchange walkerExchange = new WalkersExchange();
            WalkerModel? model = walkerExchange.Pack(walker);

            Assert.IsNotNull(model);
            Assert.That(model?.Id, Is.EqualTo(AValidId));
            Assert.That(model?.FirstName, Is.EqualTo(AValidFirstName));
            Assert.That(model?.LastName, Is.EqualTo(AValidLastName));
            Assert.That(model?.Level, Is.EqualTo(AValidLevel.ToString()));
        }

        [Test]
        public void WalkersExchange__Walker_Pack_EmptyObject_ReturnsEmptyObject()
        {
            Walker walker = new Walker();

            WalkersExchange walkerExchange = new WalkersExchange();
            WalkerModel? model = walkerExchange.Pack(walker);

            Assert.IsNotNull(model);
            Assert.That(model?.Id, Is.EqualTo(0));
            Assert.That(model?.FirstName, Is.Null);
            Assert.That(model?.LastName, Is.Null);
            Assert.That(model?.Level, Is.EqualTo(Level.Blue.ToString()));
        }

        [Test]
        public void WalkersExchange__Dog_Pack_NullObject_ReturnsNullObject()
        {
            Walker? walker = null;

            WalkersExchange walkerExchange = new WalkersExchange();
            WalkerModel? model = walkerExchange.Pack(walker);

            Assert.IsNull(model);
        }

        [Test]
        public void WalkersExchange__WalkerList_Pack_ValidList_ReturnsAValidModelList()
        {
            List<Walker> walkerList = new List<Walker>()
            {
                new Walker
                {
                    Id = AValidId,
                    FirstName = AValidFirstName,
                    LastName = AValidLastName,
                    Level = AValidLevel,
                },
                new Walker
                {
                    Id = AValidId2,
                    FirstName = AValidFirstName2,
                    LastName = AValidLastName2,
                    Level = AValidLevel2,
                }
            };

            WalkersExchange walkersExchange = new WalkersExchange();
            List<WalkerModel?> modelList = walkersExchange.Pack(walkerList).ToList();

            Assert.That(modelList, Is.Not.Empty);
            Assert.That(modelList[0]?.Id, Is.EqualTo(AValidId));
            Assert.That(modelList[0]?.FirstName, Is.EqualTo(AValidFirstName));
            Assert.That(modelList[0]?.LastName, Is.EqualTo(AValidLastName));
            Assert.That(modelList[0]?.Level, Is.EqualTo(AValidLevel.ToString()));
            Assert.That(modelList[1]?.Id, Is.EqualTo(AValidId2));
            Assert.That(modelList[1]?.FirstName, Is.EqualTo(AValidFirstName2));
            Assert.That(modelList[1]?.LastName, Is.EqualTo(AValidLastName2));
            Assert.That(modelList[1]?.Level, Is.EqualTo(AValidLevel2.ToString()));
        }

        [Test]
        public void WalkersExchange__DogList_Pack_EmptyList_ReturnsNullObjectList()
        {
            List<Walker> walkerList = new List<Walker>();

            WalkersExchange walkersExchange = new WalkersExchange();
            List<WalkerModel?> modelList = walkersExchange.Pack(walkerList).ToList();

            Assert.That(modelList, Is.Empty);
        }

        [Test]
        public void WalkersExchange__Walker_Unpack_ValidModel_ReturnsAValidObject()
        {
            WalkerModel model = new WalkerModel
            {
                Id = AValidId,
                FirstName = AValidFirstName,
                LastName = AValidLastName,
                Level = AValidLevel.ToString(),
            };

            WalkersExchange walkerExchange = new WalkersExchange();
            Walker? walker = walkerExchange.Unpack(model);

            Assert.NotNull(walker);
            Assert.That(walker?.Id, Is.EqualTo(AValidId));
            Assert.That(walker?.FirstName, Is.EqualTo(AValidFirstName));
            Assert.That(walker?.LastName, Is.EqualTo(AValidLastName));
            Assert.That(walker?.Level, Is.EqualTo(AValidLevel));
        }
        [Test]
        public void WalkersExchange__Walker_Unpack_NullModel_ReturnsNullObject()
        {
            WalkerModel model = null;

            WalkersExchange walkersExchange = new WalkersExchange();
            Walker? walker = walkersExchange.Unpack(model);

            Assert.Null(walker);
        }

        [Test]
        public void WalkersExchange__Walker_Unpack_EmptyModel_ReturnsEmptyObject() 
        {
            WalkerModel model = new WalkerModel();

            WalkersExchange walkersExchange = new WalkersExchange();
            Walker? walker = walkersExchange.Unpack(model);

            Assert.NotNull(walker);
            Assert.That(walker?.Id, Is.EqualTo(0));
            Assert.That(walker?.FirstName, Is.Null);
            Assert.That(walker?.LastName, Is.Null);
            Assert.That(walker?.Level, Is.EqualTo(Level.Blue));
        }
    }
}
