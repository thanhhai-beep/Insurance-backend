using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Models
{
    public partial class HospitalInfo
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string Phone { get; set; }
        public string Locationn { get; set; }
        public string Url { get; set; }
    }
}
