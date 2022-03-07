namespace ECommerce.Models
{
    public class Account
    {
        private User _user { get; set; }
        private int _accountId { get; set; }    
        private string _userName { get; set; }
        private string _password { get; set; }
        private string _securityQuestion { get; set; }
        private string _securityAnswer { get; set; }
        private string _passwordRecoveryEmail { get; set; }
        private DateTime _created { get; set; }
    }
}
