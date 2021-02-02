using GemFinder.Services.Stores.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GemFinder.Services.Stores.Core.Repositories
{
    public interface IStoreRepository
    {
        Task<Store> GetStore(Guid id);
        Task <IEnumerable<Store>> GetStores();
        Task UpdateStore(Store store);
        Task AddStore(Store store);
        Task DeleteStore(Store store);
    }
}
