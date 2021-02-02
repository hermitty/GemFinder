using GemFinder.Services.Stores.Application.DTO;
using GemFinder.Utils.CQRS.Queries;
using System.Collections.Generic;

namespace GemFinder.Services.Stores.Application.Queries
{
    public class GetStores : IQuery<IEnumerable<StoreShortDTO>>
    {
    }
}
