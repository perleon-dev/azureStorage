using Customer.Application.Queries.Querys;
using Customer.Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Queries.Interfaces
{
    public interface ISellerQueryHandler
    {
        Task<IEnumerable<SellerViewModel>> GetBySearch(SellerQuery query);
        Task<IEnumerable<SellerViewModel>> Search(SellerQuery query);
        Task<IEnumerable<SellerViewModel>> FindAll(SellerQuery query);
    }
}
