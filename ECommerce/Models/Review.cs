namespace ECommerce.Models
{
    public class Review
    {
        private int _reviewId { get; set; }
        private string _title { get; set; }
        private DateTime _reviewDate { get; set; }
        private int _reviewCount { get; set; } 
        private string _reviewDetail { get; set; }
        private byte _rating { get; set; }

    }
}
