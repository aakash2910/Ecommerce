using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public DateTime ReviewDate { get; set; }
        public int ReviewCount { get; set; } 
        public string ReviewDetail { get; set; }
        public byte Rating { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
