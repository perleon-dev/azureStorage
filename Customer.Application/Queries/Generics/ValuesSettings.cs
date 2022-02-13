using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Application.Queries.Generics
{
    public class ValuesSettings : IValuesSettings
    {
        public string _timeZone { get; private set; }
        public string _connectionAzureStorage { get; private set; }
        public string _azureCosmosTableStorage { get; private set; }

        public ValuesSettings(string timeZone, string connectionAzureStorage, string azureCosmosTableStorage)
        {
            _timeZone = timeZone;
            _connectionAzureStorage = connectionAzureStorage;
            _azureCosmosTableStorage = azureCosmosTableStorage;
        }

        public string GetTimeZone()
        {
            return _timeZone;
        }

        public string GetConnectionAzureStorage()
        {
            return _connectionAzureStorage;
        }

        public string GetConnectionAzureCosmosTableStorage()
        {
            return _azureCosmosTableStorage;
        }
    }

    public interface IValuesSettings
    {
        string GetTimeZone();
        string GetConnectionAzureStorage();
        string GetConnectionAzureCosmosTableStorage();
    }
}