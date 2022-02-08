using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class PolicyApprovalDetail
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
    }
}
