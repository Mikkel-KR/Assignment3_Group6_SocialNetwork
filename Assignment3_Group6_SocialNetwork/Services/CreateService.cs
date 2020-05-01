using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;

namespace Assignment3_Group6_SocialNetwork.Services
{
    public class CreateService: ICreateService
    {
        private IUserService _userService;
        public CreateService(IUserService userService)
        {
            _userService = userService;
        }

        public bool CreateComment(string postAuthorId, string postId, string commentAuthorId, string comment)
        {
            var user = _userService.Get(postAuthorId);
            var commentUser = _userService.Get(commentAuthorId);

            if (user == null || commentUser == null)
                return false;

            var newComment = new Comment()
            {
                AuthorId = commentUser.Id,
                AuthorName = commentUser.UserName,
                Content = comment,
                CreationTime = DateTime.Now,
            };

            var post = user.Posts.Find(p => p.Id == postId);

            if (post == null)
                return false;

            post.Comments.Add(newComment);
            
            _userService.Update(user.Id,user);

            return true;
        }

        public bool CreatePost(string ownerId, string content,string contentType, string circleId)
        {
            var user = _userService.Get(ownerId);

            if(user == null || !user.Circles.Select(s=>s.Id).Contains(circleId))
                return false;

            var post = new Post()
            {
                AuthorId = user.Id,
                AuthorName = user.UserName,
                CircleId = circleId,
                Comments = new List<Comment>(),
                Content = content,
                CreationTime = DateTime.Now,
                Type = contentType
            };
            user.Posts.Add(post);
            _userService.Update(user.Id, user);
            return true;
        }
    }
}
