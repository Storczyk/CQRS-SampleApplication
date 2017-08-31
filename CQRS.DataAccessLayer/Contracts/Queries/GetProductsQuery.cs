using CQRS.DataAccessLayer.Abstract;
using CQRS.Models.ViewModels.Product;
using System.Collections.Generic;

namespace CQRS.DataAccessLayer.Contracts.Queries
{
    public class GetProductsQuery:IQuery<ProductListViewModel>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
