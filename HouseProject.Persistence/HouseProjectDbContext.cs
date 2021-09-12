using HouseProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HouseProject.Persistence
{
    public class HouseProjectDbContext: DbContext
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
    }

}
