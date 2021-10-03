using Cosmonaut;
using Domain.Entities.Cosmos;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CosmosDocumentRepository : ICosmosDocumentRepository
    {
        private readonly ICosmosStore<CosmosDocument> _cosmosStore;

        public CosmosDocumentRepository(ICosmosStore<CosmosDocument> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task<IEnumerable<CosmosDocument>> GetAllAsync()
        {
            return await _cosmosStore.Query().ToListAsync();
        }

        public async Task<CosmosDocument> GetByIdAsync(string id)
        {
            return await _cosmosStore.FindAsync(id);
        }

        public async Task<CosmosDocument> AddAsync(CosmosDocument document)
        {
            document.Id = Guid.NewGuid().ToString();
            return await _cosmosStore.AddAsync(document);
        }

        public async Task UpdateAsync(CosmosDocument document)
        {
            await _cosmosStore.UpdateAsync(document);
        }

        public async Task RemoveAsync(CosmosDocument document)
        {
            await _cosmosStore.RemoveAsync(document);
        }

    }
}
