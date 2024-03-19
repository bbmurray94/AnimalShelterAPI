using AnimalShelter.Data.Data;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Data.Backends
{
    public class ActivitiesBackend : IActivitiesBackend
    {
        private readonly AnimalShelterContext _context;

        public ActivitiesBackend(AnimalShelterContext context) 
        { 
            _context = context;
        }

        public async Task<DogActivity> GetDogActivity(int id)
        {
            DogActivity dogActivity =  _context.DogActivities.Where(da => da.Id == id).Include(da => da.Walker).Include(da=> da.Dog).FirstOrDefault();
            return dogActivity;
        }

        public async Task<IEnumerable<DogActivity>> GetDogActivityList()
        {
            List<DogActivity> dogActivities = await _context.DogActivities.Include(da => da.Walker).Include(da=> da.Dog).ToListAsync();
            return dogActivities;
        }
    }
}
