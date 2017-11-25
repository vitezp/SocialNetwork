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

namespace SocialNetworkBL.Services.Groups
{
    public class GroupService : CrudQueryServiceBase<Group, GroupDto, GroupFilterDto>, IGroupService
    {
        protected GroupService(IMapper mapper, IRepository<Group> repository, QueryObjectBase<GroupDto, Group, GroupFilterDto, IQuery<Group>> query)
            : base(mapper, repository, query) { }

        public async Task<IList<GroupDto>> GetGroupsContainingSubNameAsync(string subName)
        {
            var queryResult = await Query.ExecuteQuery(new GroupFilterDto { SubName = subName });
            return queryResult?.Items.ToList();
        }
    }
}
