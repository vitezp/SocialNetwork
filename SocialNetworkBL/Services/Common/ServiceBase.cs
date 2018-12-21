﻿using AutoMapper;

namespace SocialNetworkBL.Services.Common
{
    public abstract class ServiceBase
    {
        protected readonly IMapper Mapper;

        protected ServiceBase(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}