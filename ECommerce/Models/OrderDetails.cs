namespace ECommerce.Models
{
    public class OrderDetails
    {
        private int _orderDetailId { get; set; }
        private Product _product { get; set; }
        private Order _order { get; set; }
        private int _quantity { get; set; }
        private decimal _unitPrice { get; set; }
        private Discount _discount { get; set; }
    }
}
