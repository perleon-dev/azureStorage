using Customer.Application.Commands.BlobStorageCommands;
using Customer.Application.Commands.QueueStorageFirstCommands;
using Customer.Application.Commands.TableStorageCosmosCommands;
using Customer.Application.Queries.Extensions.CosmosTableStorage;
using Customer.Application.Queries.Interfaces;
using Customer.Application.Queries.Querys.CosmosTableStorage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Customer.Api.Controllers
{
    [Route("azure-storage")]
    [ApiController]
    public class AzureStorageController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IContactoCosmosTableStorageQueryHandler _queryHandlerTableStorage;
        private readonly IBlobStorageQueryHandler _iBlobStorageQueryHandler;
        

        public AzureStorageController(IMediator mediator, 
            IContactoCosmosTableStorageQueryHandler queryHandlerTableStorage,
            IBlobStorageQueryHandler iBlobStorageQueryHandler) 
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _queryHandlerTableStorage = queryHandlerTableStorage ?? throw new ArgumentNullException(nameof(queryHandlerTableStorage));
            _iBlobStorageQueryHandler = iBlobStorageQueryHandler ?? throw new ArgumentNullException(nameof(iBlobStorageQueryHandler));
        }


        [HttpPost("upload-blob-storage")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UploadBlobStorage([FromForm] UploadBlobStorageCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("get-by-blob-storage")]
        [ProducesResponseType(typeof(Contacto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByBlobStorage([FromQuery] string query)
        {
            var result = await _iBlobStorageQueryHandler.GetBySearch(query);
            return Ok(result);
        }

        [HttpPost("insert-update-contact-cosmos-table-storage")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertTableStorageCosmos(InsertUpdateContactCosmosTableStorageCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("get-by-contact-cosmos-table-storage")]
        [ProducesResponseType(typeof(Contacto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> SelectTableStorageCosmos([FromQuery] ContactoCosmosTableStorageQuery query)
        {
           var result = await _queryHandlerTableStorage.GetBySearch(query);
           return Ok(result);
        }

        [HttpPost("delete-contact-cosmos-table-storage")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteTableStorageCosmos(DeleteContactCosmosTableStorageCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("insert-queue-storage")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertQueueStorage(InsertQueueStorageFirstCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("consume-queue-storage")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ConsumeQueueStorage(ConsumeQueueStorageFirstCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
