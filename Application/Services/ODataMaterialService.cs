using Application.Interfaces;
using Application.Materials.Query.GetDetail;
using AutoMapper;
using Domain.Interfaces;
using System.Linq;

namespace Application.Services
{
    public class ODataMaterialService : IODataMaterialService
    {
        private readonly IODataMaterialRepository _oDataMaterialRepository;
        private readonly IMapper _mapper;
        public ODataMaterialService(IODataMaterialRepository oDataMaterialRepository, IMapper mapper)
        {
            _oDataMaterialRepository = oDataMaterialRepository;
            _mapper = mapper;
        }

        public IQueryable<GetMaterialsDto> GetAllMaterials()
        {
            var materials = _oDataMaterialRepository.GetAll();
            
            return _mapper.ProjectTo<GetMaterialsDto>(materials);
        }
    }
}
