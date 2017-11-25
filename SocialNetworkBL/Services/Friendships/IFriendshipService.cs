using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.Services.Friendships
{
    public interface IFriendshipService : IService<FriendshipDto, FriendshipFilterDto>
    {
        /// <summary>
        /// Gets list of friends
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <returns>list of friends</returns>
        Task<IList<UserDto>> GetFriendsByUserIdAsync(int userId);
    }
}
