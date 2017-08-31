using CQRS.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.DataAccessLayer.Contracts.Events
{
    public class ProductUpdatedEvent : IEvent
    {
        public ProductUpdatedEvent()
        {
            Id = Guid.NewGuid();
            CreatedTime = DateTime.Now;
        }
        public ProductUpdatedEvent(Guid productId, string name, string description, decimal price) : this()
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
