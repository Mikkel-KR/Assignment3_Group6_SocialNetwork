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

        public static List<User> GetUsers()
        {
            // Users Ids
            var userIdMikkel = ObjectId.GenerateNewId().ToString();
            var userIdJeppe = ObjectId.GenerateNewId().ToString();
            var userIdMagnus = ObjectId.GenerateNewId().ToString();
            var userIdPoul = ObjectId.GenerateNewId().ToString();

            // Circle Ids
            var circleId1 = ObjectId.GenerateNewId().ToString();
            var circleId2 = ObjectId.GenerateNewId().ToString();
            var circleId3 = ObjectId.GenerateNewId().ToString();
            var circleId4 = ObjectId.GenerateNewId().ToString();

            return new List<User>()
            {
                /**********************/
                /**** USER: MIKKEL ****/
                /**********************/
                new User()
                {
                    Id = userIdMikkel,

                    // User Information
                    UserName = "Mikkel",
                    Gender = "male",
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

                /*********************/
                /**** USER: JEPPE ****/
                /*********************/
                new User()
                {
                    Id = userIdJeppe,

                    // User Information
                    UserName = "Jeppe",
                    Gender = "male",
                    Age = 24,

                    // Owned Circles
                    Circles = new List<Circle>()
                    {
                        new Circle()
                        {
                            Id = circleId2,
                            CircleName = "PersonalCircle",
                            MemberIds = new List<string>() {userIdPoul}
                        }
                    },

                    BlockedUserIds = new List<string>() { },
                    FollowingUserIds = new List<string>() { userIdMikkel, userIdMagnus, userIdPoul },

                    Posts = new List<Post>()
                    {
                        new Post()
                        {
                            Id = ObjectId.GenerateNewId().ToString(),
                            AuthorId = userIdJeppe,
                            AuthorName = "Jeppe",
                            IsPublic = true,
                            Type = "Image",
                            Content = "https://miro.medium.com/max/1400/1*mk1-6aYaf_Bes1E3Imhc0A.jpeg", //Image of baby-yoda
                            CreationTime = DateTime.Now.AddDays(2),

                            Comments = new List<Comment>()
                            {
                                new Comment()
                                {
                                    AuthorId = userIdMikkel,
                                    AuthorName = "Mikkel",
                                    Content = "Nice picture!",
                                    CreationTime = DateTime.Now.AddDays(2).AddHours(1).AddMinutes(21),
                                }
                            }
                        },

                        new Post()
                        {
                            Id = ObjectId.GenerateNewId().ToString(),
                            AuthorId = userIdJeppe,
                            AuthorName = "Jeppe",
                            IsPublic = false,
                            CircleId = circleId2,
                            Type = "Text",
                            Content = "Hey, what are you doing right now?",
                            CreationTime = DateTime.Now.AddMinutes(35),

                            Comments = new List<Comment>()
                            {
                                new Comment()
                                {
                                    AuthorId = userIdPoul,
                                    AuthorName = "Poul",
                                    Content = "Im doing fine, you wanna take a walk soon?",
                                    CreationTime = DateTime.Now.AddHours(1).AddMinutes(2),
                                },
                                new Comment()
                                {
                                    AuthorId = userIdJeppe,
                                    AuthorName = "Jeppe",
                                    Content = "Nah, maybe later...",
                                    CreationTime = DateTime.Now.AddHours(1).AddMinutes(15),
                                }
                            }
                        }
                    }
                },
                /**********************/
                /**** USER: MAGNUS ****/
                /**********************/
                new User()
                {
                    Id = userIdMagnus,

                    // User Information
                    UserName = "Magnus",
                    Gender = "male",
                    Age = 22,

                    // Owned Circles
                    Circles = new List<Circle>()
                    {
                        new Circle()
                        {
                            Id = circleId3,
                            CircleName = "CircleWithJeppe",
                            MemberIds = new List<string>() {userIdJeppe}
                        },
                        new Circle()
                        {
                            Id = circleId4,
                            CircleName = "CircleWithMikkel",
                            MemberIds = new List<string>() {userIdMikkel}
                        }
                    },

                    BlockedUserIds = new List<string>() { },
                    FollowingUserIds = new List<string>() { userIdJeppe, userIdMagnus, userIdPoul },

                    Posts = new List<Post>()
                    {
                        new Post()
                        {
                            Id = ObjectId.GenerateNewId().ToString(),
                            AuthorId = userIdMagnus,
                            AuthorName = "Magnus",
                            IsPublic = false,
                            CircleId = circleId3,
                            Type = "Image",
                            Content = "https://media.wired.com/photos/598e35994ab8482c0d6946e0/master/w_2560%2Cc_limit/phonepicutres-TA.jpg", //Image of guy on mountain
                            CreationTime = DateTime.Now.AddDays(1),

                            Comments = new List<Comment>()
                            {
                                new Comment()
                                {
                                    AuthorId = userIdJeppe,
                                    AuthorName = "Jeppe",
                                    Content = "I like it! Wauw!",
                                    CreationTime = DateTime.Now.AddDays(1).AddHours(12).AddMinutes(45),
                                }
                            }
                        },

                        new Post()
                        {
                            Id = ObjectId.GenerateNewId().ToString(),
                            AuthorId = userIdMagnus,
                            AuthorName = "Magnus",
                            IsPublic = false,
                            CircleId = circleId4,
                            Type = "Text",
                            Content = "Whatssss up!!!???",
                            CreationTime = DateTime.Now.AddMinutes(2),

                            Comments = new List<Comment>()
                            {
                                new Comment()
                                {
                                    AuthorId = userIdMikkel,
                                    AuthorName = "Mikkel",
                                    Content = "Whaszaaaaa!",
                                    CreationTime = DateTime.Now.AddMinutes(5),
                                },
                            }
                        }
                    }

                },

                /********************/
                /**** USER: POUL ****/
                /********************/
                new User()
                {
                    Id = userIdPoul,

                    // User Information
                    UserName = "Poul",
                    Gender = "male",
                    Age = 29,

                    // Owned Circles
                    Circles = new List<Circle>() {},

                    BlockedUserIds = new List<string>() { },
                    FollowingUserIds = new List<string>() { userIdMikkel, userIdJeppe, userIdMagnus },

                    Posts = new List<Post>()
                    {
                        new Post()
                        {
                            Id = ObjectId.GenerateNewId().ToString(),
                            AuthorId = userIdPoul,
                            AuthorName = "Poul",
                            IsPublic = true,
                            Type = "Text",
                            Content = "Hello followers, any ideas for what to do in Aarhus??",
                            CreationTime = DateTime.Now.AddHours(5),

                            Comments = new List<Comment>()
                            {
                                new Comment()
                                {
                                    AuthorId = userIdJeppe,
                                    AuthorName = "Jeppe",
                                    Content = "Go to AROS! Its very nice ;-)",
                                    CreationTime = DateTime.Now.AddHours(6).AddMinutes(45),
                                }
                            }
                        },
                        new Post()
                        {
                            Id = ObjectId.GenerateNewId().ToString(),
                            AuthorId = userIdPoul,
                            AuthorName = "Poul",
                            IsPublic = true,
                            CircleId = circleId4,
                            Type = "Text",
                            Content = "Come on... I need ideas...",
                            CreationTime = DateTime.Now.AddHours(6),

                            Comments = new List<Comment>()
                            {
                                new Comment()
                                {
                                    AuthorId = userIdJeppe,
                                    AuthorName = "Jeppe",
                                    Content = "I just wrote an idea on your previous post dude!",
                                    CreationTime = DateTime.Now.AddHours(6).AddMinutes(51),
                                },
                            }
                        },
                        new Post()
                        {
                            Id = ObjectId.GenerateNewId().ToString(),
                            AuthorId = userIdPoul,
                            AuthorName = "Poul",
                            IsPublic = true,
                            Type = "Image",
                            Content = "https://aimshop.dk/billeder/show/69203-super-mario-bros-mario-bamse-19-cm",
                            CreationTime = DateTime.Now.AddHours(8),

                            Comments = new List<Comment>()
                            {
                                new Comment()
                                {
                                    AuthorId = userIdMagnus,
                                    AuthorName = "Magnus",
                                    Content = "Mario Life!",
                                    CreationTime = DateTime.Now.AddHours(9).AddMinutes(33),
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
