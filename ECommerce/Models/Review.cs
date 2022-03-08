namespace ECommerce.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public DateTime ReviewDate { get; set; }
        public int ReviewCount { get; set; } 
        public string ReviewDetail { get; set; }
        public byte Rating { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }

    }
}
