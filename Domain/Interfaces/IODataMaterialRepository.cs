using Domain.Entities;
using System.Linq;

namespace Domain.Interfaces
{
    public interface IODataMaterialRepository
    {
        public IQueryable<Material> GetAll();
    }
}
