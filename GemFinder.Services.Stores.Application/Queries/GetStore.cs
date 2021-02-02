using GemFinder.Services.Stores.Application.DTO;
using GemFinder.Utils.CQRS.Queries;
using System;

namespace GemFinder.Services.Stores.Application.Queries
{
    public class GetStore : IQuery<StoreDTO>
    {
        public Guid StoreId { get; set; }
    }
}
