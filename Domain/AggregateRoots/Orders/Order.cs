using Domain.Common;
using Domain.Entities;

namespace Domain.AggregateRoots.Orders
{
    public class Order : AggregateRoot
    {
        public int ProviderId { get; set; }   
        public User? Provider { get; set; }
        public int CustomerId { get; set; }
        public User? Customer { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
