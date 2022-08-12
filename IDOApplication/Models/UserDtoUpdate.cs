using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDOApplication.Models
{
    public class UserDtoUpdate
    {

        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ComfirmPassword { get; set; }
    }
}
