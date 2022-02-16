﻿using System;
using System.Collections.Generic;
namespace backend.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Date { get; set; }
        public int? EmpId { get; set; }
    }
}
