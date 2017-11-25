using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.Services.Messages
{
    public interface IMessageService : IService<MessageDto, MessageFilterDto>
    {
        Task<IList<MessageDto>> GetMessagesByFriendshipIdAsync(int friendshipId);
    }
}
