namespace EmployeePortal.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Salary { get; set; }

        public string DateHired { get; set; }

        public IEnumerable<Department> DepartmentName { get; set; }

    }
}
