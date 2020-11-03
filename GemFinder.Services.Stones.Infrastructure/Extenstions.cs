using GemFinder.Utils.CQRS;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.Services.Stones.Infrastructure
{
    public static class Extenstions
    {
        public static IServiceCollection AddInfrasructure(this IServiceCollection builder)
        {
            builder.AddQueryHandlers();

            return builder;
        }
    }
}
