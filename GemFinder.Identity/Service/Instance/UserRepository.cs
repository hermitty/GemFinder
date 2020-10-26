using GemFinder.Identity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GemFinder.Identity.Service.Instance
{
    public class UserRepository : IUserRepository
    {
        private List<User> users;
        public UserRepository()
        {
            users = new List<User>();
            users.Add(new User(new Guid(), "email@email.com", "12345", "admin", DateTime.Now));
        }
        public Task Add(User user)
        {
            users.Add(user);
            return Task.CompletedTask;
        }

        public Task<User> Get(Guid id)
        {
            var result = users.Where(x => x.Id == id).FirstOrDefault();
            return Task.FromResult(result);
        }

        public Task<User> Get(string email)
        {
            var result = users.Where(x => x.Email == email).FirstOrDefault();
            return Task.FromResult(result);
        }
    }
}
