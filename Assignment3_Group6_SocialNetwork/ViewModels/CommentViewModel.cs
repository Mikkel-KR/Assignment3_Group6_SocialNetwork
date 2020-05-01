using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;

namespace Assignment3_Group6_SocialNetwork.ViewModels
{
    public class CommentViewModel
    {
        public string CommentAuthorId { get; set; }
        public string PostId { get; set; }
        public string PostAuthorId { get; set; }
        public string Comment { get; set; }
    }
}
