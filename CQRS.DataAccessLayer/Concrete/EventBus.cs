using Autofac;
using CQRS.DataAccessLayer.Abstract;

namespace CQRS.DataAccessLayer.Concrete
{
    public class EventBus:IEventBus
    {
        private readonly IComponentContext context;

        public EventBus(IComponentContext context)
        {
            this.context = context;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var handler = context.Resolve<IEventHandler<TEvent>>();

            handler.Handle(@event);
        }
    }
}
