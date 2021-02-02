using GemFinder.Identity.Entity;
using GemFinder.Services.Stores.Core.Entities;
using GemFinder.Services.Stores.Core.Repositories;
using GemFinder.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace GemFinder.Tests
{
    public class UserTests
    {
        IStoreRepository storeRepo;
        public UserTests()
        {
            storeRepo = new StoreRepositoryMock();
        }

        [Fact]
        public void UserIsActive()
        {
            var user = new User();
            Assert.False(user.Active);
        }

        [Fact]
        public void UserHasStore()
        {
            var user = new User(Guid.NewGuid(),"email","assword","admin", DateTime.Now);
            var store = new Store() { Owner = user.Id };
            storeRepo.AddStore(store);
            var allStores = storeRepo.GetStores().Result;
            var any = allStores.Any(x => x.Owner == user.Id);
            Assert.True(any);
        }

        [Fact]
        public void UserHasNoStore()
        {
            var user = new User(Guid.NewGuid(), "email", "assword", "admin", DateTime.Now);
            var store = new Store();
            storeRepo.AddStore(store);
            var allStores = storeRepo.GetStores().Result;
            var any = allStores.Any(x => x.Owner == user.Id);
            Assert.False(any);
        }

        [Fact]
        public void UserAddedOpinion()
        {
            var user = new User(Guid.NewGuid(), "email", "assword", "admin", DateTime.Now);
            var opinion = new Opinion(Guid.NewGuid(), user.Id, "opinion", 5);
            var store = new Store() { Opinions = new List<Opinion>()};
            store.AddOpinion(opinion);
            storeRepo.AddStore(store);
            var allStores = storeRepo.GetStores().Result;
            var any = allStores.Any(x => x.Opinions.Any(o => o.UserId == user.Id));
            Assert.True(any);
        }

        [Fact]
        public void UserCanBeLogged()
        {
            var user = new User();
            user.Active = true;
            Assert.True(user.Active);
        }
    }
}
