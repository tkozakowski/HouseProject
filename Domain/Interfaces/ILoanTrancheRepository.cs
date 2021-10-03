using Domain.Entities;
using Domain.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILoanTrancheRepository
    {
        public Task<List<LoanTranche>> GetAllAsync();
        public Task<LoanTranche> GetByIdAsync(int id);
        public Task<LoanTranche> GetAsync(LoanTrancheStage stage);
        public Task<bool> AddAsync(LoanTranche loanTranche);
        public Task<bool> UpdateAsync(LoanTranche loanTranche);
        public Task<bool> DeleteAsync(LoanTranche loanTranche);
    }
}
