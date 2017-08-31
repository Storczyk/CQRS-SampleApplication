using CQRS.DataAccessLayer.Abstract;
using CQRS.DataAccessLayer.Contracts.Commands;
using CQRS.Models.Models;
using Moq;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void ProductRepository_ShouldReturnProductByName()
        {
            var repository = new Mock<IProductRepository>();
            var product = new Product { Id = Guid.NewGuid().ToString(), Description = "asddsa", Name = "test1", Price = 2 };

            repository.Setup(i => i.GetByName("test1")).Returns(product);

            Assert.Equal(product, repository.Object.GetByName("test1"));
        }
    }
}
