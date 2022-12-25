﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace virtualReality.ViewModels.UsersVM
{
    public class EditUsersVM
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public IdentityRole Role { get; set; }

        public IEnumerable<EditRoleVM> Roles { get; set; }
    }
}
