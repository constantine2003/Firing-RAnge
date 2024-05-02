using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firing_RAnge
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();

        }
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;
        int indexRow;
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb";
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
            da = new OleDbDataAdapter("SELECT * FROM Members", myConn); // Added space after the asterisk
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "Members");
            dataGridView1.DataSource = ds.Tables["Members"];
            myConn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
            ds = new DataSet();
            myConn.Open();
            System.Windows.Forms.MessageBox.Show("Connected successfully!");
            myConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
            da = new OleDbDataAdapter("SELECT * FROM Sales Report", myConn); // Updated table name to Sales Report
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "Sales Report"); // Updated table name to Sales Report
            dataGridView1.DataSource = ds.Tables["Sales Report"]; // Updated table name to Sales Report
            myConn.Close();

        }
    }
}
