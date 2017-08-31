using Autofac;
using CQRS.DataAccessLayer.Abstract;

namespace CQRS.DataAccessLayer.Concrete
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext context;
        public QueryDispatcher(IComponentContext context)
        {
            this.context = context;
        }
        public TResult Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var handler = context.Resolve<IQueryHandler<TQuery, TResult>>();

            return handler.Handle(query);
        }
    }
}
