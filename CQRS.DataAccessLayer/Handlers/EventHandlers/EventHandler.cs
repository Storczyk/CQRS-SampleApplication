using CQRS.DataAccessLayer.Abstract;
using CQRS.DataAccessLayer.Contracts.Events;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CQRS.DataAccessLayer.Handlers.EventHandlers
{
    public class EventHandler : IEventHandler<ProductAddedEvent>, IEventHandler<ProductUpdatedEvent>
    {
        private readonly string connectionString;
        public IDbConnection Connection { get { return new SqlConnection(connectionString); } }
        public EventHandler()
        {
            connectionString = "Server=.;Database=dapper;User Id=test;Password=test;MultipleActiveResultSets=True";
        }

        public void Handle(ProductAddedEvent @event)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO dbo.ProductEvents (Id, ProductId, CreatedTime, Name, Description, Price)" +
                    "VALUES(@id, @productId, @createdTime, @name, @description, @price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { id = @event.Id, productId = @event.AggregateRoot, createdTime = @event.CreatedTime, name = @event.Name, description = @event.Description, price = @event.Price });
            }
        }

        public void Handle(ProductUpdatedEvent @event)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO dbo.ProductEvents (Id, ProductId, CreatedTime, Name, Description, Price)" +
                    "VALUES(@id, @productId, @createdTime, @name, @description, @price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { id = @event.Id, productId = @event.AggregateRoot, createdTime = @event.CreatedTime, name = @event.Name, description = @event.Description, price = @event.Price });
            }
        }
    }
}
