﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.UserProfileDtos;
using SocialNetworkBL.Facades;
using SocialNetworkDAL.Entities;
using SocialNetworkPL.Models;

namespace SocialNetworkPL.Controllers
{
    public class HomeController : Controller
    {
        //zatim - dalsi commenty a posty se zobrazovat nebudou
        public const int Posts = 3;
        public const int Comments = 50;

        private const string PostFilterSessionKey = "homePostFilter";
        private const string CommentFilterSessionKey = "homeCommentFilter";

        //Nestiham prepsat aby vyuzival jednu fasadu
        public PostGenericFacade PostGenericFacade { get; set; }
        public UserGenericFacade UserGenericFacade { get; set; }
        public CommentGenericFacade CommentGenericFacade { get; set; }

        public BasicUserFacade BasicUserFacade { get; set; }
        public UserProfileFacade UserProfileFacade { get; set; }

        // GET: Posts
        public async Task<ActionResult> Index(PostFilterDto postFilter)
        {
            //defaultni hodnota pagesize je 50 - zvysuje se po lichych cislech, takze je to v poho (y)
            if (postFilter.PageSize == 50)
            {
                postFilter = new PostFilterDto()
                {
                    SortCriteria = nameof(Post.PostedAt),
                    PageSize = Posts
                };
            }

            //priprava na pagination
            Session[PostFilterSessionKey] = postFilter;
            var commentFilter = Session[CommentFilterSessionKey] as CommentFilterDto ?? new CommentFilterDto() { PageSize = Comments};

            var posts = await UserProfileFacade.GetPostsWithUsersNicknamesAndCommentsByFilters(postFilter, commentFilter);

            BasicUserDto userWithFriends = null;
            if (Request.IsAuthenticated)
            {
                var user = await BasicUserFacade.GetUserByNickNameAsync(User.Identity.Name);
                userWithFriends = await BasicUserFacade.GetBasicUserWithFriends(user.Id);
            }

            return View("Index", new PostListModel()
            {
                PostFilter = postFilter,
                AuthenticatedUser = userWithFriends,
                Posts = posts
            });
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Index(UserProfileModel model)
        {
            model.PostFilter.PageSize += 3;

            return RedirectToAction("Index", model.PostFilter);
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> AddComment(PostListModel model)
        {
            try
            {
                var newComment = new CommentDto()
                {
                    Text = model.NewCommentText,
                    PostedAt = DateTime.Now.ToUniversalTime(),
                    StayAnonymous = model.StayAnonymous,
                    UserId = model.AuthenticatedUser.Id,
                    PostId = model.PostId
                };

                await CommentGenericFacade.CreateAsync(newComment);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


        //Pripravene akce - uzivatel je vsak zatim nedokaze spustit
        //----------------------------------------------------------

        // GET: Posts/UserProfile/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await PostGenericFacade.GetAsync(id);
            return View("PostDetailView", model);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Create(PostDto post)
        {
            try
            {
                await PostGenericFacade.CreateAsync(post);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Posts/Edit/5
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Edit(int id, PostDto post)
        {
            try
            {
                await PostGenericFacade.UpdateAsync(post);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Posts/Delete/5
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> DeletePost(int id)
        {
            try
            {
                await PostGenericFacade.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}