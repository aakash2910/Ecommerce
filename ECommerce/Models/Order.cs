namespace ECommerce.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
        
    }
}
