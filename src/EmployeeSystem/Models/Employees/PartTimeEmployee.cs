using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSystem.Models.Employees
{
    public class PartTimeEmployee : Employee
    {
        private double hourlySalary;
        private int hoursWorked;

        public double HourlySalary
        {
            get { return hourlySalary; }
            set { hourlySalary = value; }
        }

        public int HoursWorked
        {
            get { return hoursWorked; }
            set { hoursWorked = value; }
        }

        public PartTimeEmployee(string employeeId, string firstName, string lastName, string email, DateTime dateOfBirth, double hourlySalary, int hoursWorked, int vacationDays) : base(employeeId, firstName, lastName, email, dateOfBirth, vacationDays)
        {
            HourlySalary = hourlySalary;
            HoursWorked = hoursWorked;
        }
        public PartTimeEmployee(string firstName, string lastName, DateTime dateOfBirth, double hourlySalary, int HoursWorked) : base(firstName, lastName, dateOfBirth)
        {
            HourlySalary = hourlySalary;
            VacationDays = HoursWorked / 2080 * 25;
        }

        public override double CalculateSalary()
        {
            double salaryAfterTax = HourlySalary - (HourlySalary * tax);
            return salaryAfterTax;
        }

        public override string GetEmployeeDetails()
        {
            return $"PT, {base.GetEmployeeDetails()},{hourlySalary},{hoursWorked}";
        }
    }
}