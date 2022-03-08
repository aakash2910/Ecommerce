namespace ECommerce.Models
{
    public class CartDetails
    {
        private int _cartDetailId { get; set; }
        private Cart _cart { get; set; }
        private Product _product { get; set; }
    }
}
