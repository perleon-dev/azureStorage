using Customer.Application.Queries.Extensions.CosmosTableStorage;
using Customer.Application.Queries.Generics;
using MediatR;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Application.Commands.TableStorageCosmosCommands
{
    public class InsertUpdateContactCosmosTableStorageCommandHandler : IRequestHandler<InsertUpdateContactCosmosTableStorageCommand, Contacto>
    {

        private readonly IValuesSettings _valuesSettings;


        public InsertUpdateContactCosmosTableStorageCommandHandler(IValuesSettings valuesSettings)
        {
            _valuesSettings = valuesSettings;
        }

        public async Task<Contacto> Handle(InsertUpdateContactCosmosTableStorageCommand request, CancellationToken cancellationToken)
        {
            var cloudTable = await ConnectionTableAsync("PruebaTableStorage001");
            var result = await InsertTableStorageAsync(cloudTable, request);

            return result;
        }

        private async Task<CloudTable> ConnectionTableAsync(string tableName) 
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_valuesSettings.GetConnectionAzureStorage());
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            CloudTable table = tableClient.GetTableReference(tableName);

            await table.CreateIfNotExistsAsync();
            return table;
        }

        private async Task<Contacto> InsertTableStorageAsync(CloudTable table, InsertUpdateContactCosmosTableStorageCommand command ) 
        {

            Contacto contact = new Contacto(command.LastName, command.FirstName);
            contact.Email = command.Email;

            TableOperation insertOperation = TableOperation.InsertOrMerge(contact);
            TableResult result = await table.ExecuteAsync(insertOperation);
            Contacto insertedContact = result.Result as Contacto;

            return insertedContact;
        }
    }
}
