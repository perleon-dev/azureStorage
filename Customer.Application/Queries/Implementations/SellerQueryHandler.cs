using Customer.Application.Queries.Interfaces;
using Customer.Application.Queries.Querys;
using Customer.Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Queries.Implementations
{
    public class SellerQueryHandler : ISellerQueryHandler
    {
        public SellerQueryHandler() 
        {
        
        }


        public Task<IEnumerable<SellerViewModel>> FindAll(SellerQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SellerViewModel>> GetBySearch(SellerQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SellerViewModel>> Search(SellerQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
