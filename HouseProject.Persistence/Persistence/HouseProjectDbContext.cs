using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Infrastructure.Persistence
{
    public class HouseProjectDbContext : DbContext
    {
        public HouseProjectDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Application> Applications { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<LoanTranche> LoanTranches { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Preparation> Preparations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SendType> SendTypes { get; set; }
        public DbSet<WorkStage> WorkStages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Document>()
                .Property(d => d.Name)
                .HasMaxLength(100)
                .IsRequired();
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
                .HasOne(d => d.Preparation)
                .WithMany(p => p.Documents);
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Post)
                .WithMany(p => p.Documents);
            modelBuilder.Entity<Document>()
                .Property(d => d.Stage)
                .HasConversion(
                    v => v.ToString(),
                    v => (Stage)Enum.Parse(typeof(Stage), v));

            modelBuilder.Entity<Project>()
                .Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Project>()
                .Property(e => e.Payment)
                .HasConversion(
                    v => v.ToString(),
                    v => (Payment)Enum.Parse(typeof(Payment), v));

            modelBuilder.Entity<Preparation>()
                .Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Preparation>()
                .Property(e => e.Payment)
                .HasConversion(
                    v => v.ToString(),
                    v => (Payment)Enum.Parse(typeof(Payment), v));

            modelBuilder.Entity<SendType>()
                .Property(e => e.Name)
                .IsRequired();

            modelBuilder.Entity<Post>()
                .Property(e => e.Name)
                .IsRequired();

            modelBuilder.Entity<Application>()
                .HasOne(e => e.SendType)
                .WithMany(d => d.Applications);
            modelBuilder.Entity<Application>()
                .HasOne(e => e.Post)
                .WithMany(d => d.Applications);

            modelBuilder.Entity<Attachment>()
                .Property(e => e.Name)
                .IsRequired();
            modelBuilder.Entity<Attachment>()
                .HasOne(e => e.Application)
                .WithMany(d => d.Attachments);

            modelBuilder.Entity<LoanTranche>()
                .Property(e => e.Stage)
                .HasConversion(
                    v => v.ToString(),
                    v => (LoanTrancheStage)Enum.Parse(typeof(LoanTrancheStage), v));

        }
    }

}
