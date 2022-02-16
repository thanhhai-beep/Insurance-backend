using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace backend.Models
{
    public partial class UserLogin
    {
        [Key]
        public int id { get; set; }
        public string Username { get; set; }
        public string PassWord { get; set; }
        public bool? Roles { get; set; }
        public int empid { get; set; }
    }
}
