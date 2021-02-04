using System.Collections.Generic;

namespace GemFinder.Services.Stones.Application.DTO
{
    public class StoneDTO
    {
        public string Label { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Url { get; set; }

        public StoneDTO(string label, IEnumerable<string> url, string name)
        {
            Label = label;
            Url = url;
            Name = name;
        }
    }
}
