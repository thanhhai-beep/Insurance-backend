using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace backend.Models
{
    public partial class PolicyTotalDescriptions
    {
        [Key]
        public int Id { get; set; }
        public string Policyname { get; set; }
        public string PolicyDesc { get; set; }
        public int? PolicydurationinMonths { get; set; }
        public string Companyname { get; set; }
    }
}