using CQRS.DataAccessLayer.Abstract;
using CQRS.DataAccessLayer.Contracts.Queries;
using CQRS.Models.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.DataAccessLayer.Handlers.QueryHandlers
{
    public class GetProductDetailsQueryHandler : IQueryHandler<GetProductDetailsQuery, ProductDetailsViewModel>
    {
        private readonly IProductRepository repository;
        public GetProductDetailsQueryHandler(IProductRepository repository)
        {
            this.repository = repository;
        }
        public ProductDetailsViewModel Handle(GetProductDetailsQuery query)
        {
            return repository.GetProductDetails(query.Id);
        }
    }
}
