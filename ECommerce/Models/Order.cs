namespace ECommerce.Models
{
    public class Order
    {
        private int _orderId { get; set; }
        private DateTime _orderDate { get; set; }
        private User _user { get; set; }
        private List<Product> _products { get; set; }
        
    }
}
