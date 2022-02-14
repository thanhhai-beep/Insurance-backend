using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class UserLogin
    {
        public string Username { get; set; }
        public string PassWord { get; set; }
        public bool? Roles { get; set; }
    }
}
