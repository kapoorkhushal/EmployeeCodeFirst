using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class EmployeeProjectMapping
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? ProjectId { get; set; }
        public string IsActive { get; set; }

        public Employee employee { get; set; }
        public Project project { get; set; }
    }
}