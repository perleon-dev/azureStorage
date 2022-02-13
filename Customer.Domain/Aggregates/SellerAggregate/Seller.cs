using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Domain.Aggregates.SellerAggregate
{
    public class Seller
    {
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fnacimiento { get; set; }
    }
}
