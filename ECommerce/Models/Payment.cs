namespace ECommerce.Models
{
    public class Payment
    {
        private int _paymentId { get; set; }
        private DateTime _paymentDate { get; set; }
        private string _paymentType { get; set; }
        private decimal _amount { get; set; }
        private User _user { get; set; }
        private Order _order { get; set; }
    }
}
