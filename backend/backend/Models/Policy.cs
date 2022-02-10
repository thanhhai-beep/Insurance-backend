using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Policy
    {
        public Policy()
        {
            Policiesonemployees = new HashSet<Policiesonemployee>();
        }

        public int Id { get; set; }
        public string Policyname { get; set; }
        public string Policydesc { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Emi { get; set; }
        public int? Companyid { get; set; }
        public string Medicalid { get; set; }

        public virtual ICollection<Policiesonemployee> Policiesonemployees { get; set; }
    }
}
