namespace ECommerce.Models
{
    public class Address
    {
        public string AddressId { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public User User { get; set; }

    }
}
