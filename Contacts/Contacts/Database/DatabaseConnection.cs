using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Database
{
    public class DatabaseConnection
    {
        private SqlConnection _connection; 

        public SqlConnection OpenConnection()
        {
            var connection = "Data Source=DESKTOP-O7DTL46;Initial Catalog=PhoneNumberBook;Integrated Security=True;";
            _connection = new SqlConnection(connection);
            _connection.Open();
            return _connection;
        }

        public void CloseConnection() 
        {
            _connection.Close(); 
        }

    }


}
