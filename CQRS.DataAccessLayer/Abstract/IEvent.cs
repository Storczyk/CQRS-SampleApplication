using System;

namespace CQRS.DataAccessLayer.Abstract
{
    public interface IEvent
    {
        Guid AggregateRoot { get; }
        DateTime CreatedTime { get; }
    }
}
