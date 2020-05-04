using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;
using MongoDB.Driver;

namespace Assignment3_Group6_SocialNetwork.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(ISocialNetworkDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public List<User> GetAll() => 
            _users.Find(user => true).ToList();

        public List<User> GetAll(Expression<Func<User, bool>> filter) =>
            _users.Find(filter).ToList();

        public User Get(string id) =>
            _users.Find(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public List<User> CreateRange(List<User> users)
        {
            _users.InsertMany(users);
            return users;
        }

        public void Update(string id, User userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(User userIn) =>
            _users.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
            _users.DeleteOne(user => user.Id == id);

        public void RemoveRange(List<User> usersIn)
        {
            var usersInIds = usersIn.Select(u => u.Id);
            _users.DeleteMany(user => usersInIds.Contains(user.Id));
        }

        public void RemoveRange(List<string> userIds)
        {
            _users.DeleteMany(user => userIds.Contains(user.Id));
        }
    }
}
