﻿
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EgzaminasRestoranas.Models
{
    internal class DeleteEndedOrder
    {
        private ConnectToDatabase Connection = new ConnectToDatabase();
        private SqlConnection SqlConnection = new SqlConnection();
        private SqlCommand SqlCommand = new SqlCommand();
        private ReadTableId TableId = new ReadTableId();

        public void DeleteOrderFromDatabase()
        {
            CopyOrderToArchive();
            try
            {
                SqlConnection = Connection.Connection();
                SqlCommand = new SqlCommand($"Delete From ClientOrder Where TableID={TableId.ReadTableFromFile()}", SqlConnection);
                SqlCommand.ExecuteNonQuery();
                SqlConnection.Close();  
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteOrderInfo()
        {
            try
            {
                SqlConnection = Connection.Connection();
                SqlCommand = new SqlCommand($"Delete From OrderInfo Where TableID={TableId.ReadTableFromFile()}", SqlConnection);
                SqlCommand.ExecuteNonQuery();
                SqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CopyOrderToArchive()
        { 
            try
            {
                SqlConnection = Connection.Connection();
                SqlCommand = new SqlCommand($"Insert into AllOrder(Name,Price) Select Name,Price from ClientOrder Where TableID={TableId.ReadTableFromFile()}", SqlConnection);
                SqlCommand.ExecuteNonQuery();
                SqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}