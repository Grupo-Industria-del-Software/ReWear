namespace Application.DTOs.PaymentMethods
{
    public class PaymentMethodDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }   = string.Empty;
        public bool IsActive { get; set; }
    }
}