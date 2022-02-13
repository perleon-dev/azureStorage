using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Customer.Application.Commands.BlobStorageCommands;
using Customer.Application.Queries.Generics;
using MediatR;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Application.Commands.QueueStorageFirstCommands
{
    public class ConsumeQueueStorageFirstCommandHandler : IRequestHandler<ConsumeQueueStorageFirstCommand, int>
    {
        private readonly IValuesSettings _valuesSettings;
        private readonly IMediator _mediator;
        private readonly BlobServiceClient _blobServiceClient;

        public ConsumeQueueStorageFirstCommandHandler(IValuesSettings valuesSettings, 
                                                    IMediator mediator,
                                                    BlobServiceClient blobServiceClient)
        {
            _valuesSettings = valuesSettings;
            _mediator = mediator;
            _blobServiceClient = blobServiceClient;
        }


        public async Task<int> Handle(ConsumeQueueStorageFirstCommand request, CancellationToken cancellationToken)
        {
            var queue = ConnectionQueueStorage();
            await ConsumeQueue(queue);

            return 1;
        }

        private CloudQueue ConnectionQueueStorage()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_valuesSettings.GetConnectionAzureStorage());
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference("procesos");

            return queue;
        }

        private async Task ConsumeQueue(CloudQueue queue) 
        {
            CloudQueueMessage peekedMessage = queue.PeekMessage();

            foreach (CloudQueueMessage item in queue.GetMessages(3, TimeSpan.FromSeconds(100))) 
            {
                var message = queue.GetMessage().AsString;
                string filePath = string.Format(@"log{0}.txt", item.Id);
             
                using (var memory = new MemoryStream())
                {
                    var tw = new StreamWriter(memory);
                    await tw.WriteLineAsync(message);
                    await tw.FlushAsync();
 
                    await UploadBlobStorage(memory, filePath);
                }

                queue.DeleteMessage(item);
            }
        }

        private async Task UploadBlobStorage(Stream file, string fileName) 
        {

            var container = _blobServiceClient.GetBlobContainerClient("pruebalaboratorio");
            container.CreateIfNotExists();

            var blobClient = container.GetBlobClient(fileName);
            file.Position = 0;
            await blobClient.UploadAsync(file, new BlobHttpHeaders { ContentType = "text/plain" });
        }
    }
}
