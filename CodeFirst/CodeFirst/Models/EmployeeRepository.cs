using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class EmployeeRepository
    {
        public int AddEmployee(EmployeeProjectMapping employeeProjectMapping)
        {
            using (var context = new EmployeeContext())
            {
                EmployeeProjectMapping employee = new EmployeeProjectMapping()
                {
                    IsActive = employeeProjectMapping.IsActive
                };
                if (employeeProjectMapping.employee != null)
                {
                    employee.employee = new Employee()
                    {
                        FirstName = employeeProjectMapping.employee.FirstName,
                        LastName = employeeProjectMapping.employee.LastName,
                        DOB = employeeProjectMapping.employee.DOB,
                        DOJ = employeeProjectMapping.employee.DOJ,
                        Address = employeeProjectMapping.employee.Address,
                        IsActive = employeeProjectMapping.IsActive

                    };
                }

                if (employeeProjectMapping.project != null)
                {
                    employee.project = new Project()
                    {
                        Name = employeeProjectMapping.project.Name,
                        AccountName = employeeProjectMapping.project.AccountName,
                    };
                }

                if (employeeProjectMapping.employee.department != null)
                {
                    employee.employee.department = new Department()
                    {
                        Name = employeeProjectMapping.employee.department.Name,
                        Description = employeeProjectMapping.employee.department.Description,
                    };
                }

                context.EmployeeProjectMapping.Add(employee);
                context.SaveChanges();
                return employee.Id;
            }
        }
        public List<Employee> GetEmployeesDOJ()
        {
            using (var context = new EmployeeContext())
            {
                var result = context.Employee.
                            Where(x => x.DOJ > new DateTime(2019, 01, 01));
                             
                return result.ToList();
            }
        }
        public List<Employee> GetEmployeesHR()
        {
            using (var context = new EmployeeContext())
            {
                var result = context.Employee.
                            Where(x => x.department.Name == "HR" && x.DepartmentID == x.department.Id);

                return result.ToList();
            }
        }
        public List<Employee> GetEmployeeBasedProject(string ProjectName = "ABC")
        {
            using (var context = new EmployeeContext())
            {
                var detail = context.Project.FirstOrDefault(x => x.Name.Equals(ProjectName));
                var ID = context.EmployeeProjectMapping
                    .Where(x => x.ProjectId == detail.Id).Select(x => x.EmployeeId).ToList();
                var Employees = (from d in context.Employee where ID.Contains(d.Id) select d).ToList();

                return Employees.ToList();
            }
        }
        public List<Department> GetEmployeeBasedDepartmentName(string ProjectName = "ABC")
        {
            using (var context = new EmployeeContext())
            {
                var detail = context.Project.FirstOrDefault(x => x.Name.Equals(ProjectName));
                var ID = context.EmployeeProjectMapping
                    .Where(x => x.ProjectId == detail.Id).Select(x => x.EmployeeId).ToList();
                var DepartName = (from d in context.Employee where ID.Contains(d.Id) select d.DepartmentID).ToList();
                var Dept = (from d in context.Department where DepartName.Contains(d.Id) select d).ToList();

                return Dept.ToList();
            }
        }
    }
}