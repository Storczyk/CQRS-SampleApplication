namespace CQRS.DataAccessLayer.Abstract
{
    public interface IQueryHandler
    {
    }
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
