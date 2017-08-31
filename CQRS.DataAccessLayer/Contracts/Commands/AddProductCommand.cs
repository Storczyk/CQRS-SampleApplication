using CQRS.DataAccessLayer.Abstract;

namespace CQRS.DataAccessLayer.Contracts.Commands
{
    public class AddProductCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
