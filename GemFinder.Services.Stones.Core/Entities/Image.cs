using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.Services.Stones.Core.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string SourceUrl { get; set; }

        public Image(Guid id, string path, string sourceUrl)
        {
            Id = id;
            Path = path;
            SourceUrl = sourceUrl;
        }
    }
}
