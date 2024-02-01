namespace Contacts
{
    partial class AddAndEditContacts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FullName = new System.Windows.Forms.Label();
            this.TelNumber = new System.Windows.Forms.Label();
            this.Birthdate = new System.Windows.Forms.Label();
            this.FullNameTextBox = new System.Windows.Forms.TextBox();
            this.TelNubmerTextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.BirthdateTexBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FullName
            // 
            this.FullName.AutoSize = true;
            this.FullName.Location = new System.Drawing.Point(6, 11);
            this.FullName.Name = "FullName";
            this.FullName.Size = new System.Drawing.Size(52, 13);
            this.FullName.TabIndex = 0;
            this.FullName.Text = "Full name";
            // 
            // TelNumber
            // 
            this.TelNumber.AutoSize = true;
            this.TelNumber.Location = new System.Drawing.Point(6, 40);
            this.TelNumber.Name = "TelNumber";
            this.TelNumber.Size = new System.Drawing.Size(65, 13);
            this.TelNumber.TabIndex = 1;
            this.TelNumber.Text = "Tel. Number";
            // 
            // Birthdate
            // 
            this.Birthdate.AutoSize = true;
            this.Birthdate.Location = new System.Drawing.Point(6, 63);
            this.Birthdate.Name = "Birthdate";
            this.Birthdate.Size = new System.Drawing.Size(49, 13);
            this.Birthdate.TabIndex = 2;
            this.Birthdate.Text = "Birthdate";
            // 
            // FullNameTextBox
            // 
            this.FullNameTextBox.Location = new System.Drawing.Point(95, 11);
            this.FullNameTextBox.Name = "FullNameTextBox";
            this.FullNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.FullNameTextBox.TabIndex = 3;
            // 
            // TelNubmerTextBox
            // 
            this.TelNubmerTextBox.Location = new System.Drawing.Point(95, 37);
            this.TelNubmerTextBox.Name = "TelNubmerTextBox";
            this.TelNubmerTextBox.Size = new System.Drawing.Size(200, 20);
            this.TelNubmerTextBox.TabIndex = 4;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(139, 89);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 6;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(220, 89);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BirthdateTexBox
            // 
            this.BirthdateTexBox.Location = new System.Drawing.Point(95, 63);
            this.BirthdateTexBox.Name = "BirthdateTexBox";
            this.BirthdateTexBox.Size = new System.Drawing.Size(200, 20);
            this.BirthdateTexBox.TabIndex = 8;
            // 
            // AddAndEditContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 130);
            this.Controls.Add(this.BirthdateTexBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.TelNubmerTextBox);
            this.Controls.Add(this.FullNameTextBox);
            this.Controls.Add(this.Birthdate);
            this.Controls.Add(this.TelNumber);
            this.Controls.Add(this.FullName);
            this.Name = "AddAndEditContacts";
            this.Text = "AddAndEditContacts";
            this.Load += new System.EventHandler(this.AddAndEditContacts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FullName;
        private System.Windows.Forms.Label TelNumber;
        private System.Windows.Forms.Label Birthdate;
        private System.Windows.Forms.TextBox FullNameTextBox;
        private System.Windows.Forms.TextBox TelNubmerTextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox BirthdateTexBox;
    }
}