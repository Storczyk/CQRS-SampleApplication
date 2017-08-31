using CQRS.DataAccessLayer.Abstract;
using System;

namespace CQRS.DataAccessLayer.Contracts.Events
{
    public class ProductAddedEvent : IEvent
    {
        public ProductAddedEvent()
        {
            Id = Guid.NewGuid();
            CreatedTime = DateTime.Now;
        }
        public ProductAddedEvent(Guid productId, string name, string description, decimal price) : this()
        {
            AggregateRoot = productId;
            Name = name;
            Description = description;
            Price = price;
        }
        public Guid Id { get; }
        public Guid AggregateRoot { get; }

        public DateTime CreatedTime { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }

    }
}
