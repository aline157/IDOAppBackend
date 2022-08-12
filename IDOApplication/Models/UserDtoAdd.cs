using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDOApplication.Models
{
    public class UserDtoAdd
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string ComfirmPassword { get; set; }
    }
}
