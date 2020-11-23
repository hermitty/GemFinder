using GemFinder.Services.Stones.Application.DTO;
using GemFinder.Services.Stones.Application.Queries;
using GemFinder.Services.Stones.Infrastructure.DataAccess;
using GemFinder.Utils.CQRS.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GemFinder.Services.Stones.Infrastructure.Queries.Handlers
{
    public class StoneQueryHandler : IQueryHandler<GetStonesImages, IEnumerable<StoneImageDTO>>
    {
        private readonly Context context;

        public StoneQueryHandler(Context context)
        {
            this.context = context;
        }


        public async Task<IEnumerable<StoneImageDTO>> HandleAsync(GetStonesImages query) //TODO put to config
        {
            var result = context.Stones
                .Select(x => new { Label = x.Label, FileNames = x.Images.Take(10) }).ToList()
                .Select(x => new StoneImageDTO(x.Label, x.FileNames.Select(img => "https://hermitty.blob.core.windows.net/images/" + img.Name).ToList()));

            return result;
        }
    }
}
