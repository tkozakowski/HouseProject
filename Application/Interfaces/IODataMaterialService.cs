using Application.Materials.Query.GetDetail;
using System.Linq;

namespace Application.Interfaces
{
    public interface IODataMaterialService
    {
        public IQueryable<GetMaterialDto> GetAllMaterials();
    }
}
