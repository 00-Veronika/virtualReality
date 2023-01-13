using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace virtualReality.ViewModels
{
    public class RegistrationVM
    {

        [DisplayName("Email: ")]
        [Required(ErrorMessage = nameof(Email) + FieldConstants.REQUIRED)]
        public string Email { get; set; }

        [DisplayName("First Name: ")]
        [Required(ErrorMessage = nameof(FirstName) + FieldConstants.REQUIRED)]
        public string FirstName { get; set; }

        [DisplayName("Last Name: ")]
        [Required(ErrorMessage = nameof(LastName) + FieldConstants.REQUIRED)]
        public string LastName { get; set; }

        [DisplayName("Password: ")]
        [Required(ErrorMessage = nameof(Password) + FieldConstants.REQUIRED)]
        public string Password { get; set; }

        [DisplayName("Phone: ")]
        [Required(ErrorMessage = nameof(Phone) + FieldConstants.REQUIRED)]
        public string Phone { get; set; }

        [DisplayName("Username: ")]
        [Required(ErrorMessage = nameof(Username) + FieldConstants.REQUIRED)]
        public string Username { get; set; }
    }
}
