using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;
using MongoDB.Bson;

namespace Assignment3_Group6_SocialNetwork.Services
{
    public class DbSeeder
    {

        public static List<User> GetUsersNew()
        {
            // Users Ids
            var userIdMikkel = ObjectId.GenerateNewId().ToString();
            var userIdJeppe = ObjectId.GenerateNewId().ToString();
            var userIdMagnus = ObjectId.GenerateNewId().ToString();
            var userIdPoul = ObjectId.GenerateNewId().ToString();

            // Circle Ids
            var circleId1 = ObjectId.GenerateNewId().ToString();
            var circleId2 = ObjectId.GenerateNewId().ToString();

            return new List<User>()
            {
                /**** USER: MIKKEL ****/
                new User()
                {
                    Id = userIdMikkel,

                    // User Information
                    UserName = "Mikkel",
                    Gender = 'm',
                    Age = 24,

                    // Owned Circles
                    Circles = new List<Circle>()
                    {
                        new Circle()
                        {
                            Id = circleId1,
                            CircleName = "TheBois",
                            MemberIds = new List<string>() {userIdJeppe, userIdMagnus}
                        }
                    },

                    BlockedUserIds = new List<string>() { userIdPoul },
                    FollowingUserIds = new List<string>() { userIdJeppe, userIdMagnus },

                    Posts = new List<Post>()
                    {
                        new Post()
                        {
                            Id = ObjectId.GenerateNewId().ToString(),
                            AuthorId = userIdMikkel,
                            AuthorName = "Mikkel",
                            IsPublic = true,
                            Type = "Text",
                            Content = "Hello everybody! Hows it going?",
                            CreationTime = DateTime.Now,

                            Comments = new List<Comment>()
                            {
                                new Comment()
                                {
                                    AuthorId = userIdMagnus,
                                    AuthorName = "Magnus",
                                    Content = "Im doing great! Its a beautiful day today! :)",
                                    CreationTime = DateTime.Now.AddHours(3),
                                }
                            }
                        },

                        new Post()
                        {
                            Id = ObjectId.GenerateNewId().ToString(),
                            AuthorId = userIdMikkel,
                            AuthorName = "Mikkel",
                            IsPublic = false,
                            CircleId = circleId1,
                            Type = "Text",
                            Content = "Hello Bois. When are we going to make the assignment??",
                            CreationTime = DateTime.Now.AddMinutes(30),

                            Comments = new List<Comment>()
                            {
                                new Comment()
                                {
                                    AuthorId = userIdJeppe,
                                    AuthorName = "Jeppe",
                                    Content = "Lets do it tomorrow?",
                                    CreationTime = DateTime.Now.AddHours(2).AddMinutes(23),
                                },
                                new Comment()
                                {
                                    AuthorId = userIdMikkel,
                                    AuthorName = "Mikkel",
                                    Content = "Sure, sounds gucci :)",
                                    CreationTime = DateTime.Now.AddHours(2).AddMinutes(27),
                                }
                            }
                        }
                    }
                },
                new User()
                {
                    Id = userIdMikkel,

                    // User Information
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
                    return GetPostsMikkel(userName, id);
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

        private static List<Post> GetPostsMikkel(string userName, string userId)
        {
            return new List<Post>()
            {
                new Post()
                {
                    AuthorId = userId,
                    AuthorName = userName,



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
