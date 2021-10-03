using Domain.Entities.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICosmosDocumentRepository
    {
        public Task<CosmosDocument> GetByIdAsync(string id);
        public Task<IEnumerable<CosmosDocument>> GetAllAsync();
        public Task<CosmosDocument> AddAsync(CosmosDocument document);
        public Task RemoveAsync(CosmosDocument document);
        public Task UpdateAsync(CosmosDocument document);
    }
}
