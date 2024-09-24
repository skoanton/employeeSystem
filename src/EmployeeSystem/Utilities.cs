using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSystem.Models.Employees;

namespace EmployeeSystem
{
    public class Utilities
    {

        Company company;
        private string filePath = "/home/mrdavinski/test";
        public Company Company
        {
            get { return company; }
            set { company = value; }
        }

        public Utilities(Company company)
        {
            Company = company;
        }


        public void SaveToFile()
        {


            try
            {
                StreamWriter sw = new StreamWriter(filePath);
                foreach (Employee employee in company.Employees)
                {
                    sw.WriteLine(employee.GetEmployeeDetails());
                }

                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Saved");
            }

        }

        public void LoadFromFile()
        {
            try
            {
                StreamReader sr = new StreamReader(filePath);

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(',').Select(s => s.Trim()).ToArray();

                    string employeeType = data[0];

                    company.AddEmployee(CreateEmployeeFromData(employeeType, data));
                    Console.WriteLine("Loaded one emp");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Loaded");
            }
        }

        private Employee? CreateEmployeeFromData(string employeeType, string[] data)
        {
            string employeeId = data[1];
            string firstName = data[2];
            string lastName = data[3];
            string email = data[4];
            DateTime dateOfBirth = DateTime.Parse(data[5]);
            int vacationDays = int.Parse(data[6]);

            switch (employeeType)
            {
                case "FT":
                    double monthlySalary = double.Parse(data[7]);
                    DateTime dateOfEmployment = DateTime.Parse(data[8]);
                    return new FullTimeEmployee(employeeId, firstName, lastName, email, dateOfBirth, monthlySalary, dateOfEmployment, vacationDays);
                case "PT":
                    int hourlySalary = int.Parse(data[7]);
                    int hoursWorked = int.Parse(data[8]);
                    return new PartTimeEmployee(employeeId, firstName, lastName, email, dateOfBirth, hourlySalary, hoursWorked, vacationDays);
                default:
                    Console.WriteLine("Unknown employee type: " + employeeType);
                    return null;
            }

        }
    }
}