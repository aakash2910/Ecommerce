namespace ECommerce.Models
{
    public class WishList
    {
        private int wishListId { get; set; }
        private User _user { get; set; }
        private Product _product { get; set; }
    }
}
