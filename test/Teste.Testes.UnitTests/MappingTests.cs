using AutoMapper;
using Teste.Application.MappingProfiles;

namespace Teste.UnitTests
{
    public class MappingTests
    {
        [Fact]
        public void AutoMapper_Configuracao_Valida()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApplicationMappingProfile>());
            config.AssertConfigurationIsValid();
        }
    }
}
