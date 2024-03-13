using AnimalShelter.Data.Data;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;

namespace AnimalShelter.Data.Backends
{
    public class WalkersBackend : IWalkersBackend
    {
        private readonly AnimalShelterContext _context;

        public WalkersBackend(AnimalShelterContext context)
        {
            _context = context;
        }

        public async Task<Walker?> AddWalker(Walker walker)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Walker> created = _context.Walkers.Add(walker);
            _context.SaveChanges();
            return created.Entity;
        }

        public async Task<bool> DeleteWalker(int id)
        {
            Walker? dbWaler = await _context.Walkers.FindAsync(id);
            if (dbWaler == null)
            {
                return false;
            }
            _context.Remove(dbWaler);
            _context.SaveChanges();
            return true;
        }

        public async Task<Walker?> GetWalker(int id)
        {
            Walker? walker = await _context.Walkers.FindAsync(id);
            return walker;
        }

        public async Task<IEnumerable<Walker>> GetWalkerList()
        {
            List<Walker>? walkers = await _context.Walkers.AsNoTrackingWithIdentityResolution().ToListAsync();
            return walkers;
        }

        public async Task<Walker?> UpdateWalker(int id, Walker walker)
        {
            Walker? dbWalker = await _context.Walkers.FindAsync(id);
            if (dbWalker == null)
            {
                return null;
            }

            dbWalker.FirstName = walker.FirstName;
            dbWalker.LastName = walker.LastName;
            dbWalker.Level = walker.Level;
            _context.SaveChanges();

            return dbWalker;
        }
    }
}