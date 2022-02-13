using Autofac;
using Customer.Application.Queries.Generics;
using Customer.Application.Queries.Implementations.BlobStorage;
using Customer.Application.Queries.Implementations.CosmosTableStorage;
using Customer.Application.Queries.Interfaces;
using Customer.Domain.Aggregates.ConnectionBase;
using Customer.Domain.Aggregates.SellerAggregate;
using Customer.Repository.Repositories;
using Customer.Repository.Repositories.ConnectionBase;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Api.Infraestructure.AutofacModules
{
    [ExcludeFromCodeCoverage]
    public class ApplicationModule : Autofac.Module
    {
        private readonly string _connectionString;
        private readonly string _timeZone;
        private readonly string _connectionAzureStorage;
        private readonly string _azureCosmosTableStorage;

        public ApplicationModule(string connectionString,
                                 string timeZone,
                                 string connectionAzureStorage,
                                 string azureCosmosTableStorage) 
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _timeZone = timeZone ?? throw new ArgumentNullException(nameof(timeZone));
            _connectionAzureStorage = connectionAzureStorage ?? throw new ArgumentNullException(nameof(connectionAzureStorage));
            _azureCosmosTableStorage = azureCosmosTableStorage ?? throw new ArgumentNullException(nameof(azureCosmosTableStorage));
        }

        protected override void Load(ContainerBuilder builder)
        {
            #region Transversal

            builder.Register(c => new Connection(_connectionString)).As<IConnection>().InstancePerLifetimeScope();
            builder.Register(c => new ValuesSettings(_timeZone, _connectionAzureStorage, _azureCosmosTableStorage)).As<IValuesSettings>().InstancePerLifetimeScope();

            #endregion

            #region Queries

            builder.RegisterType<ContactoCosmosTableStorageQueryHandler>().As<IContactoCosmosTableStorageQueryHandler>().InstancePerLifetimeScope();
            builder.RegisterType<BlobStorageQueryHandler>().As<IBlobStorageQueryHandler>().InstancePerLifetimeScope(); 

            #endregion

            #region Mapper

            #endregion

            #region Repositoy

            builder.RegisterType<SellerRepository>().As<ISellerRepository>().InstancePerLifetimeScope();

            #endregion

            #region Services

            #endregion

            base.Load(builder);
        }

    }
}
