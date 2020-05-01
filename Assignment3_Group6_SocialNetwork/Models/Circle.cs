using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assignment3_Group6_SocialNetwork.Models
{
    public class Circle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CircleName { get; set; }
        public List<string> MemberIds { get; set; }
    }
}
