using System;
using System.Threading.Tasks;
using GemFinder.Identity.Command;
using GemFinder.Identity.DTO;

namespace GemFinder.Identity.Service
{
    public interface IIdentityService
    {
        Task<UserDto> GetUser(Guid id);
        Task<AuthDto> SignIn(SignIn command);
        Task SignUp(SignUp command);
    }
}