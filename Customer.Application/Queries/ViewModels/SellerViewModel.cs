using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Application.Queries.ViewModels
{
    public class SellerViewModel
    {
        public int? seller_id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public DateTime birth { get; set; }
    }
}
