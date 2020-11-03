using GemFinder.ImageProvider;
using GemFinder.Services.Stones.Application.DTO;
using GemFinder.Services.Stones.Application.Queries;
using GemFinder.Utils.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemFinder.Services.Stones.Infrastructure.Queries.Handlers
{
    public class StoneQueryHandler : IQueryHandler<GetSingleImageStone, SingleImageStoneDto>
    {
        private IImageProvider imageProvider;

        public StoneQueryHandler()
        {
            imageProvider = new ImageProvider.ImageProvider();
        }

        public async Task<SingleImageStoneDto> HandleAsync(GetSingleImageStone query)
        {
            var imageData = imageProvider.GetStoredImagesInfo().FirstOrDefault(x => x.Label == query.Label);
            var image = System.IO.File.ReadAllBytes(Path.Combine(imageData.Path,imageData.FileName));
            var result = new SingleImageStoneDto()
            {
                Label = imageData.Label,
                Image = image
            };
            return result;
        }
    }
}
