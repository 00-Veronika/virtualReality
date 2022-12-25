using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace virtualReality.ViewModels.UsersVM
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        //админ или продавач
        
    }
}
