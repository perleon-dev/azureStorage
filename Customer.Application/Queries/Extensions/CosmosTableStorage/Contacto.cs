using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Application.Queries.Extensions.CosmosTableStorage
{
    public class Contacto : TableEntity
    {
        public string Email { get; set; }

        public Contacto() 
        {
        
        }

        public Contacto(string apellido, string nombre)
        {
            PartitionKey = apellido;
            RowKey = nombre;
        }
    }
}
