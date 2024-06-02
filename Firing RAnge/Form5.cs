using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static Firing_RAnge.Form1;


namespace Firing_RAnge
{
    public partial class Form5 : Form
    {
        private ReceiptData receiptData;

        public Form5(ReceiptData receiptData)
        {
            InitializeComponent();
            this.receiptData = receiptData;
            DisplayReceipt();
        }
        private void DisplayReceipt()
        {
            string receiptText = $"Date: {receiptData.Date}\n" +
                                 $"Item: {receiptData.Item}\n" +
                                 $"Quantity: {receiptData.Quantity}\n" +
                                 $"Item Price: {receiptData.ItemPrice} PHP\n" +
                                 $"Total Price: {receiptData.TotalPrice} PHP";

            if (receiptData.HasTrainer)
            {
                receiptText += $"\nAdditional Charge (Yes in adding a Trainer): {receiptData.AdditionalCharge} PHP";
                receiptData.TotalPrice += receiptData.AdditionalCharge;
            }           
            receiptText += $"\n\nThank you for your purchase!";

            labelReceipt.Text = receiptText;
            try
            {
                if (File.Exists(receiptData.QRCodeFilePath))
                {
                    QRbox.Image = Image.FromFile(receiptData.QRCodeFilePath);
                    QRbox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    MessageBox.Show("QR code image not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading QR code image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
