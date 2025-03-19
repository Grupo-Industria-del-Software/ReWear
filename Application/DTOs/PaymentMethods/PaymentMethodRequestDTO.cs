namespace Application.DTOs.PaymentMethods
{
    public class PaymentMethodRequestDTO
    {
        public string Name { get; set; }  = string.Empty;
        public bool IsActive { get; set; } 
    }
}
