using AnimalShelter.Data.Data;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace AnimalShelter.Data.Backends
{
    public class ActivitiesBackend : IActivitiesBackend
    {
        private readonly AnimalShelterContext _context;

        public ActivitiesBackend(AnimalShelterContext context) 
        { 
            _context = context;
        }

        public async Task<DogActivity?> AddDogActivity(DogActivity activity)
        {
            EntityEntry<DogActivity> created = _context.DogActivities.Add(activity);
            _context.SaveChanges();
            return created.Entity;
        }

        public async Task<bool> DeleteDogActivity(int id)
        {
            DogActivity? dbDogActivity = await _context.DogActivities.FindAsync(id);
            if (dbDogActivity == null)
            {
                return false;
            }
            _context.Remove(dbDogActivity);
            _context.SaveChanges();
            return true;
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

        public async Task<DogActivity?> UpdateDogActivity(int id, DogActivity activity)
        {
            DogActivity dbDogActivity = await _context.DogActivities.FindAsync(id);
            if (dbDogActivity == null)
            {
                return null;
            }
            dbDogActivity.DogId = activity.DogId;
            dbDogActivity.WalkerId = activity.WalkerId;
            dbDogActivity.Date = activity.Date;
            dbDogActivity.Timeslot = activity.Timeslot;
            dbDogActivity.Type = activity.Type;
            _context.SaveChanges();

            return dbDogActivity;
        }
    }
}
