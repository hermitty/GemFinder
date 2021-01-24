using GemFinder.Services.Stones.Application.DTO;
using GemFinder.Utils.CQRS.Queries;

namespace GemFinder.Services.Stones.Application.Queries
{
    public class GetStoneInfo : IQuery<StoneDTO>
    {
        public string Label { get; set; }
    }
}
