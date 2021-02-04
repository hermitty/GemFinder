using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.Services.Stores.Core.Entities
{
    public class StoreImage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public StoreImage()
        {

        }

        public StoreImage(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
