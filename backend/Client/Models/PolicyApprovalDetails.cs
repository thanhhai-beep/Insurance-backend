using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Client.Models
{
    public partial class PolicyApprovalDetails
    {
        [Key]
        public int Id { get; set; }
        public int? RequestId { get; set; }
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        public string Status { get; set; }
    }
}
