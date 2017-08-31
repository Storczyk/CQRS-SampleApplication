using CQRS.DataAccessLayer.Abstract;
using CQRS.Models.Models;
using CQRS.Models.ViewModels.Product;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CQRS.DataAccessLayer.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly string connectionString;
        public IDbConnection Connection { get { return new SqlConnection(connectionString); } }

        public ProductRepository()
        {
            connectionString = "Server=.;Database=dapper;User Id=test;Password=test;MultipleActiveResultSets=True";
        }

        public void AddNewProduct(Guid guid, string name, string description, decimal price)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO dbo.Products (Id, Name, Description, Price)" +
                    "VALUES(@id, @name, @description, @price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { id = guid, name, description, price });
            }
        }

        public void UpdateProduct(Guid id, string name, string description, decimal price)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE dbo.Products SET Name=@name, Description=@description, Price=@price" +
                    " WHERE Id = @id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { id, name, description, price });
            }
        }

        public Product GetByName(string name)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM dbo.Products WHERE Name=@name";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery, new { name }).FirstOrDefault();
            }
        }

        public ProductListViewModel GetProducts(int page, int pageSize)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM dbo.Products ORDER BY Name OFFSET @Page ROWS FETCH NEXT @PageSize ROWS ONLY";
                dbConnection.Open();
                var list =  dbConnection.Query<Product>(sQuery, new { Page = pageSize * (page - 1), PageSize = pageSize })
                    .Select(i => new ProductViewModel {Id = i.Id, Description = i.Description, Name = i.Name, Price = i.Price});
                var productListViewModel = new ProductListViewModel { Products = new List<ProductViewModel>() };
                productListViewModel.Products = list;
                productListViewModel.Page = page;
                string countQuery = "SELECT COUNT(Id) FROM dbo.Products";
                productListViewModel.Pages = (int)Math.Ceiling(dbConnection.Query<decimal>(countQuery).First() / pageSize);
                return productListViewModel;
            }
        }

        public ProductDetailsViewModel GetProductDetails(string id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sQuery = "Select CreatedTime, Name, Description, Price FROM dbo.ProductEvents WHERE ProductId=@Id";
                dbConnection.Open();
                var list = dbConnection.Query<ProductDetailViewModel>(sQuery, new { Id = id });
                var productDetailsViewModel = new ProductDetailsViewModel { History = new List<ProductDetailViewModel>() };
                productDetailsViewModel.Id = id;
                productDetailsViewModel.History = list.OrderByDescending(i => i.CreatedTime);
                return productDetailsViewModel;
            }
        }
    }
}
