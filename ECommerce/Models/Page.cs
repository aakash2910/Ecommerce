using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Page
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(2,ErrorMessage = "Minimum length is 2") ]
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public int Sorting { get; set; }
    }
}
