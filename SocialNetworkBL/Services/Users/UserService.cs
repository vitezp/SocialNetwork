using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetworkBL.QueryObjects.Common;

namespace SocialNetworkBL.Services.Users
{
    public class UserService : CrudQueryServiceBase<User, UserDto, UserFilterDto>, IUserService
    {
        public UserService(IMapper mapper, IRepository<User> repository, QueryObjectBase<UserDto, User, UserFilterDto, IQuery<User>> query)
            : base(mapper, repository, query) { }

        public async Task<IEnumerable<UserDto>> GetUsersContainingSubNameAsync(string subName)
        {
            var queryResult = await Query.ExecuteQuery(new UserFilterDto { SubName = subName });
            return queryResult?.Items;
        }
    }
}
