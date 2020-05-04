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
        private ICreateService _createService;
        private IUserService _userService;
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

            var circles = new List<KeyValuePair<string, string>>();

            foreach (var circle in user.Circles)
            {
                circles.Add(new KeyValuePair<string, string>(
                    circle.Id,
                    circle.CircleName
                    ));
            }

            var vm = new PostViewModel()
            {
                Circles = new SelectList(circles),
                Post = post,
                UserName = user.UserName
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PublishPost(PostViewModel postVm)
        {
            var post = postVm.Post;

            var result = _createService.CreatePost(post.AuthorId, post.Content, post.Type, post.CircleId, post.IsPublic);

            if (!result)
                return View(postVm);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateComment(string postAuthorId, string postId, string commentAuthorId, string queryType)
        {
           var vm = new CommentViewModel()
            {
                CommentAuthorId = commentAuthorId,
                PostAuthorId = postAuthorId,
                PostId = postId,
                QueryType = queryType
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

            if(vm.QueryType == "Feed")
                return RedirectToAction(controllerName: "Query", actionName: vm.QueryType, routeValues: vm.PostAuthorId);
            else if (vm.QueryType == "Wall")
                return RedirectToAction(controllerName: "Query", actionName: "Wall", routeValues: vm.PostAuthorId);
            else
                return View();
        }
    }
}