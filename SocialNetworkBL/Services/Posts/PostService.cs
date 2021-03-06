﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.Services.Common;
using SocialNetworkDAL.Entities;

namespace SocialNetworkBL.Services.Posts
{
    public class PostService : CrudQueryServiceBase<Post, PostDto, PostFilterDto>, IPostService
    {
        public PostService(IMapper mapper, IRepository<Post> repository,
            QueryObjectBase<PostDto, Post, PostFilterDto, IQuery<Post>> query)
            : base(mapper, repository, query)
        {
        }

        public async Task<IList<PostDto>> GetPostsByGroupIdAsync(int groupId)
        {
            var queryResult = await Query.ExecuteQuery(new PostFilterDto
            {
                GroupId = groupId,
                UserId = null,
                SortAscending = false,
                SortCriteria = nameof(Post.PostedAt)
            });
            return queryResult?.Items.ToList();
        }

        public async Task<QueryResultDto<PostDto, PostFilterDto>> GetPostsAsync(PostFilterDto filter)
        {
            filter.SortCriteria = nameof(Post.PostedAt);
            filter.SortAscending = false;
            return await Query.ExecuteQuery(filter);
        }

        public async Task<IList<PostDto>> GetPostsByUserIdAsync(int userId)
        {
            var queryResult = await Query.ExecuteQuery(new PostFilterDto
            {
                UserId = userId,
                GroupId = null,
                SortAscending = false,
                SortCriteria = nameof(Post.PostedAt)
            });
            return queryResult?.Items.ToList();
        }
    }
}