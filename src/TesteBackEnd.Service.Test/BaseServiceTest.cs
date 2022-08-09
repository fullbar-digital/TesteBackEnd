using AutoMapper;
using TesteBackEnd.Infrastructure.CrossCutting.Mappings;

namespace TesteBackEnd.Service.Test
{
    public abstract class BaseServiceTest
    {
        public IMapper Mapper { get; set; }

        public BaseServiceTest()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }

        public class AutoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var config = new MapperConfiguration(
                    cfg =>
                    {
                        cfg.AddProfile(new ModelToEntityProfile());
                        cfg.AddProfile(new DtoToModelProfile());
                        cfg.AddProfile(new EntityToDtoProfile());
                    }
                );
                return config.CreateMapper();
            }
            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }

}
