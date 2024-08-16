using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Symptoms.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symptoms.ApiClient.IoC
{
    public static class ServiceCollectionExtension
    {
        public static void AddSymptomsApiClientService(this IServiceCollection services,
            Action<ApiClientOptions> options)
        {
            services.Configure(options);
            services.AddSingleton(provider =>
            {
                var options = provider.GetRequiredService<IOptions<ApiClientOptions>>().Value;
                return new SymptomsApiClientService(options);
            });
        }
    }
}
