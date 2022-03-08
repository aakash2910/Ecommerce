namespace ECommerce.Models
{
    public class CartDetails
    {
        public int CartDetailId { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
