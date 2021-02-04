using GemFinder.Services.Stores.Infrastructure.DataAccess;
using GemFinder.Utils.CQRS;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GemFinder.Services.Stores.Core.Repositories;
using GemFinder.Services.Stores.Infrastructure.Repository;

namespace GemFinder.Services.Stores.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrasructure(this IServiceCollection builder)
        {

            builder.AddQueryHandlers();
            builder.AddCommandHandlers();
            builder.AddRepositories();
            builder.AddDbContext<Context>(options =>
            options.LogTo(s => { System.Diagnostics.Debug.WriteLine(s); }).
                UseSqlServer("Data Source=DESKTOP-N7RLEAS\\DOGOCENTER; Initial Catalog=GemFinder; Integrated Security=True;"));

            return builder;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection builder)
        {
            builder.AddScoped<IStoreRepository, StoreRepository>();
            return builder;
        }
    }
}
