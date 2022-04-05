using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(2, ErrorMessage = "Minimum length is 2 characters")]
        public string Name { get; set; }
        public string? Slug { get; set; }

        [Required, MinLength(5, ErrorMessage = "Minimum length is 5 characters")]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }   

        [FileExtensions()]
        public string Image { get; set; }
        public string SKU { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "You must choose category.")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [NotMapped]
        public IFormFile ImageUpload { get; set; }



        /*[ForeignKey("DiscountId")]
        public Discount Discount { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        public List<CartDetail> CartDetails { get; set; }
        public List<WishListDetail> WishListDetails { get; set; }
        public List<Review> Reviews { get; set; }*/
    }
}
