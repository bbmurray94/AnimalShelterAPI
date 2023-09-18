using AnimalShelter.Data.Data;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Data.Backends
{
    public class DogsBackend : IDogsBackend
    {
        private readonly AnimalShelterContext _context;

        public DogsBackend(AnimalShelterContext context) 
        {
            _context = context;
        }
        
        public async Task<Dog?> GetDog(int id)
        {
            Dog? dog = await _context.Dogs.FindAsync(id);
            return dog;
        }

        public async Task<IEnumerable<Dog>> GetDogList()
        {
            List<Dog>? dogs = await _context.Dogs.AsNoTrackingWithIdentityResolution().ToListAsync();
            return dogs;
        }

        public async Task<Dog?> AddDog(Dog dog) 
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Dog> created = _context.Dogs.Add(dog);
            _context.SaveChanges();
            return created.Entity;
        }
    }
}
