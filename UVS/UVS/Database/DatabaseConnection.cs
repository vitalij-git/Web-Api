using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UVS.Models;

namespace UVS.Database
{
    public class DatabaseConnection : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConnectionConfiguration connectionConfiguration = new ConnectionConfiguration();
            optionsBuilder.UseSqlServer(connectionConfiguration.getConnectionString());
        }
    }
}
