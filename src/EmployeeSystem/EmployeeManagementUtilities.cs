using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSystem.Models.Employees;

namespace EmployeeSystem
{
    public class EmployeeManagementUtilities
    {
        Company company;

        public Company Company
        {
            get { return company; }
            set { company = value; }
        }
        public EmployeeManagementUtilities(Company company)
        {
            Company = company;
        }


        public void AddEmployee()
        {
            Console.WriteLine("1. Full Time Employee");
            Console.WriteLine("2. Part Time Employee");
            string choice = Console.ReadLine();

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Date of Birth: ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter Monthly Salary");
                    int monthlySalary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Date of employment: ");
                    DateTime dateOfEmployment = Convert.ToDateTime(Console.ReadLine());
                    FullTimeEmployee fullTimeEmployee = new FullTimeEmployee(firstName, lastName, dateOfBirth, monthlySalary, dateOfEmployment);
                    company.AddEmployee(fullTimeEmployee);
                    break;
                case "2":
                    Console.WriteLine("Enter Hourly Salary");
                    int hourlySalary = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter hours worked");
                    int hoursWorked = Convert.ToInt32(Console.ReadLine());
                    PartTimeEmployee partTimeEmployee = new PartTimeEmployee(firstName, lastName, dateOfBirth, hourlySalary, hoursWorked);
                    company.AddEmployee(partTimeEmployee);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

        }
        public List<Employee>? SearchEmployee()
        {
            Console.WriteLine("Enter Employee ID or name to search");
            string search = Console.ReadLine();

            List<Employee> employees = new List<Employee>();

            foreach (Employee employee in company.Employees)
            {
                if (employee.FirstName.ToLower() == search.ToLower() || employee.LastName.ToLower() == search.ToUpper() || employee.EmployeeId.ToLower() == search.ToLower())
                    employees.Add(employee);
            }

            return company.DisplayEmployees(employees);

        }

        public void RemoveEmployee()
        {
            if (SearchEmployee() != null)
            {
                Console.Write("Enter employee ID to remove: ");
                string id = Console.ReadLine();
                company.RemoveEmployee(id);
            }

        }

        public void ShowVacationDays()
        {
            Employee employee = company.GetEmployeeById();

            if (employee == null)
            {
                return;
            }

            Console.WriteLine($"{employee.FirstName} {employee.LastName} has {employee.VacationDays} vacation days\n");

            Console.WriteLine("1.Update");
            Console.WriteLine("2.Back");
            string choise = Console.ReadLine();

            switch (choise)
            {
                case "1":
                    UpdateVacationDays(employee);
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        }

        public void UpdateVacationDays(Employee employee)
        {
            Console.Write("Type new vacation days: ");
            employee.VacationDays = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Vacation days updated");
        }

    }
}