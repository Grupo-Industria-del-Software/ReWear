namespace Application.DTOs.PaymentMethods
{
    public class PaymentMethodRequestDto
    {
        public string Name { get; set; }  = string.Empty;
        public bool IsActive { get; set; } 
    }
}
