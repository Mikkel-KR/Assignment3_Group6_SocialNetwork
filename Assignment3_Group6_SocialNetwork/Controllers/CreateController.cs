﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;
using Assignment3_Group6_SocialNetwork.Services;
using Assignment3_Group6_SocialNetwork.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment3_Group6_SocialNetwork.Controllers
{
    public class CreateController : Controller
    {
        private readonly ICreateService _createService;
        private readonly IUserService _userService;
        public CreateController(IUserService userService, ICreateService createService)
        {
            _userService = userService;
            _createService = createService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult PublishPost(string userId)
        {
            var post = new Post {AuthorId = userId};
            var user = _userService.Get(userId);

            if (user == null)
                return RedirectToAction("Index");

            var circles = new Dictionary<string, string>();

            foreach (var circle in user.Circles)
            {
                circles.Add(circle.Id, circle.CircleName);
            }

            var vm = new PostViewModel()
            {
                Circles = new SelectList(circles.Select(x=>new {Value = x.Key, Text = x.Value}),
                    "Value",
                    "Text"),
                UserName = user.UserName,
                AuthorId = user.Id
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PublishPost(PostViewModel postVm)
        {
            var result = _createService.CreatePost(
                postVm.AuthorId, 
                postVm.PostContent, 
                postVm.PostType, 
                postVm.SelectedCircle, 
                postVm.IsPublic
                );

            if (!result)
                return View(postVm);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateComment(string postAuthorId, string postId, string commentAuthorId, string queryType, string wallOwnerId = "Default")
        {
           var vm = new CommentViewModel()
            {
                CommentAuthorId = commentAuthorId,
                PostAuthorId = postAuthorId,
                PostId = postId,
                QueryType = queryType,
                WallOwnerId = wallOwnerId
            };

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateComment(CommentViewModel vm)
        {
            var result = _createService.CreateComment(vm.PostAuthorId, vm.PostId, vm.CommentAuthorId, vm.Comment);

            if (!result)
                return View();

            // Route back to correct feed/wall (uses QueryType)
            if(vm.QueryType == "Feed")
                return RedirectToAction(controllerName: "Query", actionName: "Feed", 
                    routeValues: new {logged_in_user_id = vm.CommentAuthorId});
            else if (vm.QueryType == "Wall")
                return RedirectToAction(controllerName: "Query", actionName: "Wall", 
                    routeValues: new { user_id = vm.WallOwnerId, guest_id = vm.CommentAuthorId});

            return View();
        }
    }
}