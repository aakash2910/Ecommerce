namespace ECommerce.Models
{
    public class Cart
    {
        public int CartId { get; set; }

        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}
