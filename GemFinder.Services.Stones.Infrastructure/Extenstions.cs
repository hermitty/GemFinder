using GemFinder.Services.Stones.Infrastructure.DataAccess;
using GemFinder.Utils.CQRS;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

namespace GemFinder.Services.Stones.Infrastructure
{
    public static class Extenstions
    {
        public static IServiceCollection AddInfrasructure(this IServiceCollection builder)
        {
 
            builder.AddQueryHandlers();
            builder.AddDbContext<Context>(options =>
            options.LogTo(s => { System.Diagnostics.Debug.WriteLine(s); }).
                UseSqlServer("Data Source=DESKTOP-N7RLEAS\\DOGOCENTER; Initial Catalog=GemFinder; Integrated Security=True;"));

            return builder;
        }
    }
}
