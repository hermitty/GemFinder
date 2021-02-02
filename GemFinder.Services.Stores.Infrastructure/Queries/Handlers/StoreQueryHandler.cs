using GemFinder.Services.Stores.Application.DTO;
using GemFinder.Services.Stores.Application.Queries;
using GemFinder.Services.Stores.Infrastructure.DataAccess;
using GemFinder.Utils.CQRS.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GemFinder.Services.Stores.Infrastructure.Queries.Handlers
{
    public class StoreQueryHandler : IQueryHandler<GetStore, StoreDTO>, IQueryHandler<GetStoreOpinions, IEnumerable<OpinionDTO>>,
                                        IQueryHandler<GetStores, IEnumerable<StoreShortDTO>>, IQueryHandler<GetStoresByCriteria, IEnumerable<StoreShortDTO>>
    {
        private readonly Context context;

        public StoreQueryHandler(Context context)
        {
            this.context = context;
        }

        public async Task<StoreDTO> HandleAsync(GetStore query)
        {
            var result = context.Stores
                .Where(x => x.Id == query.StoreId)
                .Select(x => new StoreDTO(x))
                .FirstOrDefault();

            return result;
        }

        public async Task<IEnumerable<OpinionDTO>> HandleAsync(GetStoreOpinions query)
        {
            var result = context.Stores
           .Where(x => x.Id == query.StoreId)
           .SelectMany(x => x.Opinions.Select(o => new OpinionDTO(o))).ToList();

            return result;
        }

        public async Task<IEnumerable<StoreShortDTO>> HandleAsync(GetStores query)
        {
            var result = context.Stores
                .Select(x => new StoreShortDTO(x))
                .ToList();

            return result;
        }

        public async Task<IEnumerable<StoreShortDTO>> HandleAsync(GetStoresByCriteria query)
        {
            var result = context.Stores
                .Where(x => x.StoreStones.Any(y => y.StoneId == query.StoneId))
                .Select(x => new StoreShortDTO(x))
                .ToList();

            return result;
        }
    }
}
