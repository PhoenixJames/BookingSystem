using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Collections.Generic;

namespace BookingSystem.Entities
{
    public class BookingSystemContext : DbContext
    {



        public BookingSystemContext(DbContextOptions<BookingSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<UserPackage> UserPackages { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<UserClass> UserClasses { get; set; }
        public virtual DbSet<Waitlist> Waitlists { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));
                optionsBuilder.UseMySql("ConnectionStrings : DefaultConnection", serverVersion);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<UserProfile>()
                .HasKey(up => up.UserId);

            modelBuilder.Entity<Package>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<UserPackage>()
                .HasKey(up => new { up.UserId, up.PackageId });

            modelBuilder.Entity<Class>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<UserClass>()
                .HasKey(uc => new { uc.UserId, uc.ClassId });

            modelBuilder.Entity<Waitlist>()
                .HasKey(wl => new { wl.UserId, wl.ClassId });

            // Add foreign key relationships
            modelBuilder.Entity<UserPackage>()
                .HasOne(up => up.User)
                .WithMany(u => u.Packages)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserPackage>()
                .HasOne(up => up.Package)
                .WithMany(p => p.UserPackages)
                .HasForeignKey(up => up.PackageId);

            modelBuilder.Entity<UserClass>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.Classes)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserClass>()
                .HasOne(uc => uc.Class)
                .WithMany(c => c.UserClasses)
                .HasForeignKey(uc => uc.ClassId);

            modelBuilder.Entity<Waitlist>()
                .HasOne(wl => wl.User)
                .WithMany(u => u.Waitlists)
                .HasForeignKey(wl => wl.UserId);

            modelBuilder.Entity<Waitlist>()
                .HasOne(wl => wl.Class)
                .WithMany(c => c.Waitlists)
                .HasForeignKey(wl => wl.ClassId);
        }

    }
}
