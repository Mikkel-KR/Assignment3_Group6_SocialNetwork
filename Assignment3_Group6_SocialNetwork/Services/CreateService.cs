﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;

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
                CreationTime = DateTime.Now
            };

            var post = user.Posts.Find(p => p.Id == postId);

            if (post == null)
                return false;

            post.Comments.Add(newComment);
            
            _userService.Update(user.Id,user);

            return true;
        }

        public bool CreatePost(string ownerId, string content, string contentType, string circleId, bool isPublic)
        {
            var user = _userService.Get(ownerId);

            // User doesn't exist or the post is private and the user doesn't have the circle
            if(user == null || (!isPublic && !user.Circles.Select(s=>s.Id).Contains(circleId)))
                return false;

            var post = new Post()
            {
                AuthorId = user.Id,
                AuthorName = user.UserName,
                CircleId = circleId,
                Comments = new List<Comment>(),
                Content = content,
                CreationTime = DateTime.Now,
                Type = contentType,
                IsPublic = isPublic,
                Id = ObjectId.GenerateNewId().ToString()
            };
            user.Posts.Add(post);
            _userService.Update(user.Id, user);
            return true;
        }

        public bool CreateCircle(string ownerId, string circleName, List<string> usersToAddToCircle)
        {
            var user = _userService.Get(ownerId);
            
            if (user == null)
                return false;

            user.Circles.Add(new Circle()
            {
                CircleName = circleName,
                MemberIds = usersToAddToCircle,
                Id = ObjectId.GenerateNewId().ToString()
            });

            _userService.Update(ownerId, user);
            
            return true;
        }
    }
}
