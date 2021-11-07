using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure
{
    public class Seeder
    {
        private readonly HouseProjectDbContext _dbContext;
        public Seeder(HouseProjectDbContext houseProjectDbContext)
        {
            _dbContext = houseProjectDbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();

                if(pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }
            }
        }

    }
}
