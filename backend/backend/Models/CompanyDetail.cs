using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace backend.Models
{
    public partial class CompanyDetail
    {
        public CompanyDetail()
        {
            Employees = new HashSet<Employee>();
            Policies = new HashSet<Policy>();
            RequestDetails = new HashSet<RequestDetail>();
            TotalDescriptions = new HashSet<TotalDescription>();
        }

        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string CompanyUrl { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
        public virtual ICollection<TotalDescription> TotalDescriptions { get; set; }
    }
}
