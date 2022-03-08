namespace ECommerce.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
        public User User { get; set; }
        public Order Order { get; set; }
    }
}
