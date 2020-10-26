using GemFinder.Identity.Entity;
using System;
using System.Threading.Tasks;

namespace GemFinder.Identity.Service
{
    public interface IUserRepository
    {
        Task<User> Get(Guid id);
        Task<User> Get(string email);
        Task Add(User user);
    }
}