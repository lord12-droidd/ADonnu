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
            modelBuilder.Entity<StudentSubjectEntity>().HasKey(sc => new { sc.StudentId, sc.SubjectId });

            modelBuilder.Entity<TeacherSubjectEntity>().HasKey(sc => new { sc.TeacherId, sc.SubjectId });

            modelBuilder.Entity<IndScheduleRequestTeacherEntity>().HasKey(sc => new { sc.IndScheduleRequestId, sc.TeacherId });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                    {
                        Id = "810d7566-a47f-4289-bc3d-3fbb6d7bd3c8",
                        Name = "Student",
                        NormalizedName = "STUDENT",
                    }, 
                new IdentityRole
                    {
                        Id = "b22a30c6-18ce-431f-8b10-dcf4f11b4391",
                        Name = "Teacher",
                        NormalizedName = "TEACHER",
                    }, 
                new IdentityRole
                    {
                        Id = "16aaa94d-d83d-45f1-9bac-c0a265e99d66",
                        Name = "Secretary",
                        NormalizedName = "SECRETARY",
                    },
                new IdentityRole
                    {
                        Id = "7ba8f3a2-2254-43c1-aa4f-9d953e479781",
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                    }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<SubjectEntity> Subjects { get; set; }
        public DbSet<StudentSubjectEntity> StudentSubjects { get; set; }
        public DbSet<TeacherSubjectEntity> TeacherSubjects { get; set; }
        public DbSet<IndScheduleRequestTeacherEntity> IndScheduleRequestTeachers { get; set; }
        public DbSet<UserEntity> ApplicationUsers { get; set; }
        public DbSet<IndScheduleRequestEntity> IndScheduleRequests { get; set; }
    }
}