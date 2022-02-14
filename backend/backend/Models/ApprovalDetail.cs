﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace backend.Models
{
    public partial class ApprovalDetail
    {
        [Key]
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? RequestId { get; set; }
        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
        public string Reason { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
