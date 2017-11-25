﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.Messages
{
    public class MessageService : CrudQueryServiceBase<Message, MessageDto, MessageFilterDto>, IMessageService
    {
        protected MessageService(IMapper mapper, IRepository<Message> repository,
            QueryObjectBase<MessageDto, Message, MessageFilterDto, IQuery<Message>> query)
            : base(mapper, repository, query)
        {
        }

        public async Task<IList<MessageDto>> GetMessagesByFriendshipIdAsync(int friendshipId)
        {
            var queryResult = await Query.ExecuteQuery(new MessageFilterDto {FriendshipId = friendshipId});
            return queryResult?.Items.ToList();
        }
    }
}