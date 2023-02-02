using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Student",
                        NormalizedName = "STUDENT",
                    }, 
                new IdentityRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Teacher",
                        NormalizedName = "TEACHER",
                    }, 
                new IdentityRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Secretary",
                        NormalizedName = "SECRETARY",
                    }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        //public DbSet<SubjectEntity> Subjects { get; set; }
        public DbSet<UserEntity> ApplicationUsers { get; set; }
    }
}