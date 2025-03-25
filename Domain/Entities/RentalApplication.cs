using Domain.Common;
using Domain.AggregateRoots.Products;

namespace Domain.Entities
{
    public class RentalApplication : Entity
    {
        public int RequesterUserId { get; set; }
        public User? RequesterUser { get; set; }
        public int ProductOwnerUserId { get; set; }
        public User? ProductOwnerUser { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int RentalDays => (EndDate.DayNumber - StartDate.DayNumber);
        public decimal TotalPrice { get; set; }
        public int StatusId { get; set; }
        public RentalApplicationStatus? Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        private RentalApplication() { }
        public RentalApplication( int requesterUserId, int productOwnerUserId, int productId, DateOnly startDate, DateOnly endDate, decimal totalPrice, int statusId)
        {
            RequesterUserId = requesterUserId;
            ProductOwnerUserId = productOwnerUserId;
            ProductId = productId;
            StartDate = startDate;
            EndDate = endDate;
            TotalPrice = totalPrice;
            StatusId = statusId;
        }

    }
}