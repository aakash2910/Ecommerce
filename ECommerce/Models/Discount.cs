using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }
        public string Name { get; set;}

        public string Description { get; set;}

        public decimal Percentage { get; set; }

        public List<Product> Products { get; set; }
    }
}
