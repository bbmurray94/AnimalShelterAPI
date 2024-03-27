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

        public async Task<Dog?> UpdateDog(int id, Dog dog) 
        {
            Dog? dbDog = await _context.Dogs.FindAsync(id);
            if (dbDog == null) 
            {
                return null;
            }
            dbDog.Name = dog.Name;
            dbDog.Description = dog.Description;
            dbDog.Age = dog.Age;
            dbDog.Location = dog.Location;
            dbDog.Sex = dog.Sex;
            dbDog.Breed = dog.Breed;    
            dbDog.KennelNumber = dog.KennelNumber;
            dbDog.Level = dog.Level;
            dbDog.IsHouseBroken = dog.IsHouseBroken;
            dbDog.UnderHumaneInvestigation =dog.UnderHumaneInvestigation;
            _context.SaveChanges();

            return dbDog;
        }

        public async Task<bool> DeleteDog(int id) 
        {
            Dog? dbDog = await _context.Dogs.FindAsync(id);
            if (dbDog == null)
            {
                return false;
            }
            _context.Remove(dbDog);
            _context.SaveChanges();
            return true;
        }

        public async Task<DogNote?> GetNoteForDog(int dogId, int noteId) 
        {
            DogNote? dogNote = await _context.Notes.Where(d => d.Id == noteId && d.DogId == dogId).FirstOrDefaultAsync();
            return dogNote;
        }

        public async Task<IEnumerable<DogNote>> GetNoteListForDog(int id) 
        {
            List<DogNote>? dogNotes = await _context.Notes.Where(d => d.DogId == id).AsNoTrackingWithIdentityResolution().ToListAsync();
            return dogNotes;
        }

        public async Task<DogNote?> AddNote(DogNote dogNote) 
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<DogNote> created = _context.Notes.Add(dogNote);
            _context.SaveChanges();
            return created.Entity;
        }
        public async Task<DogNote?> UpdateNote(int dogId, int noteId, DogNote dogNote) 
        {
            DogNote dbDogNote =  _context.Notes.Where(d => d.DogId == dogId && d.Id == noteId).FirstOrDefault();
            if (dbDogNote == null)
            {
                return null;
            }
            dbDogNote.Note = dogNote.Note;
            if (dogId != dogNote.DogId && dogNote.DogId != 0)
            {
                dbDogNote.DogId = dogNote.DogId;
            }
            else 
            {
                dbDogNote.DogId = dogId;
            }
            _context.SaveChanges();

            return dbDogNote;
        }
        public async Task<bool> DeleteNote(int dogId, int noteId)
        {
            DogNote? dbDogNote = _context.Notes.Where(d => d.DogId == dogId && d.Id == noteId).FirstOrDefault();
            if (dbDogNote == null)
            {
                return false;
            }
            _context.Remove(dbDogNote);
            _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<DogActivity>> GetActivitiesForDog(int id)
        {
            List<DogActivity>? dogActivities = await _context.DogActivities.Where(d => d.DogId == id).Include(da => da.Walker).Include(da => da.Dog).AsNoTrackingWithIdentityResolution().ToListAsync();
            return dogActivities;
        }
    }
}
