using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Application.Commands.SellerCommands
{
    public class CreateSellerCommandHandlercs : IRequestHandler<CreateSellerCommand, bool>
    {
        public Task<bool> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
            var c = 0;

            return Task.FromResult(true);
        }
    }
}
