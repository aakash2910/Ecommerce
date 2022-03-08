namespace ECommerce.Models
{
    public class WishList
    {
        public int WishListId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
