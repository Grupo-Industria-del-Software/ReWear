using System.Linq.Expressions;
using Domain.AggregateRoots.Orders;

namespace Application.Specifications;

public class OrderSpecification:BaseSpecification<Order>
{
    public OrderSpecification(
        
        DateTime? date = null,
        int? orderStatusId = null
        
    ) : base(o => 
        (!date.HasValue || o.CreatedAt.Date == date.Value.Date) &&
        (!orderStatusId.HasValue || o.OrderStatusId == orderStatusId)
    )
    {
    }
}