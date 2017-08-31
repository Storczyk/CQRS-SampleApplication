using CQRS.DataAccessLayer.Abstract;
using CQRS.DataAccessLayer.Contracts.Queries;
using CQRS.Models.Models;
using CQRS.Models.ViewModels.Product;

namespace CQRS.DataAccessLayer.Handlers.QueryHandlers
{
    public class GetByNameProductQueryHandler : IQueryHandler<GetByNameProductQuery, Product>
    {
        private readonly IProductRepository repository;
        public GetByNameProductQueryHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public Product Handle(GetByNameProductQuery query)
        {
            return repository.GetByName(query.Name);
        }
    }
}
