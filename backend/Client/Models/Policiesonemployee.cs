using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Models
{
    public partial class Policiesonemployee
    {
        public string EmpId { get; set; }
        public int PolicyId { get; set; }
        public string Policyname { get; set; }
        public decimal Policyamount { get; set; }
        public decimal Policyduration { get; set; }
        public decimal Emi { get; set; }
        public DateTime Tartdate { get; set; }
        public DateTime Enddate { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Medical { get; set; }

        public virtual Policy Policy { get; set; }
    }
}
