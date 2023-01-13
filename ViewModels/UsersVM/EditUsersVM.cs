using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace virtualReality.ViewModels.UsersVM
{
    public class EditUsersVM
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public int Id { get; set; }

        public string LastName { get; set; }
        public string Password { get; set; }
        public IdentityRole Role { get; set; }
        public IEnumerable<EditRoleVM> Roles { get; set; }
        public string Username { get; set; }
    }
}
