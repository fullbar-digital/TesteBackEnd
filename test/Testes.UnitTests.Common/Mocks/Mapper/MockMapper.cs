using AutoMapper;
using Teste.Application.MappingProfiles;

namespace Testes.UnitTests.Common.Mocks.Mapper
{
    public class MockMapper
    {

        public IMapper Mapper
        {
            get
            {
                var config = new MapperConfiguration(cfg => cfg.AddProfile<ApplicationMappingProfile>());
                return config.CreateMapper();
            }
        }
    }
}
