using System.Threading.Tasks;
using Convey.CQRS.Commands;
using GemFinder.Identity.Service;

namespace GemFinder.Identity.Command.Handler
{
    internal sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IIdentityService _identityService;

        public SignUpHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public Task HandleAsync(SignUp command) => _identityService.SignUp(command);
    }
}