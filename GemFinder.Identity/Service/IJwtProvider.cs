using GemFinder.Identity.DTO;
using System;
using System.Collections.Generic;

namespace GemFinder.Identity.Service
{
    public interface IJwtProvider
    {
        AuthDto Create(Guid userId, string role, string audience = null,
            IDictionary<string, IEnumerable<string>> claims = null);
    }
}