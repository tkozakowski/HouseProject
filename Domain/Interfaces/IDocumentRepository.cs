using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDocumentRepository
    {
        public Task<Document> GetByIdAsync(int id);
        public Task<IEnumerable<Document>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
        public Task<bool> AddAsync(Document document);
        public Task RemoveAsync(int id);
        public Task UpdateAsync(Document document);
        public int TotalRecords(string filterBy);
    }
}
