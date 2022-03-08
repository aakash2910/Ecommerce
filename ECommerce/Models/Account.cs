namespace ECommerce.Models
{
    public class Account
    {
        public User User { get; set; }
        public int AccountId { get; set; }    
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public string PasswordRecoveryEmail { get; set; }
        public DateTime Created { get; set; }
    }
}
