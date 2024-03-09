using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UVS.Database;
using UVS.Models;

namespace UVS.Repository
{
    public class EmployeeRepository
    {
        private readonly DatabaseConnection _connection = new DatabaseConnection();

     
        public void SetEmployee(Employee employee)
        {
            _connection.Employees.Add(employee);    
            _connection.SaveChanges();
        }

        public Employee GetEmployee(int id)
        {
            return _connection.Employees.SingleOrDefault(emp => emp.EmployeeId == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _connection.Employees.ToList();  
        }
    }
}
