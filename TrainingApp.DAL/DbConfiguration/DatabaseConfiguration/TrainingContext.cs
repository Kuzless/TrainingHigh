using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training__DAL_.Models;

namespace TrainingApp.DAL.DbConfiguration.DatabaseConfiguration
{
    public class TrainingContext : DbContext
    {
        public TrainingContext(DbContextOptions<TrainingContext> options)
    : base(options)
        {
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Salary> Salarys { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SubjectName> SubjectNames { get; set; }
        public DbSet<SubjectTariff> SubjectTariffes { get; set; }
        public DbSet<SubjectType> SubjectTypes { get; set; }
        public DbSet<TeacherInfo> Teachers { get; set; }
        public DbSet<WorkedHours> WorkedHours { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelsConfiguration.ConfigureAll(modelBuilder);
            Seed.SeedData(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TrainingDb;Trusted_Connection=True;");
        }
    }
}
