using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.Services.Groups
{
    public interface IGroupService : IService<GroupDto, GroupFilterDto>
    {
        Task<IList<GroupDto>> GetGroupsContainingSubNameAsync(string subName);
    }
}
