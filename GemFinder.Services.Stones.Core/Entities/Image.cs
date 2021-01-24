using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.Services.Stones.Core.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string SourceUrl { get; set; }

        public Image(Guid id, string path, string sourceUrl, string name)
        {
            Id = id;
            Path = path;
            SourceUrl = sourceUrl;
            Name = name;
        }

        public Image(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Image()
        {

        }
    }
}
