using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment3_Group6_SocialNetwork.ViewModels
{
    public class PostViewModel
    {
        public string UserName { get; set; }
        public Post Post { get; set; }
        public SelectList Circles { get; set; }
    }
}
