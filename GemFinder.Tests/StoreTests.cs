using GemFinder.Services.Stones.Core.Entities;
using GemFinder.Services.Stores.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GemFinder.Tests
{
    public class StoreTests
    {
        [Fact]
        public void StoreHasReferenes()
        {
            var reference = new Reference("ref");
            var store = new Store() { References = new List<Reference>() { reference } };
            Assert.NotEmpty(store.References);
        }

        [Fact]
        public void StoreHasOwner()
        {
            var store = new Store() { Owner = Guid.NewGuid() };
            Assert.True(store.Owner != Guid.Empty);
        }

        [Fact]
        public void StoreDoesNotHaveOwner()
        {
            var store = new Store();
            Assert.True(store.Owner == Guid.Empty);
        }

        [Fact]
        public void StoreHasStoneList()
        {
            var stone = new StoreStone(Guid.NewGuid());
            var store = new Store() { StoreStones = new List<StoreStone>() { stone } };
            Assert.NotEmpty(store.StoreStones);
        }

        [Fact]
        public void StoreHasImageList()
        {
            var image = new StoreImage("img");
            var store = new Store() { StoreImages = new List<StoreImage>() { image } };
            Assert.NotEmpty(store.StoreImages);
        }

        public void StoreDoesNotHavaImageList()
        {
            var store = new Store() { StoreImages = new List<StoreImage>() };
            Assert.Empty(store.StoreImages);
        }

        [Fact]
        public void StoreHasOpinions()
        {
            var opinion = new Opinion(Guid.NewGuid(), Guid.NewGuid(), "", 4);
            var store = new Store() { Opinions = new List<Opinion>() { opinion } };
            Assert.NotEmpty(store.Opinions);
        }

        [Fact]
        public void StoreDoesNotHaveOpinions()
        {
            var store = new Store() { Opinions = new List<Opinion>()};
            Assert.Empty(store.Opinions);
        }
    }
}
