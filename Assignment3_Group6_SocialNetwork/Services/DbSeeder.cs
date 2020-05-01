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
                    UserName = "Mikkel",
                    Gender = 'm',
                    Age = 24,
                },
                new User()
                {
                    UserName = "Jeppe",
                    Gender = 'm',
                    Age = 24
                },
                new User()
                {
                    UserName = "Magnus",
                    Gender = 'm',
                    Age = 22
                }
            };
        }

        public static List<Post> GetPosts(string userName, string id)
        {
            switch (userName)
            {
                case "Mikkel":
                {
                    return GetPostsMikkel(id);
                }
                case "Jeppe":
                {
                    return GetPostsJeppe(id);
                }
                case "Magnus":
                {
                    return GetPostsMagnus(id);
                }
                default:
                {
                    return new System.Collections.Generic.List<Post>();
                }
            }
        }

        private static List<Post> GetPostsMikkel(string userId)
        {
            return new List<Post>()
            {
                new Post()
                {
                    AuthorName = "Anton",

                }
            };
        }

        public static List<Post> GetPostsJeppe(string userId)
        {
            return new System.Collections.Generic.List<Post>();
        }

        public static List<Post> GetPostsMagnus(string userId)
        {
            return new System.Collections.Generic.List<Post>();
        }

        public static List<Circle> GetCirclesAnton()
        {
            return new System.Collections.Generic.List<Circle>();
        }


    }
}
