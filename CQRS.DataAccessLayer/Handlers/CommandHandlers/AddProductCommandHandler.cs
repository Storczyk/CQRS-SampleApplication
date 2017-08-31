using CQRS.DataAccessLayer.Abstract;
using CQRS.DataAccessLayer.Contracts.Commands;
using CQRS.DataAccessLayer.Contracts.Events;
using System;

namespace CQRS.DataAccessLayer.Handlers.CommandHandlers
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand>
    {
        private readonly IProductRepository repository;
        private readonly IEventBus eventBus;
        public AddProductCommandHandler(IProductRepository repository, IEventBus eventBus)
        {
            this.repository = repository;
            this.eventBus = eventBus;
        }
        public void Handle(AddProductCommand command)
        {
            Guid guid = Guid.NewGuid();
            repository.AddNewProduct(guid ,command.Name, command.Description, command.Price);
            eventBus.Publish(new ProductAddedEvent(guid, command.Name, command.Description, command.Price));
        }
    }
}
