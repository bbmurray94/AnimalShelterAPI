﻿using AnimalShelter.Domain.Entities;
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
        public virtual DbSet<DogActivity> DogActivities { get; set; }
        public virtual DbSet<BoardEntry> BoardEntries { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Dog>().Property(e => e.Level).HasConversion(v => v.ToString(), v => (Level)Enum.Parse(typeof(Level), v));
            modelBuilder.Entity<Dog>().Property(e => e.Sex).HasConversion(v => v.ToString(), v => (Sex)Enum.Parse(typeof(Sex), v));

            modelBuilder.Entity<Walker>().Property(e => e.Level).HasConversion(v => v.ToString(), v => (Level)Enum.Parse(typeof(Level), v));

            modelBuilder.Entity<DogActivity>().Property(e => e.Type).HasConversion(v => v.ToString(), v => (DogActivityType)Enum.Parse(typeof(DogActivityType), v));
            modelBuilder.Entity<DogActivity>().Property(e => e.Timeslot).HasConversion(v => v.ToString(), v => (Timeslot)Enum.Parse(typeof(Timeslot), v));

            modelBuilder.Entity<BoardEntry>().Property(e => e.Type).HasConversion(v => v.ToString(), v => (DogActivityType)Enum.Parse(typeof(DogActivityType), v));
            modelBuilder.Entity<BoardEntry>().Property(e => e.Timeslot).HasConversion(v => v.ToString(), v => (Timeslot)Enum.Parse(typeof(Timeslot), v));
            modelBuilder.Entity<BoardEntry>().Property(e => e.Level).HasConversion(v => v.ToString(), v => (Level)Enum.Parse(typeof(Level), v));
        }
    }
}
