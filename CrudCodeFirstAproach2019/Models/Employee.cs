using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;           
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudCodeFirstAproach2019.Models
{
    [Table("CrudCodeFirstAproach")]
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
    }
}