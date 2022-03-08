namespace ECommerce.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public short Age { get; set; }
        public int PhoneNumber { get; set; }
        public Address Address { get; set; }    
        public Account Account { get; set; }    
          
    }
}
