using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Api.Infraestructure.Extensions
{
    public static class IServiceCollectionExtensions
    {

        public static IServiceCollection AddAzureStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(x => new BlobServiceClient(configuration["ConnectionStrings:AzureStorage"]));
            return services;
        }
    }
}
