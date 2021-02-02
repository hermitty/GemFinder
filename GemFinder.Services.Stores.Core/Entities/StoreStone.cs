using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.Services.Stores.Core.Entities
{
    public class StoreStone
    {
        public Guid Id { get; set; }
        public Guid StoneId { get; set; }

        public StoreStone()
        {

        }

        public StoreStone(Guid stoneId)
        {
            Id = Guid.NewGuid();
            StoneId = stoneId;
        }
    }
}
