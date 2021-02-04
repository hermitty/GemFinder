using GemFinder.Utils.CQRS.Commands;
using System;

namespace GemFinder.Services.Stores.Application.Commands
{
    public class DeleteStore : ICommand
    {
        public Guid Id { get; set; }
    }
}
