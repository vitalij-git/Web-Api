using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UVS.Services;

namespace UVS.Controller
{
    public class ConsoleController
    {
        
        ConsoleKeyInfo keyInfo;

      
        public void Menu()
        {
            MenuOutput();
            ConsoleCommand();
        }

        private void MenuOutput() 
        {
            Console.WriteLine("1. Add new employee " +
                "\n2. Get all employees" +
                "\n3. Get employee by ID");
        }

        private void ConsoleCommand()
        {
            EmployeeService _employeeService = new EmployeeService();
            while (true)
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.NumPad1 || keyInfo.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    _employeeService.AddEmployee();
                }
                else if (keyInfo.Key == ConsoleKey.NumPad2 || keyInfo.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    _employeeService.GetEmployees();
                }
                else if (keyInfo.Key == ConsoleKey.NumPad3 || keyInfo.Key == ConsoleKey.D3)
                {
                    Console.Clear();
                    _employeeService.GetEmployee();
                }
            }



        }
    }
}
