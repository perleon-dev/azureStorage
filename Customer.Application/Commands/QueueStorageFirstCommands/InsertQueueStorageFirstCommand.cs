using MediatR;


namespace Customer.Application.Commands.QueueStorageFirstCommands
{
    public class InsertQueueStorageFirstCommand : IRequest<int>
    {
        public string UserName { get; set; }
    }
}
