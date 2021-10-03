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

        public async Task<List<Domain.Entities.SendApplication>> GetAllAsync()
            => await _houseProjectDbContext.SendApplications.ToListAsync();

        public async Task<Domain.Entities.SendApplication> GetByIdAsync(int id)
            => await _houseProjectDbContext.SendApplications.FirstOrDefaultAsync(x => x.Id == id);

    }
}
