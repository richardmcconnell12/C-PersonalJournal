using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalJournal.Models;

namespace PersonalJournal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<PersonalJournal.Models.Entry> Entry { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Intitial user seeding 
            modelBuilder.Entity<Entry>()
                .Property(d => d.DateCreated)
                .HasDefaultValueSql("getdate()");

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Admini",
                LastName = "Strator",
                Email = "administrator@internet.com",
                NormalizedEmail = "ADMINISTRATOR@INTERNET.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Abc123!");
            modelBuilder.Entity<ApplicationUser>().HasData(user);


        }
    }
}
