using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.Services.Stores.Application.DTO
{
    public class NewOpinionDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
    }
}
