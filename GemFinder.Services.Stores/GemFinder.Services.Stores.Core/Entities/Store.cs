using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.Services.Stores.Core.Entities
{
    public class Store
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Owner { get; set; }
        public List<Reference> References { get; set; }
        public List<Opinion> Opinions { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<StoreImage> StoreImages { get; set; }
        public List<StoreStone> StoreStones { get; set; }

        public void AddOpinion(Opinion opinion)
        {
            Opinions.Add(opinion);
        }
    }
}
