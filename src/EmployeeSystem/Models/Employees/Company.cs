using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSystem.Models.Employees
{
    public class Company
    {
        private List<Employee> employees = new List<Employee>();

        public List<Employee> Employees
        {
            get { return employees; }
        }

        public void AddEmployee(Employee employee)
        {
            Console.Clear();
            employees.Add(employee);
            Console.WriteLine($"Employee {employee.FirstName} Added");
        }

        public void RemoveEmployee(string id)
        {
            foreach (Employee employee in employees)
            {
                if (employee.EmployeeId == id)
                    Employees.Remove(employee);
            }

        }

        public List<Employee>? DisplayEmployees(List<Employee> employees)
        {
            if (employees.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No Employees\n");

                return null;
            }
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"Employee ID: {employee.EmployeeId}");
                Console.WriteLine($"First Name: {employee.FirstName}");
                Console.WriteLine($"Last Name: {employee.LastName}");
                Console.WriteLine($"Email: {employee.Email}");
                Console.WriteLine($"Date of Birth: {employee.DateOfBirth.ToShortDateString()}");
                if (employee is FullTimeEmployee)
                {
                    FullTimeEmployee fullTimeEmployee = (FullTimeEmployee)employee;
                    Console.WriteLine($"Monthly Salary: {fullTimeEmployee.MonthlySalary}");
                }
                else if (employee is PartTimeEmployee)
                {
                    PartTimeEmployee partTimeEmployee = (PartTimeEmployee)employee;
                    Console.WriteLine($"Hourly Salary: {partTimeEmployee.HourlySalary}");
                }
                Console.WriteLine();
            }
            return employees;
            Console.ReadLine();

        }

        public Employee? GetEmployeeById()
        {
            Console.Write("Enter employee ID to calculate: ");
            string id = Console.ReadLine();
            Employee employee = Employees.Find(e => e.EmployeeId == id);
            if (employee == null)
            {
                Console.WriteLine("No employee with that id");
                return null;
            }
            return employee;

        }
    }
}