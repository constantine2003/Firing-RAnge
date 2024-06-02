using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firing_RAnge
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Hardcoded admin credentials
            string adminUsername = "admin";
            string adminPassword = "admin123";

            if (username == adminUsername && password == adminPassword)
            {
                MessageBox.Show("Login successful! You are now logged in as admin.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // You can perform further actions for admin login here
                Form1 mainForm = new Form1();
                mainForm.Show();

            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
