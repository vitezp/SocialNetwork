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

namespace SocialNetworkBL.Services.Comments
{
    public class CommentService : CrudQueryServiceBase<Comment, CommentDto, CommentFilterDto>, ICommentService
    {
        public CommentService(IMapper mapper, IRepository<Comment> repository,
            QueryObjectBase<CommentDto, Comment, CommentFilterDto, IQuery<Comment>> query)
            : base(mapper, repository, query)
        {
        }

        public async Task<IList<CommentDto>> GetCommentsByPostIdAsync(int postId)
        {
            var queryResult = await Query.ExecuteQuery(new CommentFilterDto {PostId = postId});
            return queryResult?.Items.ToList();
        }

        public async Task<IList<CommentDto>> GetLatestCommentsByPostIdAsync(int postId, int pageSize)
        {
            var queryResult = await Query.ExecuteQuery(new CommentFilterDto
            {
                PostId = postId,
                PageSize = pageSize,
                RequestedPageNumber = 1,
                SortAscending = true
            });
            return queryResult?.Items.ToList();
        }

        public async Task<QueryResultDto<CommentDto, CommentFilterDto>> GetCommentsByFilter(CommentFilterDto filter)
        {
            return await Query.ExecuteQuery(filter);
        }
    }
}