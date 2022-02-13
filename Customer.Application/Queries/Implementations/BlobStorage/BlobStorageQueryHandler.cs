using Azure.Storage.Blobs;
using Customer.Application.Queries.Generics;
using Customer.Application.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Queries.Implementations.BlobStorage
{
    public  class BlobStorageQueryHandler : IBlobStorageQueryHandler
    {
        private readonly IValuesSettings _valuesSettings;
        private readonly BlobServiceClient _blobServiceClient;

        public BlobStorageQueryHandler(IValuesSettings valuesSettings, BlobServiceClient blobServiceClient)
        {
            _valuesSettings = valuesSettings;
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> GetBySearch(string query)
        {
            var container = _blobServiceClient.GetBlobContainerClient("pruebalaboratorio");
            container.CreateIfNotExists();

            var blobClient = container.GetBlobClient(query);

            return blobClient.Uri.AbsoluteUri;
        }
    }
}
