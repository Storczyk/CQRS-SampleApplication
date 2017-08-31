using CQRS.DataAccessLayer.Abstract;
using CQRS.Models.Models;
namespace CQRS.DataAccessLayer.Contracts.Queries
{
    public class GetByNameProductQuery:IQuery<Product>
    {
        public string Name { get; set; }
    }
}
