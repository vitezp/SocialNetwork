﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades;
using SocialNetworkPL.Models;

namespace SocialNetworkPL.Controllers
{
    public class UsersController : Controller
    {
        public UserFacade UserFacade { get; set; }
        public PostFacade PostFacade { get; set; }
        public CommentFacade CommentFacade { get; set; }
        public FriendshipFacade FriendshipFacade { get; set; }
        public GroupFacade GroupFacade { get; set; }

        public async Task<ActionResult> Index([FromUri] string subname)
        {
            var filter = new UserFilterDto {SubName = subname};

            var users = await UserFacade.GetUsersContainingSubNameAsync(filter.SubName);
            var model = InitializeProductListViewModel(filter, users);

            return View("FindUsersView", model);
        }

        private FindUsersModel InitializeProductListViewModel(UserFilterDto filter, IEnumerable<UserDto> users)
        {
            return new FindUsersModel
            {
                Filter = filter,
                Users = new HashSet<UserDto>(users)
            };
        }

        // GET: Users/UserProfile/5
        public async Task<ActionResult> UserProfile(string nickName = "")
        {
            UserDto user;
            List<PostDto> posts;
            List<UserDto> friendships;

            if (nickName != "")
            {
                try
                {
                    user = await UserFacade.GetUserByNickNameAsync(nickName);
                    posts = await PostFacade.GetPostsByUserIdAsync(user.Id) as List<PostDto>;
                    friendships = await FriendshipFacade.GetFriendsByUserIdAsync(user.Id) as List<UserDto>;
                }
                catch
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }

            return View("UserProfile", new UserProfileModel
            {
                UserDto = user,
                PostDtos = posts,
                FriendshipDtos = friendships
            });
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Create(UserDto user)
        {
            try
            {
                await UserFacade.CreateAsync(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Edit(int id, UserDto user)
        {
            try
            {
                await UserFacade.UpdateAsync(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await UserFacade.DeleteAsync(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AddPost()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> AddPost(UserProfileModel model)
        {
            try
            {
                var newPost = new PostDto
                {
                    Text = model.NewPostText,
                    UserId = model.UserDto.Id,
                    PostedAt = DateTime.Now
                };

                await PostFacade.CreateAsync(newPost);
                return RedirectToAction("UserProfile", new {nickName = model.UserDto.NickName});
            }
            catch
            {
                return RedirectToAction("UserProfile", new { nickName = model.UserDto.NickName });
            }
        }
    }
}