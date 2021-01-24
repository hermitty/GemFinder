using System.Threading.Tasks;

namespace GemFinder.Utils.CQRS.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        Task HandleAsync(TCommand Command);
    }
}
