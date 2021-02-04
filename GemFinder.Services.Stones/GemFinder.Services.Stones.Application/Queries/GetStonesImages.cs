using GemFinder.Services.Stones.Application.DTO;
using GemFinder.Utils.CQRS.Queries;
using System.Collections.Generic;

namespace GemFinder.Services.Stones.Application.Queries
{
    public class GetStonesImages : IQuery<IEnumerable<StoneImageDTO>>
    {
    }
}
