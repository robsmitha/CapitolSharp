using CapitolSharp.Congress.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace CapitolSharp.Congress
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCongressApi(
            this IServiceCollection services,
            string apiKey)
        {
            services.AddHttpClient("CongressApiClient", client =>
            {
                client.BaseAddress = new Uri("https://api.propublica.org/congress/v1");
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);
            });

            services.AddScoped<IBills, Bills>();
            services.AddScoped<ICommittees, Committees>();
            services.AddScoped<ILobbying, Lobbying>();
            services.AddScoped<IMembers, Members>();
            services.AddScoped<IStatements, Statements>();
            services.AddScoped<IVotes, Votes>();

            return services;
        }
    }
}
