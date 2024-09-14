using EmployeeSystem;
using EmployeeSystem.Models.Employees;

Company company = new Company();
Utilities utilities = new Utilities(company);
EmployeeManagementUtilities employeeManagementUtilities = new EmployeeManagementUtilities(company);
SalaryUtilities salaryUtilities = new SalaryUtilities(company, employeeManagementUtilities);



string choice;
do
{

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Employee System");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"Loaded({company.Employees.Count})");
    Console.WriteLine("---------------------------------\n\n");
    Console.ResetColor();
    Console.WriteLine("1. Add Employee");
    Console.WriteLine("2. Remove Employee");
    Console.WriteLine("3. List Employees");
    Console.WriteLine("4. Search Employee");
    Console.WriteLine("5. Calculate Salary");
    Console.WriteLine("6. Calculate bonus");
    Console.WriteLine("7. Vacations");
    Console.WriteLine("8. Update salary");
    Console.WriteLine("9. Save Employees");
    Console.WriteLine("10. Load Employees");
    Console.WriteLine("0. Exit");
    choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            employeeManagementUtilities.AddEmployee();
            break;
        case "2":
            employeeManagementUtilities.RemoveEmployee();
            break;
        case "3":
            company.DisplayEmployees(company.Employees);
            break;
        case "4":
            employeeManagementUtilities.SearchEmployee();
            break;
        case "5":
            salaryUtilities.CalculateSalary();
            break;
        case "6":
            salaryUtilities.CalculateBonus();
            break;
        case "7":
            employeeManagementUtilities.ShowVacationDays();
            break;
        case "8":
            salaryUtilities.UpdateSalary();
            break;
        case "9":
            utilities.SaveToFile();
            break;
        case "10":
            utilities.LoadFromFile();
            break;
        case "0":
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("Invalid Choice");
            break;
    }
} while (choice != "0");