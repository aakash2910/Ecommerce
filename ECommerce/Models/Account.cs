using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }    
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public string PasswordRecoveryEmail { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public short Age { get; set; }
        public int PhoneNumber { get; set; }

        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public DateTime Created { get; set; }

        public List<Order> Orders { get; set; }
        public List<Review> Reviews { get; set; }
        public Cart Cart { get; set; }
        
    }
}
