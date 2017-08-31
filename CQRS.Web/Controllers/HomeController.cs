using Microsoft.AspNetCore.Mvc;
using CQRS.DataAccessLayer.Abstract;
using CQRS.DataAccessLayer.Contracts.Commands;
using CQRS.DataAccessLayer.Contracts.Queries;
using CQRS.Models.Models;
using CQRS.Models.ViewModels.Product;

namespace CQRC.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ICommandBus commandBus, IQueryDispatcher queryDispatcher) : base(commandBus, queryDispatcher)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("product")]
        public IActionResult AddProduct([FromBody] AddProductCommand command)
        {
            commandBus.Send(command);
            return Ok(queryDispatcher.Dispatch<GetByNameProductQuery, Product>(new GetByNameProductQuery { Name = command.Name }));
        }

        [HttpPut, Route("product")]
        public IActionResult UpdateProduct([FromBody] UpdateProductCommand command)
        {
            commandBus.Send(command);
            return Ok(queryDispatcher.Dispatch<GetByNameProductQuery, Product>(new GetByNameProductQuery { Name = command.Name }));
        }
        [HttpGet,Route("product/{id}")]
        public IActionResult GetProductDetails(string id)
        {
            var query = new GetProductDetailsQuery { Id = id };
            return Ok(queryDispatcher.Dispatch<GetProductDetailsQuery, ProductDetailsViewModel>(query));
        }

        [HttpGet, Route("products/{name}")]
        public IActionResult GetProductByName(string name)
        {
            var query = new GetByNameProductQuery { Name = name };
            return Ok(queryDispatcher.Dispatch<GetByNameProductQuery, Product>(query));
        }

        [HttpGet, Route("products")]
        public IActionResult GetProducts(int page = 1, int pageSize = 10)
        {
            var query = new GetProductsQuery { Page = page, PageSize = pageSize };
            return Ok(queryDispatcher.Dispatch<GetProductsQuery, ProductListViewModel>(query));
        }
    }
}
