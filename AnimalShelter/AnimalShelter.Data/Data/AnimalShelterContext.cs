using AnimalShelter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Data.Data
{
    public class AnimalShelterContext : DbContext
    {
        public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options) : base(options) 
        {
           
        }
        public virtual DbSet<Dog> Dogs { get; set; }
    }
}
