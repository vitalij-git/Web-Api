using Contacts.Database;
using Contacts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts
{
    public partial class Main : Form
    {
        private Contact Contact = new Contact();
        private int RowIndex;
        public Main()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddAndEditContacts addAndEditContacts = new AddAndEditContacts();
            addAndEditContacts.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
             ContactsOutput();
        }

        private void ContactsOutput()
        {
            var contactsBook = GetContactsFromDatabase();
            var id = 1;

            foreach (var contacts in contactsBook)
            {
                int contactId = contacts.Key;
                foreach(var contact in contacts.Value)
                {
                    ContactsDataGridView.Rows.Add(id, contact.FullName, contact.TelNumber, contact.Birthdate, contact.Id);
                    id++;
                }
            }
            
        }

        private Dictionary<int, List<Contact>> GetContactsFromDatabase()
        {
            Dictionary<int, List<Contact>> contactsBook = new Dictionary<int, List<Contact>>();
            DatabaseConnection databaseConnection = new DatabaseConnection();          
            using(var connection = databaseConnection.OpenConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("spContacts_GetALl", connection);
                using(SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    int id = 1;
                    while (reader.Read())
                    {

                        DateTime birthData = (DateTime)reader["BirthDate"];
                        string formatBirthData = birthData.ToString("yyyy-MM-dd");
                        int contactId = Convert.ToInt32(reader["ID"]);
                        Contact contact = new Contact()
                        {
                            Id = contactId,
                            FullName = reader["FullName"].ToString(),
                            TelNumber = (int)reader["PhoneNumber"],
                            Birthdate = formatBirthData,

                        };
                        if (!contactsBook.ContainsKey(contact.Id))
                        {
                            contactsBook[contactId] = new List<Contact>();
                        }
                        contactsBook[contactId].Add(contact);
                        id++;
                    }
                    
                }
            }
            return contactsBook;
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if(RowIndex >= 0)
            {
                AddAndEditContacts addAndEditContacts = new AddAndEditContacts();
                addAndEditContacts.SelectedContact = Contact;
                addAndEditContacts.Show();
            }
           
        }

        private void Delete_Click(object sender, EventArgs e)
        {
           
            if (RowIndex >= 0)
            {
                DatabaseConnection databaseConnection = new DatabaseConnection();
                using (var connection = databaseConnection.OpenConnection())
                {
                    SqlCommand sqlCommand = new SqlCommand("spContact_Delete", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@ContactId", Contact.Id);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Contact deleted successfully");

                }

                ContactsDataGridView.Rows.Clear();
                var contactsBook = GetContactsFromDatabase();
                var id = 1;

                foreach (var contacts in contactsBook)
                {
                    int contactId = contacts.Key;
                    foreach (var contact in contacts.Value)
                    {
                        ContactsDataGridView.Rows.Add(id, contact.FullName, contact.TelNumber, contact.Birthdate, contact.Id);
                        id++;
                    }
                }
            }
        }

        private void ContactsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowIndex = e.RowIndex;
            if (RowIndex != -1)
            {
                DataGridViewRow dvgRow = ContactsDataGridView.Rows[RowIndex];
                Contact.FullName = dvgRow.Cells[1].Value.ToString();
                Contact.TelNumber = (int)dvgRow.Cells[2].Value;
                Contact.Birthdate = dvgRow.Cells[3].Value.ToString();
                Contact.Id = (int)dvgRow.Cells[4].Value;
            }
            
        }


    }
}
