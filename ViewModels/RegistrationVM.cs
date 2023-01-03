using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace virtualReality.ViewModels
{
    public class RegistrationVM
    {
        [DisplayName("Username: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public string Username { get; set; }

        [DisplayName("Password: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public string Password { get; set; }

        [DisplayName("Phone: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public string Phone { get; set; }

        [DisplayName("Email: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public string Email { get; set; }
    }
}
