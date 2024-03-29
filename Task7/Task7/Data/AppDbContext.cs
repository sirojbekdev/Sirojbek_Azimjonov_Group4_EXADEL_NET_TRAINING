﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Task7.Models;

namespace Task7.Data
{
    public class AppDbContext :DbContext
    {
        private readonly IConfiguration _IConfiguration;
        private readonly string _ConnectionString;
        public AppDbContext()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _IConfiguration = builder.Build();
            _ConnectionString = _IConfiguration.GetConnectionString("default");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_ConnectionString);
        }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassSubject> ClassSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassSubject>()
                .HasKey(cs => new { cs.ClassId, cs.SubjectId });
            modelBuilder.Entity<ClassSubject>()
                .HasOne(cs => cs.Class)
                .WithMany(c => c.ClassSubjects)
                .HasForeignKey(bc => bc.ClassId);
            modelBuilder.Entity<ClassSubject>()
                .HasOne(cs => cs.Subject)
                .WithMany(s => s.ClassSubjects)
                .HasForeignKey(cs => cs.SubjectId);
        }
    }
}
