using AutoMapper;

namespace SocialNetworkBL.Services.Common
{
    public class ServiceBase
    {
        protected readonly IMapper Mapper;

        protected ServiceBase(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
