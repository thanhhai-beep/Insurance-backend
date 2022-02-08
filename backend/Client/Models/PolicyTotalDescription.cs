using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Models
{
    public partial class PolicyTotalDescription
    {
        public int Id { get; set; }
        public string Policyname { get; set; }
        public string Policydes { get; set; }
        public decimal? Policyamount { get; set; }
        public decimal? Emi { get; set; }
        public int? PolicydurationinMonths { get; set; }
        public string Companyname { get; set; }
        public string Medicalid { get; set; }
    }
}
