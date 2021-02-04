using GemFinder.Services.Stores.Application.DTO;
using GemFinder.Utils.CQRS.Queries;
using System;
using System.Collections.Generic;

namespace GemFinder.Services.Stores.Application.Queries
{
    public class GetStoresByCriteria : IQuery<IEnumerable<StoreShortDTO>>
    {
        public Guid StoneId { get; set; }

    }
}
