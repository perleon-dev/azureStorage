using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Customer.Application.Queries.Generics;
using MediatR;
using System;

using System.Threading;
using System.Threading.Tasks;

namespace Customer.Application.Commands.BlobStorageCommands
{
    public class UploadBlobStorageCommandHandler : IRequestHandler<UploadBlobStorageCommand, string>
    {
        private readonly IValuesSettings  _valuesSettings;
        private readonly BlobServiceClient _blobServiceClient;

        public UploadBlobStorageCommandHandler(IValuesSettings valuesSettings, BlobServiceClient blobServiceClient) 
        {
            _valuesSettings = valuesSettings;
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> Handle(UploadBlobStorageCommand request, CancellationToken cancellationToken)
        {
            var container = _blobServiceClient.GetBlobContainerClient("pruebalaboratorio");
            container.CreateIfNotExists();

            var blobClient = container.GetBlobClient(request.file.FileName);
            await blobClient.UploadAsync(request.file.OpenReadStream(), new BlobHttpHeaders { ContentType = request.file.ContentType });

            return blobClient.Uri.AbsoluteUri;
        }
    }
}
