using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LoanTrancheRepository : ILoanTrancheRepository
    {
        private readonly HouseProjectDbContext _houseProjectDbContext;

        public LoanTrancheRepository(HouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public async Task<List<LoanTranche>> GetAllAsync()
            => await _houseProjectDbContext.LoanTranches.ToListAsync();

        public async Task<LoanTranche> GetByIdAsync(int id)
            => await _houseProjectDbContext.LoanTranches.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<LoanTranche> GetAsync(LoanTrancheStage stage)
            => await _houseProjectDbContext.LoanTranches.FirstOrDefaultAsync(x => x.Stage == stage);

        public async Task<bool> AddAsync(LoanTranche loanTranche)
        {
            _houseProjectDbContext.LoanTranches.Add(loanTranche);

            return await _houseProjectDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(LoanTranche loanTranche)
        {
            _houseProjectDbContext.LoanTranches.Update(loanTranche);

            return await _houseProjectDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(LoanTranche loanTranche)
        {
            _houseProjectDbContext.LoanTranches.Remove(loanTranche);

            return await _houseProjectDbContext.SaveChangesAsync() > 0;
        }
    }
}
