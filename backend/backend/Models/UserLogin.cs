using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace backend.Models
{
    public partial class UserLogin
    {
        [Key]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        public bool? Roles { get; set; }
    }
}
