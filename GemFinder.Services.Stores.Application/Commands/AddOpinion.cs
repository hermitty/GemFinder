using GemFinder.Services.Stores.Application.DTO;
using GemFinder.Utils.CQRS.Commands;
using System;

namespace GemFinder.Services.Stores.Application.Commands
{
    public class AddOpinion : ICommand
    {
        public Guid StoreId { get; set; }
        public NewOpinionDTO Opinion { get; set; }
    }
}
