﻿using System;
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
        public char Gender { get; set; }
        public int Age { get; set; }

        // List of blocked users
        public List<string> BlockedUsers { get; set; }

        // List of users who's is being followed
        public List<string> FollowingUsers { get; set; }

    }
}
