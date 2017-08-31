using CQRS.DataAccessLayer.Abstract;
using CQRS.Models.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.DataAccessLayer.Contracts.Queries
{
    public class GetProductDetailsQuery:IQuery<ProductDetailsViewModel>
    {
        public string Id { get; set; }
    }
}
