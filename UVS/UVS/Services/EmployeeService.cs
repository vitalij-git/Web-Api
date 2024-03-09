using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UVS.Controller;
using UVS.Migrations;
using UVS.Models;
using UVS.Repository;

namespace UVS.Services
{
    public class EmployeeService
    {
         EmployeeRepository _employeeRepository = new EmployeeRepository();
         ConsoleController _consoleController = new ConsoleController();
         ConsoleKeyInfo keyInfo;
       
        public void AddEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("Enter the employee name");
            var name = CheckNameFromInput(out string nameInput);
            employee.EmployeeName = name;
            Console.WriteLine("Enter the employee salary");
            var salary = GetNumberFromInput(out string salaryInput);
            employee.EmployeeSalary = salary;

            _employeeRepository.SetEmployee(employee);
            Console.WriteLine("The employee is added to the database");
            ReturnOrExit();
        }

        public void GetEmployees()
        {
            var employees = _employeeRepository.GetEmployees();
            foreach (var employee in employees)
            {
                Console.WriteLine("-------------------------------------");
                ShowEmployee(employee);

            }
            Console.WriteLine("-------------------------------------");
            ReturnOrExit();
        }
        public void GetEmployee()
        {
            Console.WriteLine("Enter Employee ID number");
            var employeeId = GetNumberFromInput(out string input);
            
            var employee = _employeeRepository.GetEmployee(employeeId);
            if (employee == null)
            {
                Console.WriteLine("The employee with the specified ID does not exist in the system");
                ReturnOrExit();
            }

            ShowEmployee(employee);
            ReturnOrExit();

        }

        private string CheckNameFromInput(out string input)
        {
            string pattern = @"[\d\W]";
            while (true)
            {
                input = Console.ReadLine();
                if (!Regex.IsMatch(input,pattern))
                {
                    break;
                }
                Console.WriteLine("please enter a correct name without numbers or symbols");

            }

            return input;
        }
        private int GetNumberFromInput(out string input)
        {
            while (true)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out var _))
                {
                    break;
                }
                Console.WriteLine("please enter a integer");

            }
            return Convert.ToInt32(input);
        }

        private void ReturnOrExit()
        {
            Console.WriteLine("Push 1 to return menu or 2 to exit");
            while (true)
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.NumPad1 || keyInfo.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    _consoleController.Menu();
                }
                else if (keyInfo.Key == ConsoleKey.NumPad2 || keyInfo.Key == ConsoleKey.D2)
                {
                    Environment.Exit(0);
                }

            }
        }

        private void ShowEmployee(Employee employee)
        {
            Console.WriteLine($" Employee ID is {employee.EmployeeId}" +
                $"\n Employee name is {employee.EmployeeName}" +
                $"\n Employee salary is {employee.EmployeeSalary}");
        }
    }
}
