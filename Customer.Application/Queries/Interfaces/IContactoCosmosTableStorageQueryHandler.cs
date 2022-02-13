using Customer.Application.Queries.Extensions.CosmosTableStorage;
using Customer.Application.Queries.Querys;
using Customer.Application.Queries.Querys.CosmosTableStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Queries.Interfaces
{
    public interface IContactoCosmosTableStorageQueryHandler
    {
        Task<Contacto> GetBySearch(ContactoCosmosTableStorageQuery query);
    }
}
