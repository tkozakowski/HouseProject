using HouseProject.Domain.Entities;
using HouseProject.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace HouseProject.Persistence
{
    public class HouseProjectDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public HouseProjectDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorkStage> WorkStages { get; set; }
        public DbSet<LoanTranche> LoanTranches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanTranche>()
                .Property(e => e.Stage)
                .HasConversion(
                    v => v.ToString(),
                    v => (LoanTrancheStage)Enum.Parse(typeof(LoanTrancheStage), v));
            modelBuilder.Entity<Application>()
                .Property(e => e.Payment)
                .HasConversion(
                    v => v.ToString(),
                    v => (Payment)Enum.Parse(typeof(Payment), v));

            modelBuilder.Entity<Project>()
                .Property(e => e.Payment)
                .HasConversion(
                    v => v.ToString(),
                    v => (Payment)Enum.Parse(typeof(Payment), v));

            modelBuilder.Entity<Document>()
                .Property(e => e.Description)
                .HasMaxLength(250);
            modelBuilder.Entity<Document>()
                .HasOne(d => d.SendType)
                .WithMany(s => s.Documents);
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Project)
                .WithMany(p => p.Documents);
            modelBuilder.Entity<Document>()
                .Property(d => d.Stage)
                .HasConversion(
                    v => v.ToString(),
                    v => (Stage)Enum.Parse(typeof(Stage), v));
            modelBuilder.Entity<Document>()
                .Property(e => e.Payment)
                .HasConversion(
                    v => v.ToString(),
                    v => (Payment)Enum.Parse(typeof(Payment), v));

        }
    }

}
