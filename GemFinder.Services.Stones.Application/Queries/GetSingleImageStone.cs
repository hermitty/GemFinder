using GemFinder.Services.Stones.Application.DTO;
using GemFinder.Utils.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.Services.Stones.Application.Queries
{
    public class GetSingleImageStone : IQuery<SingleImageStoneDto>
    {
        public string Label { get; set; }
    }
}
