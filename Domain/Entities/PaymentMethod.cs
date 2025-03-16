using Domain.Common;

namespace Domain.Entities
{
    public class PaymentMethod : Entity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public PaymentMethod(string name, bool isActive = true)
        {
            Name = name;
            IsActive = isActive;
        }
    }
}
