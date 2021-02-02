using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.Services.Stores.Core.Entities
{
    public class SupportMessage
    {
        public Guid Id { get; set; }
        public Guid Userid { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
    }
}
