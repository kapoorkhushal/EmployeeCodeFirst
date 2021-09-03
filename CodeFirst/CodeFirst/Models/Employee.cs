using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Employee
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public System.DateTime DOB { get; set; }
        [Required]
        public System.DateTime DOJ { get; set; }
        [Required]
        public string Address { get; set; }

        public int? DepartmentID { get; set; }

        public string IsActive { get; set; }
        public Department department { get; set; }

    }
}