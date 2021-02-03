using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.Services.Stones.Application.DTO
{
    public class StoneImageDTO
    {
        public string Label { get; set; }
        public string Url { get; set; }
        public StoneImageDTO(string label, string url)
        {
            Label = label;
            Url = url;
        }
    }
}
