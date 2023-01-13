using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace virtualReality.ViewModels
{
    public class LoginVM
    {
        [DisplayName("Password: ")]
        [Required(ErrorMessage = nameof(Password) + FieldConstants.REQUIRED)]
        public string Password { get; set; }

        [DisplayName("Username: ")]
        [Required(ErrorMessage = nameof(Username) + FieldConstants.REQUIRED)]
        public string Username { get; set; }
    }
}
