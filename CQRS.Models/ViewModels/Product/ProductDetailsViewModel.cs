using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Models.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public string Id { get; set; }

        public IEnumerable<ProductDetailViewModel> History { get; set; }
    }
}
