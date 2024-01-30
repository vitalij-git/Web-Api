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
            Main main = new Main();
            this.Hide();
            main.Show();
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
            else if(IsCorrectFullName(FullNameTextBox.Text) != true)
            {
                MessageBox.Show("Please enter a valid full name");
            }
            else if(SelectedContact != null)
            {
                UpdateContact();
            }
            else
            {
                AddContact();
            }
        }

        private bool IsCorrectFullName(string fullName)
        {
            return Regex.IsMatch(fullName, @"^[A-Za-z\s]*$");
        }
     

        private void AddAndEditContacts_Load(object sender, EventArgs e)
        {
            if(SelectedContact != null)
            {
                FullNameTextBox.Text = SelectedContact.FullName;
                TelNubmerTextBox.Text = SelectedContact.TelNumber.ToString();
                if(DateTime.TryParse(SelectedContact.Birthdate, out DateTime date))
                {
                    dateTimePicker.Value = date;
                }
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
                sqlCommand.Parameters.AddWithValue("@TelNumber", TelNubmerTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@Birthdate", dateTimePicker.Value);

                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Contact added successfully");
                Main main = new Main();
                this.Hide();
                main.Show();
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
                sqlCommand.Parameters.AddWithValue("@TelNumber", TelNubmerTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@Birthdate", dateTimePicker.Value);

                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Contact updated successfully");
                Main main = new Main();
                this.Hide();
                main.Show();
            }
        }
    }
}
