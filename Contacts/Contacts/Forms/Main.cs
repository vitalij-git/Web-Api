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
        public Main()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddAndEditContacts addAndEditContacts = new AddAndEditContacts();
            this.Hide();
            addAndEditContacts.Show();
        }


        private void ContactListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edit.Enabled = ContactListBox.SelectedItem != null;
            Delete.Enabled = ContactListBox.SelectedItem != null;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ContactsOutput();
        }

        private void ContactsOutput()
        {
            var contactsBook = GetContactsFromDatabase();

            foreach (var contacts in contactsBook)
            {
                int contactId = contacts.Key;
                foreach(var contact in contacts.Value)
                {
                    ContactListBox.Items.Add(contact); 
                }
            }
            ContactListBox.DisplayMember = "ToString";
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
                            ListNumber = id


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
            if (ContactListBox.SelectedItem != null)
            {
                Contact selectedContact = (Contact)ContactListBox.SelectedItem;
                AddAndEditContacts addAndEditContacts = new AddAndEditContacts();
                addAndEditContacts.SelectedContact = selectedContact;
                this.Hide();
                addAndEditContacts.Show();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (ContactListBox.SelectedItem != null)
            {
                Contact selectedContact = (Contact)ContactListBox.SelectedItem;
                DatabaseConnection databaseConnection = new DatabaseConnection();
                using (var connection = databaseConnection.OpenConnection())
                {
                    SqlCommand sqlCommand = new SqlCommand("spContact_Delete", connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@ContactId", selectedContact.Id);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Contact deleted successfully");
                    
                }
                var updatedContacts = GetContactsFromDatabase();
                ContactListBox.Items.Clear();
                foreach (var contacts in updatedContacts)
                {
                    int contactId = contacts.Key;
                    foreach (var contact in contacts.Value)
                    {
                        ContactListBox.Items.Add(contact);
                    }
                }
            }
        }
    }
}
