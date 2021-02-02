using GemFinder.Services.Stores.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GemFinder.Services.Stores.Application.DTO
{
    public class StoreDTO
    {
        public StoreDTO()
        { }

        public StoreDTO(Store store)
        {
            Id = store.Id;
            Name = store.Name;
            References = store.References.Select(x => x.Url).ToList();
            Location = store.Location;
            Description = store.Description;
            Images = store.StoreImages.Select(x => x.Name).ToList();
            Stones = store.StoreStones.Select(x => x.StoneId).ToList();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> References { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public List<Guid> Stones { get; set; }
    }
}
