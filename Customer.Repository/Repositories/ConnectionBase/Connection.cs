using Customer.Domain.Aggregates.ConnectionBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Repository.Repositories.ConnectionBase
{
    public class Connection : IConnection
    {
        public string ConnectionString { get; set; }
        public Connection(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public string GetConnectionString()
        {
            return ConnectionString;
        }
    }
}
