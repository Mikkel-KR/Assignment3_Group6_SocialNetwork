using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;

namespace Assignment3_Group6_SocialNetwork.ViewModels
{
    public class FeedViewModel
    {
        public FeedViewModel(List<Post> feed, User loggedInUser)
        {
            FeedPosts = feed;
            LoggedInUser = loggedInUser;
        }

        public List<Post> FeedPosts { get; set; }
        public User LoggedInUser { get; set; }
    }
}
