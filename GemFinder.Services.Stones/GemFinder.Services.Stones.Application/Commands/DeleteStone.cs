using GemFinder.Utils.CQRS.Commands;

namespace GemFinder.Services.Stones.Application.Commands
{
    public class DeleteStone : ICommand
    {
        public string Label { get; set; }
    }
}
