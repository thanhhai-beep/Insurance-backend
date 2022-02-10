using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class PolicyRequestDetail
    {
        public int Id { get; set; }
        public DateTime? RequestDate { get; set; }
        public int Empno { get; set; }
        public int? PolicyId { get; set; }
        public string Policyname { get; set; }
        public decimal? PolicyAmount { get; set; }
        public decimal? Emi { get; set; }
        public int? CompanyId { get; set; }
        public string Companyname { get; set; }
        public string Status { get; set; }
    }
}
