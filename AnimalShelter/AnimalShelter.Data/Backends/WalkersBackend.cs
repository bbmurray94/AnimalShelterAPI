using AnimalShelter.Data.Data;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Data.Backends
{
    public class WalkersBackend : IWalkersBackend
    {
        private readonly AnimalShelterContext _context;

        public WalkersBackend(AnimalShelterContext context)
        {
            _context = context;
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
    }
}