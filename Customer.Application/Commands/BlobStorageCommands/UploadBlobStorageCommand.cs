using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Application.Commands.BlobStorageCommands
{
    public class UploadBlobStorageCommand : IRequest<string>
    { 
        public IFormFile file { get; set; } // Microsoft.AspNetCore.Http
    }
}
