using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace backend.Models
{
    public partial class PolicyRequestDetails
    {
        [Key]
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RequestDate { get; set; }
        public int Empno { get; set; }
        public int? PolicyId { get; set; }
        public string Policyname { get; set; }
        public int? CompanyId { get; set; }
        public string Companyname { get; set; }
        [DefaultValue("0")]
        public string Status { get; set; }
    }
}
