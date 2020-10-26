using System;
using Convey.CQRS.Queries;
using GemFinder.Identity.DTO;

namespace GemFinder.Identity.Query
{
    public class GetUser : IQuery<UserDto>
    {
        public Guid UserId { get; set; }
    }
}