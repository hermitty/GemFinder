using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.Services.Stones.Core.Entities
{
    //TODO exception, set protected, add methods
    //agrregate valueobject
    public class Stone
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public IList<Image> Images { get; set; }

        public Stone(Guid id, string name, string label, IList<Image> images)
        {
            Id = id;
            Name = name;
            Label = label;
            Images = images;
        }
    }
}
