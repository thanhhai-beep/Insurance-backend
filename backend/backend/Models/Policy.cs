using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace backend.Models
{
    public partial class Policy
    {
        public Policy()
        {
            Employees = new HashSet<Employee>();
            RequestDetails = new HashSet<RequestDetail>();
            TotalDescriptions = new HashSet<TotalDescription>();
        }
        [Key]
        public int Id { get; set; }
        public string PolicyName { get; set; }
        public string PolicyDesc { get; set; }
        public int? CompanyId { get; set; }

        public virtual CompanyDetail Company { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
        public virtual ICollection<TotalDescription> TotalDescriptions { get; set; }
    }
}
