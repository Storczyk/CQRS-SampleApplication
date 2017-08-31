using CQRS.Models.Models;
using CQRS.Models.ViewModels.Product;
using System;
using System.Collections.Generic;

namespace CQRS.DataAccessLayer.Abstract
{
    public interface IProductRepository
    {
        void AddNewProduct(Guid id, string name, string description, decimal price);
        void UpdateProduct(Guid id, string name, string description, decimal price);
        Product GetByName(string name);
        ProductListViewModel GetProducts(int page, int pageSize);
        ProductDetailsViewModel GetProductDetails(string id);
    }
}
