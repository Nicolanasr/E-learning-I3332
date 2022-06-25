using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Learning_I3332.Models
{
    public class LoginFormClass
    {
        [EmailAddress]
        public string? Email { get; set; }
        [PasswordPropertyText]
        public string? Password { get; set; }
    }
}