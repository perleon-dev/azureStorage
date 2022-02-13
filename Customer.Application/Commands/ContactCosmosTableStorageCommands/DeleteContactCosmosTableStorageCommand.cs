using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Application.Commands.TableStorageCosmosCommands
{
    public class DeleteContactCosmosTableStorageCommand : IRequest<int>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
