using System;
using System.Collections.Generic;
using EmployeePortal.Models;

namespace Testing
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployee(int id);

        void UpdateEmployee(Employee employee);

        public void InsertEmployee(Employee EmployeeToInsert);

        public Employee AssignDepartment();

        public void DeleteEmployee(Employee employee);

    }
}