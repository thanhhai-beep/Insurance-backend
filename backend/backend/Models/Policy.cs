using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Policy
    {
        public Policy()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Policyname { get; set; }
        public string Policydesc { get; set; }
        public int? Companyid { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
