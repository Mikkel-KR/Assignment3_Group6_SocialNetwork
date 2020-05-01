using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;

namespace Assignment3_Group6_SocialNetwork.Services
{
    public interface IQueryService
    {
        List<Post> GetFeed(string loggedInUserId);

        List<Post> GetWall(string ownerId, string guestId);
    }
}
