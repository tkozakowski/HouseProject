using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IApplicationRepository
    {
        public Task<Application> GetByIdAsync(int id);
        public Task<List<Application>> GetAllAsync();
    }
}
