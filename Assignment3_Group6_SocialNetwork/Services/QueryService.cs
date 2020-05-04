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

            feedPosts.AddRange(thisUser.Posts); // Add own posts

            //var followingUserIds = thisUser.FollowingUserIds;
            //List<User> followingUsers = new List<User>();
            //foreach (var followingUserId in followingUserIds)
            //{
            //    followingUsers.Add(_userService.Get(followingUserId));
            //}

            // Get all users which loggedInUser follows
            var followingUsers = _userService.GetAll(user => thisUser.FollowingUserIds.Contains(user.Id));

            foreach(var followingUser in followingUsers)
            {
                if (followingUser.BlockedUserIds.Contains(thisUser.Id))
                    continue; //If feed-owner has been blocked from the user he's following --> Jump to next followingUser (Nothing to see)

                // Get all circle-Ids (from followingUser) for which loggedInUser is a member (a part of)
                var circleIds = followingUser.Circles.Where(circle => circle.MemberIds.Contains(thisUser.Id))
                    .Select(circle => circle.Id);

                // Add all posts to feed where loggedInUser has access (via circleIds)
                feedPosts.AddRange(followingUser.Posts.Where(post => post.IsPublic || circleIds.Contains(post.CircleId))); // Add other posts
            }

            return feedPosts.OrderByDescending(post => post.CreationTime).ToList();
        }

        public List<Post> GetWall(string ownerId, string guestId)
        {
            List<Post> wallPosts = new List<Post>();

            var owner = _userService.Get(ownerId);
            var guest = _userService.Get(guestId);

            if (ownerId == guestId)
                return owner.Posts;

            var circleIds = owner.Circles.Where(circle => circle.MemberIds.Contains(guest.Id))
                .Select(circle => circle.Id);

            wallPosts.AddRange(owner.Posts.Where(post => post.IsPublic || circleIds.Contains(post.CircleId)));

            return wallPosts.OrderByDescending(post => post.CreationTime).ToList();

        }
    }
}
