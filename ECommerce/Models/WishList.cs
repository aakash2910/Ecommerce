namespace ECommerce.Models
{
    public class WishList
    {
        public int WishListId { get; set; }
        
        public List<WishListDetail> WishListDetails { get; set; }
    }
}
