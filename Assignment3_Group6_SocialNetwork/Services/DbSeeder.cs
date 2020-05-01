using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;

namespace Assignment3_Group6_SocialNetwork.Services
{
    public class DbSeeder
    {
        public static List<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    UserName = "Anton",
                    Gender = 'm',
                    Age = 26,
                }
            };
        }

        public static List<Post> GetPostsAnton(string antonId)
        {
            return new List<Post>()
            {
                new Post()
                {
                    AuthorName = "Anton",

                }
            };
        }

        public static List<Post> GetPostsJens()
        {
            return new System.Collections.Generic.List<Post>();
        }

        public static List<Circle> GetCirclesAnton()
        {
            return new System.Collections.Generic.List<Circle>();
        }


    }
}
