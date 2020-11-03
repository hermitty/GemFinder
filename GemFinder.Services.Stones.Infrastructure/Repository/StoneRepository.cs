using GemFinder.ImageProvider;
using GemFinder.Services.Stones.Core.Entities;
using GemFinder.Services.Stones.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GemFinder.Services.Stones.Infrastructure.Repository
{
    //TODO inject imageProvider
    public class StoneRepository : IStoneRepository
    {
        private IImageProvider imageProvider;
        private IList<Stone> stoneList;
        public StoneRepository()
        {
            imageProvider = new ImageProvider.ImageProvider();
            stoneList = imageProvider.GetStoredImagesInfo().GroupBy(x => x.Label).Select(stone => new Stone(
                new Guid(),
                stone.FirstOrDefault().Label.Replace('_', ' '),
                stone.FirstOrDefault().Label,
                stone.Select(i => new Image(i.Id, i.Path, i.Source)).ToList()
                )).ToList();
        }
        public async Task<Stone> GetStone(string label)
        {
            var stone = stoneList.FirstOrDefault(x => x.Label == label);
            return stone;
        }
    }
}
