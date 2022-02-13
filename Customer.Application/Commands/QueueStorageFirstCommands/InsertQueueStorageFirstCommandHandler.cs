using Customer.Application.Queries.Generics;
using MediatR;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Application.Commands.QueueStorageFirstCommands
{
    class InsertQueueStorageFirstCommandHandler : IRequestHandler<InsertQueueStorageFirstCommand, int>
    {
        private readonly IValuesSettings _valuesSettings;


        public InsertQueueStorageFirstCommandHandler(IValuesSettings valuesSettings)
        {
            _valuesSettings = valuesSettings;
        }

        public Task<int> Handle(InsertQueueStorageFirstCommand request, CancellationToken cancellationToken)
        {
            var queue = ConnectionQueueStorage();
            InsertQueue(queue, request);

            return Task.FromResult(1);
        }

        private CloudQueue ConnectionQueueStorage()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_valuesSettings.GetConnectionAzureStorage());
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference("procesos");
            queue.CreateIfNotExists();

            return queue;
        }

        private void InsertQueue(CloudQueue queue, InsertQueueStorageFirstCommand request) 
        {
            CloudQueueMessage message = new CloudQueueMessage(string.Format("Operacion : {0}", request.UserName));
            queue.AddMessage(message);
        }
    }
}
