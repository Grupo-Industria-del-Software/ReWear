using Domain.Common;
using Domain.AggregateRoots.Products;

namespace Domain.AggregateRoots.Orders
{
    public class OrderItem : Entity
    {
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal Price { get; set; }
        public DateOnly? RentalStart { get; set; }
        public DateOnly? RentalEnd { get; set; }
        public bool IsRental { get; set; }
    }
}
