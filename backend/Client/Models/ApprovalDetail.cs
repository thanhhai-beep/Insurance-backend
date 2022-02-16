using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Models
{
    public partial class ApprovalDetail
    {
        public int Id { get; set; }
        public int? EmpId { get; set; }
        public int? RequestId { get; set; }
        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
        public string Reason { get; set; }
    }
}
