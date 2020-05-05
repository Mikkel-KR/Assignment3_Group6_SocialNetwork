using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;
using Assignment3_Group6_SocialNetwork.Services;
using Assignment3_Group6_SocialNetwork.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;

namespace Assignment3_Group6_SocialNetwork.Controllers
{
    public class OverviewController : Controller
    {
        private readonly IUserService _userService;

        public OverviewController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View(_userService.GetAll());
        }
    }
}
