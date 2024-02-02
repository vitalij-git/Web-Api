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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts
{
    public partial class AddAndEditContacts : Form
    {
        public Contact SelectedContact { get; set; }
        public AddAndEditContacts()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FullNameTextBox.Text) || string.IsNullOrEmpty(TelNubmerTextBox.Text))
            {
                MessageBox.Show("There is a empty input");
            }
            else if (!int.TryParse(TelNubmerTextBox.Text, out _))
            {
                MessageBox.Show("The provided telephone number is not valid. Please enter a valid telephone number.");
            }
            else if(FullNameTextBox.Text.Any(char.IsDigit) == true)
            {
                MessageBox.Show("Valid full name without any digit.");
            }
            else if(SelectedContact != null)
            {
                UpdateContact();
                Main main = new Main();
                main.DataGridViewRefresh();
                this.Close();
            }
            else
            {
                AddContact();
                Main main = new Main();
                main.DataGridViewRefresh();
                this.Close();
            }

            
        }



        private void AddAndEditContacts_Load(object sender, EventArgs e)
        {
            if(SelectedContact != null)
            {
                FullNameTextBox.Text = SelectedContact.FullName;
                TelNubmerTextBox.Text = SelectedContact.TelNumber.ToString();
                BirthdateTexBox.Text = SelectedContact.Birthdate.ToString();
            }
        }

        private void AddContact()
        {
            DatabaseConnection database = new DatabaseConnection();
            using (var connection = database.OpenConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("spContact_Add", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FullName", FullNameTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", TelNubmerTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@Birthdate", BirthdateTexBox.Text);

                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Contact added successfully");
            }
        }

        private void UpdateContact()
        {
            DatabaseConnection database = new DatabaseConnection();
            using (var connection = database.OpenConnection())
            {
                SqlCommand sqlCommand = new SqlCommand("spContact_Update", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ContactId", SelectedContact.Id);
                sqlCommand.Parameters.AddWithValue("@FullName", FullNameTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", TelNubmerTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@Birthdate", BirthdateTexBox.Text);

                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Contact updated successfully");
            }
        }
    }
}
