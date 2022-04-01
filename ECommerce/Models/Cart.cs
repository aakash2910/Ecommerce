using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        public List<CartDetail> CartDetail { get; set; }
    }
}
