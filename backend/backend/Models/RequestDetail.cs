using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace backend.Models
{
    public partial class RequestDetail
    {
        [Key]
        public int Id { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? EmpId { get; set; }
        public int? PolicyId { get; set; }
        public int? CompanyId { get; set; }
        public bool? Status { get; set; }

        public virtual CompanyDetail Company { get; set; }
        public virtual Employee Emp { get; set; }
        public virtual Policy Policy { get; set; }
    }
}
