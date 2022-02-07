using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int empId { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string address { get; set; }
        public string Phone { get; set; }
        public int age { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime birthday { get; set; }
        public float salary { get; set; }
        public int role { get; set; }

    }
}
