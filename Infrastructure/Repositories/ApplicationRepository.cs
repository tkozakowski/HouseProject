using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly HouseProjectDbContext _houseProjectDbContext;

        public ApplicationRepository(HouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<List<Domain.Entities.Application>> GetAllAsync()
            => await _houseProjectDbContext.Applications.ToListAsync();

        public async Task<Domain.Entities.Application> GetByIdAsync(int id)
            => await _houseProjectDbContext.Applications.FirstOrDefaultAsync(x => x.Id == id);

    }
}
