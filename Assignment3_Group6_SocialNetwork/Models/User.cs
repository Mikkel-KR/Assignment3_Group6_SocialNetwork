using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assignment3_Group6_SocialNetwork.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        // UserInformation
        public string UserName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        // List of Circles
        public List<Circle> Circles { get; set; }

        // List of blocked users
        public List<string> BlockedUserIds { get; set; }

        // List of users who's is being followed
        public List<string> FollowingUserIds { get; set; } 

        // List of own Posts (in circles and public)
        public List<Post> Posts { get; set; }

    }
}
