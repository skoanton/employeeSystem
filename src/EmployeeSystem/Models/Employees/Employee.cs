using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSystem.Models.Employees
{
    public abstract class Employee
    {
        protected string firstName;
        protected string lastName;
        protected string email;
        protected DateTime dateOfBirth;
        protected string employeeId;
        protected double tax = 0.15;

        protected double vacationDays;

        public abstract double CalculateSalary();
        public virtual string GetEmployeeDetails()
        {
            return $"{EmployeeId},{FirstName},{LastName},{email},{DateOfBirth.ToShortDateString()},{vacationDays}";
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (value.Contains("å"))
                {
                    value = value.Replace("å", "a");

                }
                if (value.Contains("ä"))
                {
                    value = value.Replace("ä", "a");
                }
                if (value.Contains("ö"))
                {
                    value = value.Replace("ö", "o");
                }
                email = value.ToLower();

            }
        }
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
            }
        }

        public string EmployeeId
        {
            get { return employeeId; }
            private set { employeeId = value; }
        }

        public double VacationDays
        {
            get { return vacationDays; }
            set { vacationDays = value; }
        }

        public Employee(string employeeId, string firstName, string lastName, string email, DateTime dateOfBirth, int vacationDays)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            EmployeeId = employeeId;
            VacationDays = vacationDays;
        }
        public Employee(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = $"{FirstName}.{LastName}@mail.com";
            DateOfBirth = dateOfBirth;
            EmployeeId = Guid.NewGuid().ToString();
        }

    }
}