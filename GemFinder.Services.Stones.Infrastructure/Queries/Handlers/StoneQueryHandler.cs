﻿using GemFinder.Services.Stones.Application.DTO;
using GemFinder.Services.Stones.Application.Queries;
using GemFinder.Services.Stones.Infrastructure.DataAccess;
using GemFinder.Utils.CQRS.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GemFinder.Utils.CQRS.Commands;

namespace GemFinder.Services.Stones.Infrastructure.Queries.Handlers
{
    public class StoneQueryHandler : IQueryHandler<GetStonesImages, IEnumerable<StoneImageDTO>>, IQueryHandler<GetStoneInfo, StoneDTO>
    {
        private readonly Context context;

        public StoneQueryHandler(Context context)
        {
            this.context = context;
        }


        public async Task<IEnumerable<StoneImageDTO>> HandleAsync(GetStonesImages query) //TODO put to config
        {
            var result = context.Stones
                .Select(x => new { Label = x.Label, Image = x.Images.FirstOrDefault().Name }).ToList()
                .Select(x => new StoneImageDTO(x.Label, "https://hermitty.blob.core.windows.net/images/" + x.Image));

            return result;
        }

        public async Task<StoneDTO> HandleAsync(GetStoneInfo query)
        {
            var result = context.Stones
                 .Where(x => x.Label == query.Label)
                 .Select(x => new StoneDTO(x.Label, x.Images.Select(img => "https://hermitty.blob.core.windows.net/images/" + img.Name).ToList(), x.Name))
                 .FirstOrDefault();
            return result;
        }
    }
}
