using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Policy
    {
        public int Id { get; set; }
        public string PolicyName { get; set; }
        public string PolicyDesc { get; set; }
        public int? CompanyId { get; set; }
    }
}
