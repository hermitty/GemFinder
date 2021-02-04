using GemFinder.Utils.CQRS.Commands;
using System.Collections.Generic;

namespace GemFinder.Services.Stones.Application.Commands
{
    public class AddImagesToStone : ICommand
    {
        public string Label { get; set; }
        public IList<string> ImageNames { get; set; }
    }
}
