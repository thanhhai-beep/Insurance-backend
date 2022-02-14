using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace backend.Models
{
    public partial class Employee
    {
        public Employee()
        {
            ApprovalDetails = new HashSet<ApprovalDetail>();
            Feedbacks = new HashSet<Feedback>();
            RequestDetails = new HashSet<RequestDetail>();
        }

        [Key]
        public int EmpId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int? PolicyId { get; set; }
        public int? CompanyId { get; set; }
        public string Image { get; set; }
        public bool? IsAdmin { get; set; }

        public virtual CompanyDetail Company { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual ICollection<ApprovalDetail> ApprovalDetails { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
    }
}
