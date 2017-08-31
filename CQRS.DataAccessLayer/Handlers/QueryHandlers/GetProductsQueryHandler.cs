using CQRS.DataAccessLayer.Abstract;
using CQRS.DataAccessLayer.Contracts.Queries;
using CQRS.Models.ViewModels.Product;
using System.Collections.Generic;

namespace CQRS.DataAccessLayer.Handlers.QueryHandlers
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, ProductListViewModel>
    {
        private readonly IProductRepository repository;
        public GetProductsQueryHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ProductListViewModel Handle(GetProductsQuery query)
        {
            return repository.GetProducts(query.Page, query.PageSize);
        }
    }
}
