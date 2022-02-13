using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Domain.Aggregates.ConnectionBase
{
    public interface IConnection
    {
        string GetConnectionString();
    }
}
