using System.Threading.Tasks;

namespace GemFinder.Utils.CQRS.Commands
{
    public interface ICommandDispatcher
    {
        Task SendAsync<T>(T command) where T : class, ICommand;
    }
}
