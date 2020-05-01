using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Assignment3_Group6_SocialNetwork.Models;

namespace Assignment3_Group6_SocialNetwork.Services
{
    public interface IUserService
    {
        public List<User> GetAll();
        public List<User> GetAll(Expression<Func<User, bool>> filter);
        public User Get(string id);

        public User Create(User user);

        public void Update(string id, User userIn);

        public void Remove(User userIn);

        public void Remove(string id);
    }
}
