using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Services;
using Assignment3_Group6_SocialNetwork.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3_Group6_SocialNetwork.Controllers
{
    public class QueryController : Controller
    {
        private readonly IQueryService _queryService;

        public QueryController(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Feed(string logged_in_user)
        {
            var feedPosts = _queryService.GetFeed(logged_in_user);

            var vm = new FeedViewModel(feedPosts);

            return View(vm);
        }

        public IActionResult Wall(string user_id, string guest_id)
        {
            var wallPosts = _queryService.GetWall(user_id, guest_id);

            return View(wallPosts);
        }
    }
}