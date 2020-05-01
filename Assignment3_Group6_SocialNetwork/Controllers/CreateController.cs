using System;
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
        private IUserService _userService;
        public CreateController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult PublishPost(string userId)
        {
            var post = new Post();
            post.AuthorId = userId;
            var user = _userService.Get(userId);

            var circles = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Public", "Public")
            };

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
        public IActionResult PublishPost(Post post)
        {
            var user = _userService.Get(post.AuthorId);
            post.IsPublic = post.CircleId == "Public";
            post.CreationTime = DateTime.Now;
            

            user.Posts.Add(post);
            
            _userService.Update(user.Id, user);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateComment(string postAutherId, string postId, string commentAuthorId)
        {
            var comment = new Comment();
            var vm = new CommentViewModel()
            {
                Comment = comment,
                CommentAuthorId = commentAuthorId,
                PostAuthorId = postAutherId,
                PostId = postId
            };

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateComment(CommentViewModel vm)
        {
            var postUser = _userService.Get(vm.PostAuthorId);
            var commentUser = _userService.Get(vm.CommentAuthorId);
            var post = postUser.Posts.Find(p => p.Id == vm.PostId);

            vm.Comment.AuthorId = commentUser.Id;
            vm.Comment.AuthorName = commentUser.UserName;
            vm.Comment.CreationTime = DateTime.Now;

            post.Comments.Add(vm.Comment);

            _userService.Update(postUser.Id, postUser);

            return RedirectToAction(nameof(Index));
        }

    }
}