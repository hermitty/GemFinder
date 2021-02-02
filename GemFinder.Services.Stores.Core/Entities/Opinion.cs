using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.Services.Stores.Core.Entities
{
    public class Opinion
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }

        public Opinion()
        {}

        public Opinion(Guid id, Guid userId, string comment, int rate)
        {
            Id = id;
            UserId = userId;
            Comment = comment;
            Rate = rate;
        }
    }
}
