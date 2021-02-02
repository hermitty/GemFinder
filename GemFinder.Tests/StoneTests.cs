using GemFinder.Services.Stones.Core.Entities;
using GemFinder.Services.Stones.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GemFinder.Tests
{
    public class StoneTests
    {
        private readonly IStoneRepository repo;
        public StoneTests()
        {
            repo = new StoneRepositoryMock();
        }

        [Fact]
        public void StoneIsUnique()
        {
            var stone = new Stone(Guid.NewGuid(), "test", "test", new List<Image>());
            repo.AddStone(stone);
            var allStones = repo.GetAllStones().Result;
            var numberOfStones = allStones.Where(x => x.Id == stone.Id).Count();
            Assert.True(numberOfStones == 1);
        }

        [Fact]
        public void StoneHasImages()
        {
            var stone = new Stone(Guid.NewGuid(), "test", "test", new List<Image>());
            stone.AddImage("test");
            Assert.NotEmpty(stone.Images);
        }

        [Fact]
        public void StoneHasLabel()
        {
            var stone = new Stone(Guid.NewGuid(), "test", "test", new List<Image>());
            Assert.NotNull(stone.Images);
        }

        [Fact]
        public void StoneHasNoImages()
        {
            var stone = new Stone(Guid.NewGuid(), "test", "test", new List<Image>());
            Assert.Empty(stone.Images);
        }
    }
}
