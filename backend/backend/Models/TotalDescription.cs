using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class TotalDescription
    {
        public int Id { get; set; }
        public int? PolicyId { get; set; }
        public string PolicyDesc { get; set; }
        public int? PolicydurationinMonths { get; set; }
        public int? CompanyId { get; set; }
    }
}
