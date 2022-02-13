using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Aggregates.SellerAggregate
{
    public interface ISellerRepository
    {
        Task<int> Register(Seller seller);
    }
}
