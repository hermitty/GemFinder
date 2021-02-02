using GemFinder.Identity.Entity;
using GemFinder.Identity.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GemFinder.Tests
{
    public class UserRespoisotryMock : IUserRepository
    {
        private readonly IList<User> users;
        public UserRespoisotryMock()
        {
            users = new List<User>();
        }
        public async Task Add(User user)
        {
            users.Add(user);
        }

        public Task<User> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(string email)
        {
            throw new NotImplementedException();
        }
    }
}
