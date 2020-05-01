using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_Group6_SocialNetwork.Services
{
    public interface ICreateService
    {
        bool CreateComment(string postAuthorId, string postId, string commentAuthorId, string comment);

        bool CreatePost(string ownerId, string content, string contentType, string circleId);
    }
}
