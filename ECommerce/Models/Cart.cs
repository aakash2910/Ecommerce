namespace ECommerce.Models
{
    public class Cart
    {
        private int _cartID { get; set; }

        private User _user { get; set; }
        private List<Product> products { get; set; }
    }
}
