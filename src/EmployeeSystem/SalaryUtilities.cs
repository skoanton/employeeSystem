using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using EmployeeSystem.Models.Employees;

namespace EmployeeSystem
{
    public class SalaryUtilities
    {

        private Company company = new Company();
        private EmployeeManagementUtilities employeeManagementUtilities;
        public Company Company
        {
            get { return company; }
            set { company = value; }
        }
        public EmployeeManagementUtilities EmployeeManagementUtilities
        {
            get { return employeeManagementUtilities; }
            set { employeeManagementUtilities = value; }
        }
        public SalaryUtilities(Company company, EmployeeManagementUtilities employeeManagementUtilities)
        {
            Company = company;
            EmployeeManagementUtilities = employeeManagementUtilities;
        }

        public void CalculateSalary()
        {
            if (employeeManagementUtilities.SearchEmployee() != null)
            {
                Employee employee = company.GetEmployeeById();
                if (employee == null)
                {
                    return;
                }
                double salary = employee.CalculateSalary();

                Console.WriteLine($"Salary: {salary} \n");
            }

        }

        public void CalculateBonus()
        {
            if (employeeManagementUtilities.SearchEmployee() != null)
            {

                Employee employee = company.GetEmployeeById();
                if (employee == null)
                {
                    return;
                }

                if (employee is PartTimeEmployee)
                {
                    Console.WriteLine("No bonus for part time employees");
                    return;
                }

                if (employee is FullTimeEmployee)
                {
                    FullTimeEmployee fullTimeEmployee = (FullTimeEmployee)employee;
                    double bonus = fullTimeEmployee.CalculateBonus();
                    Console.WriteLine($"Bonus for {fullTimeEmployee.FirstName} {fullTimeEmployee.LastName} is {bonus} kr ");
                }
            }

        }

        public void UpdateSalary()
        {
            if (employeeManagementUtilities.SearchEmployee() != null)
            {
                Employee employee = company.GetEmployeeById();
                if (employee == null)
                {
                    return;
                }

                Console.WriteLine("Type new salary: ");
                double newSalary = Convert.ToInt32(Console.ReadLine());
                if (employee is FullTimeEmployee)
                {
                    FullTimeEmployee fullTimeEmployee = (FullTimeEmployee)employee;
                    fullTimeEmployee.MonthlySalary = newSalary;
                }

                if (employee is PartTimeEmployee)
                {
                    PartTimeEmployee partTimeEmployee = (PartTimeEmployee)employee;
                    partTimeEmployee.HourlySalary = newSalary;
                }
            }
        }

    }
}