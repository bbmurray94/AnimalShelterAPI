using AnimalShelter.Domain.Entities;
using AnimalShelter.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Data.Data
{
    public class AnimalShelterContext : DbContext
    {
        public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options) : base(options) 
        {
           
        }
        public virtual DbSet<Dog> Dogs { get; set; }
        public virtual DbSet<DogNote> Notes { get; set; }
        public virtual DbSet<Walker> Walkers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Dog>().Property(e => e.Level).HasConversion(v => v.ToString(), v => (Level)Enum.Parse(typeof(Level), v));
            modelBuilder.Entity<Dog>().Property(e => e.Sex).HasConversion(v => v.ToString(), v => (Sex)Enum.Parse(typeof(Sex), v));

            modelBuilder.Entity<Walker>().Property(e => e.Level).HasConversion(v => v.ToString(), v => (Level)Enum.Parse(typeof(Level), v));
        }
    }
}
