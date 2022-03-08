namespace ECommerce.Models
{
    public class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Discount Discount { get; set; }
    }
}
