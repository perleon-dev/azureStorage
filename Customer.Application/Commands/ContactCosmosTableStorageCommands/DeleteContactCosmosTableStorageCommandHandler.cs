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
    public class DeleteContactCosmosTableStorageCommandHandler : IRequestHandler<DeleteContactCosmosTableStorageCommand, int>
    {

        private readonly IValuesSettings _valuesSettings;

        public DeleteContactCosmosTableStorageCommandHandler(IValuesSettings valuesSettings)
        {
            _valuesSettings = valuesSettings;
        }

        public async Task<int> Handle(DeleteContactCosmosTableStorageCommand request, CancellationToken cancellationToken)
        {
            var cloudTable = ConnectionTableAsync("PruebaTableStorage001");
            var result = await DeleteContactTableStorageAsync(cloudTable, request);

            return 1;
        }

        private CloudTable ConnectionTableAsync(string tableName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_valuesSettings.GetConnectionAzureStorage());
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            CloudTable table = tableClient.GetTableReference(tableName);

            return table;
        }

        private async Task<TableResult> DeleteContactTableStorageAsync(CloudTable table, DeleteContactCosmosTableStorageCommand command)
        {

            Contacto contact = new Contacto(command.LastName, command.FirstName) 
            {
                ETag = "*"
            };

            TableOperation deleteOperation = TableOperation.Delete(contact);
            TableResult result = await table.ExecuteAsync(deleteOperation);

            return result;
        }
    }
}
