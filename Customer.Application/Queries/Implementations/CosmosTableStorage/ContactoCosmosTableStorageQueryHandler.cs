using Customer.Application.Queries.Extensions.CosmosTableStorage;
using Customer.Application.Queries.Generics;
using Customer.Application.Queries.Interfaces;
using Customer.Application.Queries.Querys.CosmosTableStorage;
using Microsoft.Azure.Cosmos.Table;
using System.Threading.Tasks;

namespace Customer.Application.Queries.Implementations.CosmosTableStorage
{
    public class ContactoCosmosTableStorageQueryHandler : IContactoCosmosTableStorageQueryHandler
    {

        private readonly IValuesSettings _valuesSettings;

        public ContactoCosmosTableStorageQueryHandler(IValuesSettings valuesSettings)
        {
            _valuesSettings = valuesSettings;
        }

        public async Task<Contacto> GetBySearch(ContactoCosmosTableStorageQuery query)
        {
            var cloudTable = ConnectionTableAsync("PruebaTableStorage001");
            TableOperation retrieveOperation = TableOperation.Retrieve<Contacto>(query.LastName, query.FirstName);
            TableResult result = await cloudTable.ExecuteAsync(retrieveOperation);
            Contacto contact = result.Result as Contacto;

            if (contact != null)
                return contact;
            else
                return null;
        }

        private CloudTable ConnectionTableAsync(string tableName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_valuesSettings.GetConnectionAzureStorage());
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            CloudTable table = tableClient.GetTableReference(tableName);

            return table;
        }
    }
}
