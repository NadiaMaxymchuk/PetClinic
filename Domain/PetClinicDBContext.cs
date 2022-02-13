using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public  class PetClinicDBContext: DbContext
    {
        public PetClinicDBContext(DbContextOptions<PetClinicDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            //Database.Migrate();
        }
        
         public DbSet<Appointment> Appointments { get; set; }
         public DbSet<User> Users { get; set; }
         public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<User>()
                .HasKey(x=>x.Id);

            modelBuilder.Entity<Appointment>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
                .HasMany(x=>x.Pets)
                .WithOne(x=>x.Owner)
                .HasForeignKey(x=>x.OwnerId);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Appointments)
                .WithOne(x => x.Doctor)
                .HasForeignKey(x => x.DoctorId);

            modelBuilder.Entity<Pet>()
                .HasMany(x => x.Appointments)
                .WithOne(x => x.Pet)
                .HasForeignKey(x => x.PetId);

        }
    }

}
