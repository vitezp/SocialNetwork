﻿using AutoMapper;
using Infrastructure.Query;
using Infrastructure.Query.Predicates;
using Infrastructure.Query.Predicates.Operators;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkDAL.Entities;

namespace SocialNetworkBL.QueryObjects
{
    public class GetGroupUsersQueryObject : QueryObjectBase<GetGroupUsersDto, GroupUser, GetGroupUsersFilterDto, IQuery<GroupUser>>
    {
        public GetGroupUsersQueryObject(IMapper mapper, IQuery<GroupUser> query) : base(mapper, query)
        {
        }

        protected override IQuery<GroupUser> ApplyWhereClause(IQuery<GroupUser> query, GetGroupUsersFilterDto filter)
        {
            //var simplePredicate = filter.GroupId.Equals(null) ?
            //                            new SimplePredicate(nameof(GroupUser.UserId), ValueComparingOperator.Equal, filter.UserId) :
            //                            new SimplePredicate(nameof(GroupUser.GroupId), ValueComparingOperator.Equal, filter.GroupId);

            //return filter.UserId.Equals(null) && filter.GroupId.Equals(null)
            //    ? query
            //    : query.Where(simplePredicate);

            var simplePredicate =
                new SimplePredicate(nameof(GroupUser.GroupId), ValueComparingOperator.Equal, filter.GroupId);

            return filter.GroupId.Equals(null)
                ? query
                : query.Where(simplePredicate);
        }
    }
}