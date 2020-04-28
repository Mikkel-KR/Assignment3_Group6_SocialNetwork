using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;

namespace Assignment3_Group6_SocialNetwork.Services
{
    public class QueryService
    {
        private readonly IUserService _userService;

        public QueryService(IUserService userService)
        {
            _userService = userService;
        }

        public List<Post> GetFeed(string loggedInUserId)
        {
            List<Post> feedPosts = new List<Post>();

            var thisUser = _userService.Get(loggedInUserId);
            feedPosts.AddRange(thisUser.Posts);

            //var followingUserIds = thisUser.FollowingUserIds;
            //List<User> followingUsers = new List<User>();
            //foreach (var followingUserId in followingUserIds)
            //{
            //    followingUsers.Add(_userService.Get(followingUserId));
            //}

            var followingUsers = _userService.GetAll().FindAll(user => thisUser.FollowingUserIds.Contains(user.Id));

            var circleIds = thisUser.Circles.Select(circle => circle.Id).ToList();

            //var relevantPosts = followingUsers.Select(user => user.Posts).Where(posts =>
            //    posts.Where(post => post.IsPublic || circleIds.Contains(post.CircleId)));

            //var relevantPosts = followingUsers.Select(user => user.Posts).Where(user =>
            //    user.Posts.Where(post => (post.IsPublic || circleIds.Contains(post.CircleId)))).Select(user => user.Posts);

            return feedPosts;
        }

        public List<Post> GetWall(string ownerId, string guestId)
        {

        }
    }
}
