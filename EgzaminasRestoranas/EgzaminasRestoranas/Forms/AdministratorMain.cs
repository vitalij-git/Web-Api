﻿using EgzaminasRestoranas.Models;
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

namespace EgzaminasRestoranas.Forms
{
    public partial class AdministratorMain : Form
    {
        public AdministratorMain()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sėkmingai atsijungėte");
            this.Hide();
            WorkerLogin login = new WorkerLogin();
            login.Show();
        }

        private void AddNewWorker_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddWorker addWorker = new AddWorker(); 
            addWorker.Show();
        }
        public void ShowWorkerStatus()
        {
            var workerStatus = new WorkerStatus();
            List<string> userStatusList = workerStatus.GetWorkerStatus();
            workerName.Text = userStatusList[0];
            workerRole.Text = userStatusList[1];
        }

        private void ShowMenu_Click(object sender, EventArgs e)
        {
            RestaurantMenu menu = new RestaurantMenu();
            this.Hide();
            menu.Show();
        }

        private void Statisctics_Click(object sender, EventArgs e)
        {
            Statistics statistics = new Statistics();
            this.Hide();
            statistics.Show();
        }

        private void ShowWorkers_Click(object sender, EventArgs e)
        {
            Workers workers = new Workers();
            this.Hide();
            workers.Show();
        }

        //nereikalingi
        private void AdministratorMain_Load(object sender, EventArgs e)
        {
            ShowWorkerStatus();
        }

        private void workerName_Click(object sender, EventArgs e)
        {

        }

    }
}
