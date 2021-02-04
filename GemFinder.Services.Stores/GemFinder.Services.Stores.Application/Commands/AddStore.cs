using GemFinder.Utils.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.Services.Stores.Application.Commands
{
    public class AddStore : ICommand
    {
        public string Name { get; set; }
        public Guid Owner { get; set; }
        public List<string> References { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public List<Guid> Stones { get; set; }
    }
}
