using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Queries.Interfaces
{
    public interface IBlobStorageQueryHandler
    {
        Task<string> GetBySearch(string query);
    }
}
