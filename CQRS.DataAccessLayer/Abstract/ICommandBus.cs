namespace CQRS.DataAccessLayer.Abstract
{
    public interface ICommandBus
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
