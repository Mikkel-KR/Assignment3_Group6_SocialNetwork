using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment3_Group6_SocialNetwork.ViewModels
{
    public class PostTypes
    {
        public static SelectList GetPostTypes()
        {
            return new SelectList(new List<string>()
            {
                "Text",
                "Image"
            });
        }
    }
}
