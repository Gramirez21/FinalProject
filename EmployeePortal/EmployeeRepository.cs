using Dapper;
using EmployeePortal.Models;
using System.Data;
using Testing;

namespace EmployeePortal
{
    public class EmployeeRepository: IEmployeeRepository
    {

        private readonly IDbConnection _conn;

        public EmployeeRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _conn.Query<Employee>("SELECT * FROM EMPLOYEES;");
        }

        public Employee GetEmployee(int id)
        {
            return _conn.QuerySingle<Employee>("SELECT * FROM Employees WHERE EmployeeID = @id", new { id = id });
        }

        public void UpdateEmployee(Employee employee)
        {
            _conn.Execute("UPDATE employees SET EmployeeID = @id, FirstName = @firstname, LastName = @lastname, Email = @email,Department = @department,Salary = @salary  WHERE EmployeeID = @id",
             new { id = employee.EmployeeID, firstname = employee.FirstName,lastname = employee.LastName, email = employee.Email,department = employee.Department, salary = employee.Salary  });
        }


        public IEnumerable<Department> GetCategories()
        {
            return _conn.Query<Department>("SELECT * FROM Department;");
        }


        public void InsertEmployee(Employee employeeToInsert)
        {
            _conn.Execute("INSERT INTO employees (EmployeeID, FirstNAME, LastName, Email,Department, Salary, DateHired) VALUES (@employeeid, @name, @last, @email, @department, @salary, @datehired);",
                new { employeeid = employeeToInsert.EmployeeID, name = employeeToInsert.FirstName, last = employeeToInsert.LastName, email = employeeToInsert.Email, department = employeeToInsert.Department, salary = employeeToInsert.Salary, datehired = employeeToInsert.DateHired });
        }

        public Employee AssignDepartment()
        {
            var categoryList = GetCategories();
            var product = new Employee();
            product.DepartmentName = categoryList;
            return product;
        }

        public void DeleteEmployee(Employee employee)
        {
            _conn.Execute("DELETE FROM Employees WHERE EmployeeID = @id;", new { id = employee.EmployeeID });
           
        }

    }
}
