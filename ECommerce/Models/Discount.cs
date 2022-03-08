namespace ECommerce.Models
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string Name { get; set;}

        public string Description { get; set;}

        public decimal Percentage { get; set; }

    }
}
