using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Application.Commands.QueueStorageFirstCommands
{
    public class ConsumeQueueStorageFirstCommand : IRequest<int>
    {
    }
}
