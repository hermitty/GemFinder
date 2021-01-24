using GemFinder.Utils.CQRS.Commands;
using GemFinder.Utils.CQRS.Commands.Dispatchers;
using GemFinder.Utils.CQRS.Queries;
using GemFinder.Utils.CQRS.Queries.Dispatchers;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace GemFinder.Utils.CQRS
{
    public static class Extensions
    {
        public static IServiceCollection AddQueryHandlers(this IServiceCollection builder)
        {
            builder.Scan(s =>
                s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                    .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            return builder;
        }

        public static IServiceCollection AddInMemoryQueryDispatcher(this IServiceCollection builder)
        {
            builder.AddSingleton<IQueryDispatcher, QueryDispatcher>();
            return builder;
        }

        public static IServiceCollection AddCommandHandlers(this IServiceCollection builder)
        {
            builder.Scan(s =>
                s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            return builder;
        }

        public static IServiceCollection AddInMemoryCommandDispatcher(this IServiceCollection builder)
        {
            builder.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            return builder;
        } 
    }
}
