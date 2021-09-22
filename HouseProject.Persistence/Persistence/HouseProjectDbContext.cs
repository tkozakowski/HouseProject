using Domain.Common;
using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public DbSet<Material> Materials { get; set; }
        public DbSet<Execution> Executions { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Finance> Finances { get; set; }
        public DbSet<Stage> Stages { get; set; }

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
                .HasOne(d => d.Stage)
                .WithMany(p => p.Documents);                

            modelBuilder.Entity<Project>()
                .Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Project>()
                .HasOne(e => e.PaymentType)
                .WithMany(d => d.Projects);


            modelBuilder.Entity<Preparation>()
                .Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Preparation>()
                .HasOne(e => e.PaymentType)
                .WithMany(d => d.Preparations);


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

            modelBuilder.Entity<Material>()
                .HasOne(e => e.LoanTranche)
                .WithMany(d => d.Materials);
            modelBuilder.Entity<Material>()
                .HasOne(e => e.Execution)
                .WithMany(d => d.Materials);
            modelBuilder.Entity<Material>()
                .HasOne(e => e.PaymentType)
                .WithMany(d => d.Materials);

            modelBuilder.Entity<Execution>()
                .HasOne(e => e.WorkStage)
                .WithMany(d => d.Executions);

            modelBuilder.Entity<Finance>()
                .HasOne(e => e.LoanTranche)
                .WithMany(d => d.Finances);

        }

        public async Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var item in entries)
            {
                ((AuditableEntity)item.Entity).LastModified = DateTime.Now;

                if(item.State == EntityState.Added)
                {
                    ((AuditableEntity)item.Entity).CreatedAt = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync();
        }

    }

}
