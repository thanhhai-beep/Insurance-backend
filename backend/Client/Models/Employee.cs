using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Client.Models
{
    public partial class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public int PolicyId { get; set; }
        public string Policyname { get; set; }
        public decimal Policyduration { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime EndDate { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Image { get; set; }

        public virtual Policy Policy { get; set; }
    }
}
