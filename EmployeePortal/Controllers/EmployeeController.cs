using EmployeePortal.Models;
using Microsoft.AspNetCore.Mvc;
using Testing;

namespace EmployeePortal.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var Employees = repo.GetAllEmployees();
            return View(Employees);
        }

        public IActionResult ViewEmployee(int id)
        {
            var employee = repo.GetEmployee(id);
            return View(employee);
        }


        public IActionResult UpdateEmployee(int id)
        {
            Employee prod = repo.GetEmployee(id);
            if (prod == null)
            {
                return View("EmployeeNotFound");
            }
            return View(prod);
        }

        public IActionResult UpdateEmployeeToDatabase(Employee product)
        {
            repo.UpdateEmployee(product);

            return RedirectToAction("ViewEmployee", new { id = product.EmployeeID });
        }

        public IActionResult InsertEmployee()
        {
            var prod = repo.AssignDepartment();
            return View(prod);
        }

        public IActionResult InsertEmployeeToDatabase(Employee productToInsert)
        {
            repo.InsertEmployee(productToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmployee(Employee employee)
        {
            repo.DeleteEmployee(employee);
            return RedirectToAction("Index");
        }

    }
}
