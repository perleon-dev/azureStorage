using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Application.Commands.SellerCommands
{
    public class CreateSellerCommand : IRequest<bool>
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fnacimiento { get; set; }
    }
}
