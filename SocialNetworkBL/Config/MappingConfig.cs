using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.Common;
using Infrastructure.Query;
using SocialNetworkBL.DataTransferObjects;

namespace SocialNetworkBL.Config
{
    public class MappingConfig
    {
        public static void ConfigureMapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<Friendship, FriendshipDto>().ReverseMap();
            config.CreateMap<QueryResult<Friendship>, QueryResultDto<FriendshipDto, FriendshipFilterDto>>();

            config.CreateMap<User, UserDto>().ReverseMap();
            config.CreateMap<QueryResult<User>, QueryResultDto<UserDto, UserFilterDto>>();

            config.CreateMap<Message, MessageDto>().ReverseMap();
            config.CreateMap<QueryResult<Message>, QueryResultDto<MessageDto, MessageFilterDto>>();

            config.CreateMap<Comment, CommentDto>().ReverseMap();
            config.CreateMap<QueryResult<Comment>, QueryResultDto<CommentDto, CommentFilterDto>>();

            config.CreateMap<Group, GroupDto>().ReverseMap();
            config.CreateMap<QueryResult<Group>, QueryResultDto<GroupDto, GroupFilterDto>>();

            config.CreateMap<GroupUser, GroupUserDto>().ReverseMap();
            config.CreateMap<QueryResult<GroupUser>, QueryResultDto<GroupUserDto, GroupUserFilterDto>>();
        }
    }
}
