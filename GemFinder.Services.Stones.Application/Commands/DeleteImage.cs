using GemFinder.Utils.CQRS.Commands;

namespace GemFinder.Services.Stones.Application.Commands
{
    public class DeleteImage : ICommand
    {
        public string StoneName { get; set; }
    }
}
