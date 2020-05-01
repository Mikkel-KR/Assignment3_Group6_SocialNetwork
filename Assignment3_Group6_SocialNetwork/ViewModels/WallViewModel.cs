using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;

namespace Assignment3_Group6_SocialNetwork.ViewModels
{
    public class WallViewModel
    {
        public WallViewModel(List<Post> wall, User owner, User guest)
        {
            WallPosts = wall;
            OwnerUser = owner;
            GuestUser = guest;
        }

        public List<Post> WallPosts { get; set; }
        public User OwnerUser { get; set; }
        public User GuestUser { get; set; }

    }
}
