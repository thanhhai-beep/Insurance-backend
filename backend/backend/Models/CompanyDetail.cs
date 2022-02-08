using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class CompanyDetail
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string CompanyUrl { get; set; }
    }
}
