using CapitolSharp.Congress.Stores;
using Microsoft.Extensions.DependencyInjection;
using CapitolSharp.DataStore.Extensions;

namespace CapitolSharp.Congress.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCapitolSharp(this IServiceCollection services, string apiKey)
        {
            services.AddCongressApiClient(apiKey);

            return services.AddScoped<IBills, Bills>()
                .AddScoped<ICommittees, Committees>()
                .AddScoped<ILobbying, Lobbying>()
                .AddScoped<IMembers, Members>()
                .AddScoped<IStatements, Statements>()
                .AddScoped<IVotes, Votes>();
        }
    }
}
