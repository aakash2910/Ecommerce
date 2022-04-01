using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }    
    }
}
