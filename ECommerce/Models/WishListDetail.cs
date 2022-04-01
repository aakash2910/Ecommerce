using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class WishListDetail
    {
        [Key]
        public int WishListDetailId { get; set; }
        
        [ForeignKey("WishListId")]
        public WishList WishList { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
