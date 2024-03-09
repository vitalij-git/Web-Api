using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UVS.Database
{
    public class ConnectionConfiguration
    {
        protected string ConnectionString { get; set; } 

        public ConnectionConfiguration()
        {
            ConnectionString = "Server=DESKTOP-O7DTL46; Database=UVS_Employees; Trusted_Connection=True;TrustServerCertificate=true";
        }

        public string getConnectionString()
        {
            return ConnectionString;
        }
    }
}
