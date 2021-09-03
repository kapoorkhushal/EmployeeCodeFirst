using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirst.Models;

namespace CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        EmployeeContext employeeContext = new EmployeeContext();
        EmployeeRepository employeeRepository = null;

        public HomeController()
        {
            employeeRepository = new EmployeeRepository();
        }
        // GET: Home
        public ActionResult Index()
        {
            var data = employeeContext.Employee.ToList();
            return View(data);
        }
        public ActionResult IndexProject()
        {
            var data = employeeContext.Project.ToList();
            return View(data);
        }
        public ActionResult IndexDepartment()
        {
            var data = employeeContext.Department.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeProjectMapping employeeProjectMapping)
        {
            if (ModelState.IsValid)
            {
                int id = employeeRepository.AddEmployee(employeeProjectMapping);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "<script>alert('Data added Successfully !')</script>";
                }
                else
                {
                    ViewBag.IsSuccess = "<script>alert('Data added Failure !')</script>";
                }
            }
            return View();
        }

        public ActionResult Query()
        {
            return View();
        }
        public ActionResult EmployeeDOJ()
        {
            var data = employeeRepository.GetEmployeesDOJ().ToList();
            return View(data);
        }
        public ActionResult EmployeeHR()
        {
            var data = employeeRepository.GetEmployeesHR().ToList();
            return View(data);
        }
        public ActionResult EmployeeBasedProject()
        {
            var data = employeeRepository.GetEmployeeBasedProject("ABC").ToList();
            return View(data);
        }
        public ActionResult GetEmployeeBasedDepartmentName()
        {
            var data = employeeRepository.GetEmployeeBasedDepartmentName("ABC").ToList();
            return View(data);
        }

    }
}