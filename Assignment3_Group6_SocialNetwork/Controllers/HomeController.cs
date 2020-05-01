using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment3_Group6_SocialNetwork.Models;
using Assignment3_Group6_SocialNetwork.Services;

namespace Assignment3_Group6_SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        private ICreateService _createService;

        public HomeController(IUserService userService, ICreateService createService)
        {
            _userService = userService;
            _createService = createService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // SEEDING:

        public IActionResult PopulateDatabase()
        {
            //Deleting everything in database before populating the database
            
            /***************************************************************/
            var users = DbSeeder.GetUsers();

            foreach (var user in users)
            {
                var createdUser = _userService.Create(user);

                var posts = DbSeeder.GetPosts(createdUser.UserName, createdUser.Id);

                foreach (var post in posts)
                {
                    _createService.CreatePost(createdUser.Id, post.Content, post.Type, post.CircleId)
                }

                _createService.CreatePost(createdUser.Id, "Hej", "text", "Public")


                //_createService.CreatePost(user.Id, )
            }

            return View("Index");
        }

        public IActionResult ClearDatabase()
        {
            
            return View("Index");
        }
    }
}
