//using Domain.Entities;
//using Domain.Interfaces;
//using Infrastructure.Extensions;
//using Infrastructure.Persistence;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.Repositories
//{
//    public class DocumentRepository : IDocumentRepository
//    {
//        private readonly HouseProjectDbContext _houseProjectContext;

//        public DocumentRepository(HouseProjectDbContext houseProjectContext)
//        {
//            _houseProjectContext = houseProjectContext;
//        }


//        public async Task<IEnumerable<Document>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
//        {
//            List<Document> result = await _houseProjectContext.Documents
//                .Where(x => x.Name.ToLower().Contains(filterBy.ToLower()) || x.Description.ToLower().Contains(filterBy.ToLower()))
//                .OrderByPropertyName(sortField, ascending)
//                .Skip((pageNumber - 1) * pageSize)
//                .Take(pageSize)
//                .ToListAsync();

//            return result;
//        }

//        public async Task<Document> GetByIdAsync(int id)
//            => await _houseProjectContext.Documents.FirstOrDefaultAsync(x => x.Id == id);

//        public async Task<bool> AddAsync(Document document)
//        {
//            await _houseProjectContext.AddAsync(document);

//            return await _houseProjectContext.SaveChangesAsync() > 0;
//        }

//        public async Task RemoveAsync(Document document)
//        {
//            _houseProjectContext.Remove(document);

//            await _houseProjectContext.SaveChangesAsync();

//            await Task.CompletedTask;
//        }

//        public async Task UpdateAsync(Document document)
//        {
//            if (document is null) return;

//            _houseProjectContext.Update(document);

//            await _houseProjectContext.SaveChangesAsync();

//            await Task.CompletedTask;
//        }

//        public int TotalRecords(string filterBy)
//            => _houseProjectContext.Documents.Where(x => x.Name.ToLower().Contains(filterBy.ToLower()) || x.Description.ToLower()
//            .Contains(filterBy.ToLower())).Count();

//    }
//}
