using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Models
{
    public partial class RequestDetail
    {
        public int Id { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? EmpId { get; set; }
        public int? PolicyId { get; set; }
        public int? CompanyId { get; set; }
        public bool? Status { get; set; }
    }
}
