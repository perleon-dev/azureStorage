using Customer.Application.Commands.SellerCommands;
using Customer.Application.Queries.Implementations;
using Customer.Application.Queries.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Customer.Api.Controllers
{
    [Route("seller")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISellerQueryHandler ISellerQueryHandler;


        public SellerController(IMediator mediator, ISellerQueryHandler iSellerQueryHandler)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            ISellerQueryHandler = iSellerQueryHandler ?? throw new ArgumentNullException(nameof(iSellerQueryHandler));
        }


        //[HttpGet]
        //[ProducesResponseType((int)HttpStatusCode.Created)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> Search(CreateSellerCommand command)
        //{
        //    var result = ISellerQueryHandler.Search(); ;
        //    return CreatedAtAction(nameof(CreateConcept), result);
        //}


        [HttpPost("send")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateConcept(CreateSellerCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateConcept), result);
        }
    }
}
