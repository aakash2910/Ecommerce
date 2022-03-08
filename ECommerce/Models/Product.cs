namespace ECommerce.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }   
        public int Quantity { get; set; }
        public Discount Discount { get; set; }
               
    }
}
