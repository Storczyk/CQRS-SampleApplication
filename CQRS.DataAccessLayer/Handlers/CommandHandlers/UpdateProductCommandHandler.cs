using CQRS.DataAccessLayer.Abstract;
using CQRS.DataAccessLayer.Contracts.Commands;
using CQRS.DataAccessLayer.Contracts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.DataAccessLayer.Handlers.CommandHandlers
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly IProductRepository repository;
        private readonly IEventBus eventBus;
        public UpdateProductCommandHandler(IProductRepository repository, IEventBus eventBus)
        {
            this.repository = repository;
            this.eventBus = eventBus;
        }
        public void Handle(UpdateProductCommand command)
        {
            repository.UpdateProduct(command.Id, command.Name, command.Description, command.Price);
            eventBus.Publish(new ProductUpdatedEvent(command.Id, command.Name, command.Description, command.Price));
        }
    }
}
