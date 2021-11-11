using AutoMapper;
using HouseProject.Application.Mappings;

namespace UnitTests.Handlers.Helpers
{
    public class MapperExtension
    {
        public static IMapper CreateInstance()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            return mappingConfig.CreateMapper();
        }
    }
}
