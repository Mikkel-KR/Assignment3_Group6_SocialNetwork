using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;

namespace Assignment3_Group6_SocialNetwork.Services
{
    public class QueryService : IQueryService
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

            var followingUsers = _userService.GetAll(user => thisUser.FollowingUserIds.Contains(user.Id));

            var circleIds = thisUser.Circles.Select(circle => circle.Id).ToList();

            foreach(var followingUser in followingUsers)
            {
                //Add Posts
                feedPosts.AddRange(followingUser.Posts.Where(post => post.CircleId.ToLower() == "public" || circleIds.Contains(post.CircleId)));
            }

            return feedPosts.OrderByDescending(post => post.CreationTime).ToList();
        }

        public List<Post> GetWall(string ownerId, string guestId)
        {
            List<Post> wallPosts = new List<Post>();

            var owner = _userService.Get(ownerId);

            if (ownerId == guestId)
                return owner.Posts;

            var guest = _userService.Get(guestId);
            var guestCircleIds = guest.Circles.Select(circle => circle.Id).ToList();

            return owner.Posts.Where(post => post.CircleId.ToLower() == "public" || guestCircleIds.Contains(post.CircleId))
                .OrderByDescending(post => post.CreationTime).ToList();

        }
    }
}
