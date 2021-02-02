using GemFinder.Services.Stones.Core.Entities;
using GemFinder.Services.Stones.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GemFinder.Tests
{
    public class StoneRepositoryMock : IStoneRepository
    {
        private readonly IList<Stone> stones;
        public StoneRepositoryMock()
        {
            var stone1 = new Stone(Guid.NewGuid(), "stone1", "stone_1", new List<Image>());
            var stone2 = new Stone(Guid.NewGuid(), "stone2", "stone_2", new List<Image>());
            var stone3 = new Stone(Guid.NewGuid(), "stone3", "stone_3", new List<Image>());
            stones = new List<Stone>() { stone1, stone2, stone3 };

        }

        public async Task AddStone(Stone stone)
        {
            stones.Add(stone);
        }

        public Task DeleteImage(Image image)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStone(Stone stone)
        {
            throw new NotImplementedException();
        }

        public Task<Stone> GetAllStones()
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetImage(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Stone> GetStone(string label)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStone(Stone stone)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Stone>> IStoneRepository.GetAllStones()
        {
            return stones;
        }
    }
}
