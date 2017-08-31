using CQRS.DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CQRC.Controllers
{
    public class BaseController:Controller
    {
        protected ICommandBus commandBus;
        protected IQueryDispatcher queryDispatcher;
        public BaseController(ICommandBus bus, IQueryDispatcher queryDispatcher)
        {
            this.commandBus = bus;
            this.queryDispatcher = queryDispatcher;
        }
    }
}
