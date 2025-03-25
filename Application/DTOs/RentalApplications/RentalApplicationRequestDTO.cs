namespace Application.DTOs.RentalApplications
{
    public class RentalApplicationRequestDTO
    {
        public int ProductId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int RequesterUserId { get; set; }
        public int ProductOwnerUserId { get; set; }
        public int StatusId { get; set; }
    }
}
