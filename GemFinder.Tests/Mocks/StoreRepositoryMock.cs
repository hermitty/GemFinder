
using GemFinder.Services.Stores.Core.Entities;
using GemFinder.Services.Stores.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GemFinder.Tests.Mocks
{
    public class StoreRepositoryMock : IStoreRepository
    {
        private readonly IList<Store> stores;
        public StoreRepositoryMock()
        {
            stores = new List<Store>();
        }
        public async Task AddStore(Store store)
        {
            stores.Add(store);
        }

        public Task DeleteStore(Store store)
        {
            throw new NotImplementedException();
        }

        public Task<Store> GetStore(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            return stores;
        }

        public Task UpdateStore(Store store)
        {
            throw new NotImplementedException();
        }
    }
}
