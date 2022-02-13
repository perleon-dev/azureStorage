using Customer.Application.Queries.Extensions.CosmosTableStorage;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Application.Commands.TableStorageCosmosCommands
{
    public class InsertUpdateContactCosmosTableStorageCommand : IRequest<Contacto>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
    }
}
