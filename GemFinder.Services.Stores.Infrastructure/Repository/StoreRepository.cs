using GemFinder.Services.Stores.Core.Entities;
using GemFinder.Services.Stores.Core.Repositories;
using GemFinder.Services.Stores.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GemFinder.Services.Stores.Infrastructure.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly Context context;
        public StoreRepository(Context context)
        {
            this.context = context;
        }

        public async Task AddStore(Store store)
        {
            context.Add(store);
            context.SaveChanges();
        }

        public async Task DeleteStore(Store store)
        {
            context.Remove(store);
            context.SaveChanges();
        }

        public async Task<Store> GetStore(Guid id)
        {
            var store = context.Stores
                  .FirstOrDefault(x => x.Id == id);
            return store;
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            var stores = context.Stores.ToList();
            return stores;
        }

        public async Task UpdateStore(Store store)
        {
            context.Update(store);
            context.SaveChanges();
        }
    }
}
