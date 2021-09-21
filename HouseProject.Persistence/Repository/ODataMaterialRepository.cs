using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using System.Linq;

namespace Infrastructure.Repository
{
    public class ODataMaterialRepository : IODataMaterialRepository
    {
        private readonly HouseProjectDbContext _houseProjectDbContext;

        public ODataMaterialRepository(HouseProjectDbContext houseProjectDbContext)
        {
            _houseProjectDbContext = houseProjectDbContext;
        }

        public IQueryable<Material> GetAll()
        {
            return _houseProjectDbContext.Materials.AsQueryable();
        }
    }
}
