using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Orders
{
    public class OrderResponseDTO
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public required string ProviderName { get; set; }
        public int CustomerId { get; set; }
        public required string CustomerName { get; set; }
        public int OrderStatus { get; set; }
        public required string OrderStatusName { get; set; }
        public required List<OrderItemResponseDTO> OrderItems { get; set; } = new();
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
