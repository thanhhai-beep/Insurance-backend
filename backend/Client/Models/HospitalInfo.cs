using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Client.Models
{
    public partial class HospitalInfo
    {
        [Key]
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }
    }
}
