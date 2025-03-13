using Domain.Common;

namespace Domain.Entities
{
    public class OrderType: Entity
    {
        public string Type { get; set; }
        public OrderType(string type)
        {
            Type = type;
        }
    }
}