using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSystem.Models.Employees
{
    public class FullTimeEmployee : Employee
    {
        private double monthlySalary;
        private double bonusAfterFiveYears = 0.10;
        private double bonusAfterTenYears = 0.15;
        private DateTime dateOfEmployment;
        public double MonthlySalary
        {
            get { return monthlySalary; }
            set { monthlySalary = value; }
        }
        public double BonusAfterFiveYears
        {
            get { return bonusAfterFiveYears; }
            private set { bonusAfterFiveYears = value; }
        }
        public double BonusAfterTenYears
        {
            get { return bonusAfterTenYears; }
            private set { bonusAfterTenYears = value; }
        }
        public DateTime DateOfEmployment
        {
            get { return dateOfEmployment; }
            set { dateOfEmployment = value; }
        }
        public FullTimeEmployee(string firstName, string lastName, DateTime dateOfBirth, double monthlySalary, DateTime dateOfEmployment) : base(firstName, lastName, dateOfBirth)
        {
            MonthlySalary = monthlySalary;
            VacationDays = 25;
        }
        public FullTimeEmployee(string employeeId, string firstName, string lastName, string email, DateTime dateOfBirth, double monthlySalary, DateTime dateOfEmployment, int vacationDays) : base(employeeId, firstName, lastName, email, dateOfBirth, vacationDays)
        {
            MonthlySalary = monthlySalary;
            DateOfEmployment = dateOfEmployment;
        }

        public override double CalculateSalary()
        {
            double salaryAfterTax = MonthlySalary - (MonthlySalary * tax);
            return salaryAfterTax;
        }

        public double CalculateBonus()
        {
            TimeSpan daysWorked = DateTime.Now - DateOfEmployment;
            double yearsWorked = daysWorked.Days / 365;
            if (yearsWorked > 5)
            {
                return MonthlySalary * BonusAfterFiveYears;
            }

            else if (yearsWorked < 10)
            {
                return MonthlySalary * BonusAfterTenYears;
            }

            return 0;
        }

        public override string GetEmployeeDetails()
        {
            return $"FT,{base.GetEmployeeDetails()},{MonthlySalary},{dateOfEmployment.ToShortDateString()}";
        }
    }
}