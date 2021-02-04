using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.Services.Stores.Core.Entities
{
    public class Reference
    {
        public Guid Id { get; set; }
        public string Url { get; set; }

        public Reference()
        {

        }

        public Reference(string url)
        {
            Id = Guid.NewGuid();
            Url = url;
        }
    }
}
