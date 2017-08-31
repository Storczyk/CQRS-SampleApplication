using Autofac;
using CQRS.DataAccessLayer.Abstract;

namespace CQRS.DataAccessLayer.Concrete
{
    public class CommandBus : ICommandBus
    {
        private readonly IComponentContext context;

        public CommandBus(IComponentContext context)
        {
            this.context = context;
        }

        public void Send<TCommand>(TCommand command) where TCommand:ICommand
        {
            var handler = context.Resolve<ICommandHandler<TCommand>>();

            handler.Handle(command);
        }
    }
}
