using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
        
        public Order Orders { get; set; }
    }
}
