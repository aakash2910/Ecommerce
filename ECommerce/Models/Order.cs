using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }

        [ForeignKey("AccountId")]
        public Account Accounts { get; set; }

        [ForeignKey("PaymentId")]
        public Payment Payments { get; set; }   
        
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
