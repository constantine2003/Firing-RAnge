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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            LoadData();
        }
        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;
        int indexRow;
        private void LoadData()
        {
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
            da = new OleDbDataAdapter("SELECT * FROM [Staff Querry]", myConn); // Assuming "Staff Query" is the query name
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "StaffQuerryResult"); // Naming the result as "StaffQueryResult" in the DataSet
            dataGridView1.DataSource = ds.Tables["StaffQuerryResult"]; // Binding to the result of the custom query
            myConn.Close();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxLoad_Click(object sender, EventArgs e)
        {

        }

        private void tbxUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE Staffs SET Available = @avail WHERE ID = @id"; // Assuming 'Available' is an editable field
                cmd = new OleDbCommand(query, myConn);
                cmd.Parameters.AddWithValue("@avail", tbxAvailability.SelectedItem.ToString()); // Use the selected item text from the ComboBox
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(tbxTrainerID.Text));

                myConn.Open();
                cmd.ExecuteNonQuery();
                myConn.Close();

                // After updating, reload the data into the DataGridView
                myConn.Open();
                da = new OleDbDataAdapter("SELECT * FROM [Staff Querry]", myConn); // Assuming "Staff Query" is the query name
                ds = new DataSet();
                da.Fill(ds, "StaffQuerryResult"); // Naming the result as "StaffQueryResult" in the DataSet
                dataGridView1.DataSource = ds.Tables["StaffQuerryResult"]; // Binding to the result of the custom query
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
