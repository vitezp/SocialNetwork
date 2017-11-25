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

namespace SocialNetworkBL.Services.Comments
{
    public class CommentService : CrudQueryServiceBase<Comment, CommentDto, CommentFilterDto>, ICommentService
    {
        protected CommentService(IMapper mapper, IRepository<Comment> repository, QueryObjectBase<CommentDto, Comment, CommentFilterDto, IQuery<Comment>> query)
            : base(mapper, repository, query) { }

        public async Task<IList<CommentDto>> GetCommentsByPostIdAsync(int postId)
        {
            var queryResult = await Query.ExecuteQuery(new CommentFilterDto { PostId = postId });
            return queryResult?.Items.ToList();
        }
    }
}
