using AutoMapper.Execution;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.DataStore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCongressApiClient(this IServiceCollection services, string apiKey)
        {
            services.AddHttpClient(DataStoreConstants.CONGRESS_API_CLIENT, client =>
            {
                client.BaseAddress = new Uri("https://api.propublica.org/congress/v1");
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);
            });

            return services;
        }
    }
}
