using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assignment3_Group6_SocialNetwork.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public bool IsPublic { get; set; }
        public string CircleId { get; set; }
        public string AuthorId { get; set; }
        [Display(Name = "Author")]
        public string AuthorName { get; set; }
        public DateTime CreationTime { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
