using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;

namespace Assignment3_Group6_SocialNetwork.ViewModels
{
    public class CommentViewModel
    {
        [Display(Name = "Comment-Author-Id")]
        public string CommentAuthorId { get; set; }
        public string PostId { get; set; }
        public string PostAuthorId { get; set; }
        public string Comment { get; set; }
        public string QueryType { get; set; }
        public string WallOwnerId { get; set; }
    }

    public class QueryInfo
    {
        public string QueryType { get; set; }
        public string OwnerId { get; set; } //Owner of wall/feed
        public string GuestId { get; set; } //Only for wall-query
    }
}
