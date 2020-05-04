using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;
using Assignment3_Group6_SocialNetwork.Services;
using Assignment3_Group6_SocialNetwork.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3_Group6_SocialNetwork.Controllers
{
    public class QueryController : Controller
    {
        private IUserService _userService;
        private readonly IQueryService _queryService;

        public QueryController(IQueryService queryService, IUserService userService)
        {
            _userService = userService;
            _queryService = queryService;
        }

        // Display query-choices: Feed or Wall
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Feed(string logged_in_user_id)
        {
            // Get logged-in user
            var user = _userService.Get(logged_in_user_id);

            if (user == null)
                return RedirectToAction("Index");

            // Get posts in feed
            var feedPosts = _queryService.GetFeed(logged_in_user_id);

            var vm = new FeedViewModel(feedPosts, user);

            return View(vm);
        }

        public IActionResult Wall(string user_id, string guest_id)
        {
            //// Get Users
            var owner = _userService.Get(user_id);
            var guest = _userService.Get(guest_id);

            if (owner == null || guest == null)
                return RedirectToAction("Index");

            //// Get posts on wall
            var wallPosts = _queryService.GetWall(user_id, guest_id);

            var vm = new WallViewModel(wallPosts, owner, guest);

            return View(vm);
        }
    }
}