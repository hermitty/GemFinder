using GemFinder.Services.Stores.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GemFinder.Services.Stores.Application.DTO
{
    public class StoreShortDTO
    {
        public StoreShortDTO(Store store)
        {
            Id = store.Id;
            Name = store.Name;
            Images = store.StoreImages.Select(x => x.Name).ToList();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Images { get; set; }
    }
}
