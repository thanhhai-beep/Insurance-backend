using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string Fname { get; set; }
        public string Password { get; set; }
        public string Lname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int? PolicyId { get; set; }
        public int? CompanyId { get; set; }
        public string Image { get; set; }
        public int? IsAdmin { get; set; }
    }
}
