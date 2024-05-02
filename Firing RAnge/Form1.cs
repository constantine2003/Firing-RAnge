using QRCoder;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;
using ZXing.Windows.Compatibility;
using System.Reflection.Emit;



namespace Firing_RAnge
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer; // Explicitly use System.Windows.Forms.Timer
        private int imageIndex = 0;
        private string[] imagePaths = { @"D:\gun1.jpg", @"D:\gun2.jpg" }; // Absolute paths to the images
        public Form1()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer(); // Use System.Windows.Forms.Timer
            timer.Interval = 3000; // 5 seconds = 5000 milliseconds
            timer.Tick += Timer_Tick;
            timer.Start();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            barcodeReader = new BarcodeReader();

        }

        OleDbConnection? myConn;
        OleDbDataAdapter? da;
        OleDbCommand? cmd;
        DataSet? ds;
        int indexRow;
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb";

        private void button1_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
            da = new OleDbDataAdapter("SELECT * FROM Members", myConn); // Added space after the asterisk
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "Members");
            dataGridView1.DataSource = ds.Tables["Members"];
            myConn.Close();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Change the picture box image every 5 seconds
            if (imageIndex >= imagePaths.Length)
                imageIndex = 0;

            pictureBox1.Image = Image.FromFile(imagePaths[imageIndex]);
            imageIndex++;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tbxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbxYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panel3.Visible = true;
            panel4.Visible = true;
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
            da = new OleDbDataAdapter("SELECT * FROM Staffs", myConn); // Added space after the asterisk
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "Staffs");
            dataGridView2.DataSource = ds.Tables["Staffs"];
            myConn.Close();

        }

        private void btnGuns_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // ADD MEMBERS LOGIC
            //string query = "Insert into Members (Name, Gender, Month, Day) values (@Name, @Gender, @Month, @Day)";
            //string query = "Insert into Members (Name, Gender, Month, Day, Year, Number, Address) values (@Name, @Gender, @Month, @Day, @Year, @Number, @Address)";
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
            ds = new DataSet();
            string query = "Insert into Members (FullName, Gender, BirthMonth, BirthDay, BirthYear, CellNumber, Address) values (@Name, @Gender, @Month, @Day, @Year, @Number, @Address)";
            cmd = new OleDbCommand(query, myConn);

            cmd.Parameters.AddWithValue("@Name", tbxFullName.Text);
            cmd.Parameters.AddWithValue("@Gender", tbxGender.Text);
            cmd.Parameters.AddWithValue("@Month", tbxMonth.Text);
            cmd.Parameters.AddWithValue("@Day", tbxDay.Text);
            cmd.Parameters.AddWithValue("@Year", tbxYear.Text);
            cmd.Parameters.AddWithValue("@Number", tbxNumber.Text);
            cmd.Parameters.AddWithValue("@Address", tbxAddress.Text);

            try
            {
                myConn.Open();
                cmd.ExecuteNonQuery();
                // Close the connection after inserting the member
                myConn.Close();


                // After adding a member, load the updated data from the database
                LoadMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding member: " + ex.Message);
            }
        }

        private void LoadMembers()
        {
            // Initialize database connection, data adapter, and dataset
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
            da = new OleDbDataAdapter("SELECT * FROM Members", myConn);
            ds = new DataSet();

            try
            {
                // Open connection, fill dataset, and close connection
                myConn.Open();
                da.Fill(ds, "Members");
                dataGridView1.DataSource = ds.Tables["Members"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading members: " + ex.Message);
            }
            finally
            {
                myConn.Close(); // Ensure connection is closed even if an exception occurs
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Clear the text in each textbox
            tbxFullName.Text = "";
            tbxGender.Text = "";
            tbxMonth.Text = "";
            tbxDay.Text = "";
            tbxYear.Text = "";
            tbxNumber.Text = "";
            tbxAddress.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the ID of the selected row to delete
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int memberId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ID"].Value); // Assuming there's a column named "ID"

                // Confirm deletion with the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete this member?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Delete the member from the database
                        myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
                        string query = "DELETE FROM Members WHERE ID = @MemberID";
                        cmd = new OleDbCommand(query, myConn);
                        cmd.Parameters.AddWithValue("@MemberID", memberId);

                        myConn.Open();
                        cmd.ExecuteNonQuery();
                        myConn.Close();

                        // Reload the members list after deletion
                        LoadMembers();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting member: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a member to delete.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //LOAD BUTTON
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
            da = new OleDbDataAdapter("SELECT * FROM Members", myConn); // Added space after the asterisk
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "Members");
            dataGridView1.DataSource = ds.Tables["Members"];
            myConn.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Get the ID of the selected row to be deleted
                int selectedRowID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ID"].Value);

                // Delete the row with the selected ID from the database
                DeleteStaffMember(selectedRowID);

                // Reload the DataGridView after deletion
                LoadStaffMembers();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void DeleteStaffMember(int staffID)
        {
            try
            {
                myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
                string query = "DELETE FROM Staffs WHERE ID = @StaffID";
                cmd = new OleDbCommand(query, myConn);
                cmd.Parameters.AddWithValue("@StaffID", staffID);

                myConn.Open();
                cmd.ExecuteNonQuery();
                myConn.Close();

                MessageBox.Show("Staff member deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting staff member: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Add a new staff member to the database
            AddStaffMember();

            // Load the updated database after adding the staff member
            LoadStaffMembers();
        }

        private void AddStaffMember()
        {
            try
            {
                myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
                string query = "INSERT INTO Staffs (FullName, Gender, StaffMonth, StaffDay, StaffYear, CellNumber, JobPosition, Address) VALUES (@Name2, @Gender2, @Month2, @Day2, @Year2, @Number2, @JP, @Address2)";
                cmd = new OleDbCommand(query, myConn);

                cmd.Parameters.AddWithValue("@Name2", tbxFullName2.Text);
                cmd.Parameters.AddWithValue("@Gender2", tbxGender2.Text);
                cmd.Parameters.AddWithValue("@Month2", tbxMonth2.Text);
                cmd.Parameters.AddWithValue("@Day2", tbxDay2.Text);
                cmd.Parameters.AddWithValue("@Year2", tbxYear2.Text);
                cmd.Parameters.AddWithValue("@Number2", tbxNumber2.Text);
                cmd.Parameters.AddWithValue("@JP", tbxJobPosition.Text);
                cmd.Parameters.AddWithValue("@Address2", tbxAddress2.Text);

                myConn.Open();
                cmd.ExecuteNonQuery();
                myConn.Close();

                MessageBox.Show("Staff member added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding staff member: " + ex.Message);
            }
        }

        private void LoadStaffMembers()
        {
            try
            {
                myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
                da = new OleDbDataAdapter("SELECT * FROM Staffs", myConn);
                ds = new DataSet();

                myConn.Open();
                da.Fill(ds, "Staffs");
                myConn.Close();

                // Bind the loaded data to your DataGridView or any other display control
                dataGridView2.DataSource = ds.Tables["Staffs"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading staff members: " + ex.Message);
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {

            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panel5.Visible = true;
            panel6.Visible = true;

            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
            da = new OleDbDataAdapter("SELECT * FROM Inventory", myConn); // Updated table name to Inventory
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "Inventory"); // Updated table name to Inventory
            dataGridView3.DataSource = ds.Tables["Inventory"]; // Updated table name to Inventory
            myConn.Close();
        }
        private void btnRevenue_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel6.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel7.Visible = true;  // Set panel7 to visible
            panel8.Visible = true;  // Set panel8 to visible
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
            da = new OleDbDataAdapter("SELECT * FROM Ammo", myConn); // Updated table name to Sales Report
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "Ammo"); // Updated table name to Sales Report
            dataGridView4.DataSource = ds.Tables["Ammo"]; // Updated table name to Sales Report
            myConn.Close();

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //LOAD BUTTON IN PANEL 6
            myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
            da = new OleDbDataAdapter("SELECT * FROM Inventory", myConn); // Updated table name to Inventory
            ds = new DataSet();
            myConn.Open();
            da.Fill(ds, "Inventory"); // Updated table name to Inventory
            dataGridView3.DataSource = ds.Tables["Inventory"]; // Updated table name to Inventory
            myConn.Close();

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            // Clear the text in each textbox
            tbxGunName.Text = "";
            tbxDescription.Text = "";
            tbxAvailability.Text = "";
            tbxSerialNumber.Text = "";
            tbxIDInventory.Text = "";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
                string query = "INSERT INTO Inventory (GunName, Description, Availability, SerialNumber) VALUES (@GunName, @Description, @Availability, @SerialNumber)";
                cmd = new OleDbCommand(query, myConn);
                cmd.Parameters.AddWithValue("@GunName", tbxGunName.Text);
                cmd.Parameters.AddWithValue("@Description", tbxDescription.Text);
                cmd.Parameters.AddWithValue("@Availability", tbxAvailability.Text);
                cmd.Parameters.AddWithValue("@SerialNumber", tbxSerialNumber.Text);

                myConn.Open();
                cmd.ExecuteNonQuery();
                myConn.Close();

                // After successful insertion, load the updated data into the DataGridView
                LoadInventoryData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item to inventory: " + ex.Message);
            }
        }

        private void LoadInventoryData()
        {
            try
            {
                da = new OleDbDataAdapter("SELECT * FROM Inventory", myConn);
                ds = new DataSet();

                myConn.Open();
                da.Fill(ds, "Inventory");
                myConn.Close();

                // Bind the loaded data to your DataGridView or any other display control
                dataGridView3.DataSource = ds.Tables["Inventory"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory data: " + ex.Message);
            }
        }
        private void btnUpdateInventory_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "Update Inventory Set Availability = @Availability Where GunID = @id";
                cmd = new OleDbCommand(query, myConn);
                cmd.Parameters.AddWithValue("@Availability", tbxAvailability.Text);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(tbxIDInventory.Text));

                myConn.Open();
                cmd.ExecuteNonQuery();
                myConn.Close();

                // After successful update, load the updated data into the DataGridView
                LoadInventoryData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating inventory: " + ex.Message);
            }
        }

        private void btnDeleteInventory_Click(object sender, EventArgs e)
        {

        }
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            

        }

        private Dictionary<string, int> itemPrices = new Dictionary<string, int>()
        {
            {"Remington 700", 1000},
            {"AR-15", 1250},
            {"Barrett M82", 2500},
            {"TRG-42", 900},
            {"Glock 19", 500},
            {"Beretta 92X", 600},
            {"CZ Evo3", 700},
            {"MP5", 700}
        };

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No need to calculate total here, as it should be calculated only on total_Click
        }

        private void tbxAmount_TextChanged(object sender, EventArgs e)
        {
            // No need to calculate total here, as it should be calculated only on total_Click
        }

        private void total_Click(object sender, EventArgs e)
        {
            // CalculateTotal();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update total if "Yes" is selected in comboBox2
            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "Yes")
            {
                // Add 1000 PHP to the existing total
                if (int.TryParse(total.Text.Replace(" PHP", ""), out int currentTotal))
                {
                    currentTotal += 1000;
                    total.Text = currentTotal.ToString() + " PHP";
                }
            }
        }
        private void UpdateAmmoQuantity(string selectedItem, int quantity)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Construct the SQL command to update the quantity
                    string query = "UPDATE Ammo SET Quantity = Quantity - @Quantity WHERE [Ammo Name] = @SelectedItem";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@SelectedItem", selectedItem);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // MessageBox.Show("Ammo quantity updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update ammo quantity.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating ammo quantity: " + ex.Message);
            }
        }
        private void Receipt_Click(object sender, EventArgs e)
        {
            string selectedItem = ComboBox1.SelectedItem?.ToString();
            string quantityStr = tbxAmount.Text.Trim();
            int quantity;
            int.TryParse(quantityStr, out quantity);

            if (selectedItem == null || quantity <= 0)
            {
                MessageBox.Show("Please select a valid item and enter a valid quantity.");
                return;
            }

            UpdateAmmoQuantity(selectedItem, quantity);

            int itemPrice = itemPrices.ContainsKey(selectedItem) ? itemPrices[selectedItem] : 0;
            int totalPrice = itemPrice * quantity;

            // Get the current date and time
            DateTime currentDate = DateTime.Now;

            // Create receipt text with current date
            string receiptText = $"Date: {currentDate}\n" +
                                 $"Item: {selectedItem}\n" +
                                 $"Quantity: {quantity}\n" +
                                 $"Item Price: {itemPrice} PHP\n" +
                                 $"Total Price: {totalPrice} PHP";

            if (comboBox2.SelectedItem?.ToString() == "Yes")
            {
                totalPrice += 1000;
                receiptText += "\nAdditional Charge (Yes in adding a Trainer): 1000 PHP";
                receiptText += $"\nUpdated Total Price: {totalPrice} PHP";
            }

            receiptText += "\n\nThank you for your purchase!";

            total.Text = receiptText; // Display receipt in the "total" label

            // Generate QR Code and convert to byte array
            QRCodeWriter qrWriter = new QRCodeWriter();
            ZXing.Common.BitMatrix qrMatrix = qrWriter.encode(receiptText, ZXing.BarcodeFormat.QR_CODE, 200, 200);
            Bitmap qrCodeImage = new Bitmap(qrMatrix.Width, qrMatrix.Height);
            for (int x = 0; x < qrMatrix.Width; x++)
            {
                for (int y = 0; y < qrMatrix.Height; y++)
                {
                    qrCodeImage.SetPixel(x, y, qrMatrix[x, y] ? Color.Black : Color.White);
                }
            }

            // Save the QR code image to the specified directory
            string saveDirectory = @"C:\Users\Dell\Desktop\QRCODES";
            Directory.CreateDirectory(saveDirectory); // Create directory if it doesn't exist
            string fileName = $"QRCode_{DateTime.Now:yyyyMMddHHmmssfff}.png"; // Unique filename based on current datetime
            string filePath = Path.Combine(saveDirectory, fileName);
            qrCodeImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            Console.WriteLine("QR Code saved to: " + filePath);

            // Add the receipt data to the database
            AddReceiptToDatabase(currentDate.ToString(), selectedItem, quantity.ToString(), totalPrice, filePath);
        }

        private void AddReceiptToDatabase(string purchaseDate, string itemName, string quantity, int totalPrice, string qrCodeImagePath)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "INSERT INTO Receipt (PurchaseDate, ItemName, Quantity, TotalPrice, QRCodeImage) VALUES (@PurchaseDate, @ItemName, @Quantity, @TotalPrice, @QRCodeImage)";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PurchaseDate", purchaseDate);
                        command.Parameters.AddWithValue("@ItemName", itemName);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                        command.Parameters.AddWithValue("@QRCodeImage", File.ReadAllBytes(qrCodeImagePath));

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Receipt added to database successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add receipt to database.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding receipt to database: " + ex.Message);
            }
        }


        private void CalculateTotal()
        {
            if (ComboBox1.SelectedItem != null && int.TryParse(tbxAmount.Text, out int quantity))
            {
                string selectedItem = ComboBox1.SelectedItem.ToString();

                if (itemPrices.ContainsKey(selectedItem))
                {
                    int totalPrice = itemPrices[selectedItem] * quantity;
                    total.Text = totalPrice.ToString() + " PHP";
                }
                else
                {
                    MessageBox.Show("Please select a valid item.");
                    ComboBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity.");
                tbxAmount.Focus();
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        /* private void SaveQRCodeAsPNG(Bitmap qrCodeImage, string filePath)
         {
             qrCodeImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
             MessageBox.Show($"QR code saved as PNG: {filePath}");
         } */
        private BarcodeReader barcodeReader;

        private void button14_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Select QR Code Image";
            dialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All Files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the selected image file
                    Image selectedImage = Image.FromFile(dialog.FileName);
                    Bitmap selectedBitmap = new Bitmap(selectedImage);

                    // Decode the QR code from the selected image
                    var result = barcodeReader.Decode(selectedBitmap);

                    if (result != null)
                    {
                        MessageBox.Show($"Scanned QR code text: {result.Text}");
                    }
                    else
                    {
                        MessageBox.Show("QR code not detected or could not be decoded.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }



        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void QR_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = true;
            panel10.Visible = true;
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb";

            // SQL query to select all columns from the Receipt table
            string query = "SELECT * FROM Receipt";

            // Initialize connection, data adapter, and dataset
            myConn = new OleDbConnection(connectionString);
            da = new OleDbDataAdapter(query, myConn);
            ds = new DataSet();

            // Open the connection, fill the dataset, and close the connection
            myConn.Open();
            da.Fill(ds, "Receipt");
            myConn.Close();

            // Set the DataGridView's DataSource to the Receipt table in the dataset
            dataGridView5.DataSource = ds.Tables["Receipt"];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Calculate the total price and total quantity sold from the dataset
            int totalPriceSum = 0;
            int totalQuantitySold = 0;

            // Check if the dataset and Receipt table are not null
            if (ds != null && ds.Tables["Receipt"] != null)
            {
                foreach (DataRow row in ds.Tables["Receipt"].Rows)
                {
                    int totalPrice, quantity;
                    if (int.TryParse(row["TotalPrice"].ToString(), out totalPrice) &&
                        int.TryParse(row["Quantity"].ToString(), out quantity))
                    {
                        totalPriceSum += totalPrice;
                        totalQuantitySold += quantity;
                    }
                }

                // Update the label with the total revenue and total quantity sold
                label32.Text = $"Total Revenue: {totalPriceSum} PHP\nTotal Magazine Sold: {totalQuantitySold} units";
            }
            else
            {
                MessageBox.Show("Error: Dataset or Receipt table is null or empty.");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (ds != null && ds.Tables["Receipt"] != null)
            {
                // Get the current date
                DateTime currentDate = DateTime.Now.Date;

                // Calculate daily revenue and daily amount sold quantity for the current date
                int dailyRevenue = CalculateDailyRevenue(currentDate);
                int dailyAmountSold = CalculateDailyAmountSold(currentDate);

                // Display the daily revenue and daily amount sold quantity in label32
                label32.Text = $"Daily Revenue ({currentDate.ToShortDateString()}): {dailyRevenue} PHP\n" +
                               $"Daily Magazine Sold: {dailyAmountSold} units";
            }
            else
            {
                MessageBox.Show("Error: Dataset or Receipt table is null or empty.");
            }
        }

        private int CalculateDailyRevenue(DateTime currentDate)
        {
            int dailyRevenue = 0;

            foreach (DataRow row in ds.Tables["Receipt"].Rows)
            {
                DateTime purchaseDate;
                int totalPrice;
                if (DateTime.TryParse(row["PurchaseDate"].ToString(), out purchaseDate) &&
                    purchaseDate.Date == currentDate &&
                    int.TryParse(row["TotalPrice"].ToString(), out totalPrice))
                {
                    dailyRevenue += totalPrice;
                }
            }

            return dailyRevenue;
        }

        private int CalculateDailyAmountSold(DateTime currentDate)
        {
            int dailyAmountSold = 0;

            foreach (DataRow row in ds.Tables["Receipt"].Rows)
            {
                DateTime purchaseDate;
                int quantity;
                if (DateTime.TryParse(row["PurchaseDate"].ToString(), out purchaseDate) &&
                    purchaseDate.Date == currentDate &&
                    int.TryParse(row["Quantity"].ToString(), out quantity))
                {
                    dailyAmountSold += quantity;
                }
            }

            return dailyAmountSold;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (ds != null && ds.Tables["Receipt"] != null)
            {
                // Get the current month and year
                DateTime currentDate = DateTime.Now;
                int currentMonth = currentDate.Month;
                int currentYear = currentDate.Year;

                // Calculate monthly revenue and monthly amount sold for the current month
                int monthlyRevenue = CalculateMonthlyRevenue(currentMonth, currentYear);
                int monthlyAmountSold = CalculateMonthlyAmountSold(currentMonth, currentYear);

                // Display the monthly revenue and monthly amount sold in label32
                label32.Text = $"Monthly Revenue ({currentDate.ToString("MMMM yyyy")}): {monthlyRevenue} PHP\n" +
                               $"Monthly Magazine Sold: {monthlyAmountSold} units";
            }
            else
            {
                MessageBox.Show("Error: Dataset or Receipt table is null or empty.");
            }
        }

        private int CalculateMonthlyRevenue(int month, int year)
        {
            int monthlyRevenue = 0;

            foreach (DataRow row in ds.Tables["Receipt"].Rows)
            {
                DateTime purchaseDate;
                int totalPrice;
                if (DateTime.TryParse(row["PurchaseDate"].ToString(), out purchaseDate) &&
                    purchaseDate.Month == month && purchaseDate.Year == year &&
                    int.TryParse(row["TotalPrice"].ToString(), out totalPrice))
                {
                    monthlyRevenue += totalPrice;
                }
            }

            return monthlyRevenue;
        }

        private int CalculateMonthlyAmountSold(int month, int year)
        {
            int monthlyAmountSold = 0;

            foreach (DataRow row in ds.Tables["Receipt"].Rows)
            {
                DateTime purchaseDate;
                int quantity;
                if (DateTime.TryParse(row["PurchaseDate"].ToString(), out purchaseDate) &&
                    purchaseDate.Month == month && purchaseDate.Year == year &&
                    int.TryParse(row["Quantity"].ToString(), out quantity))
                {
                    monthlyAmountSold += quantity;
                }
            }

            return monthlyAmountSold;
        }

        private void tbxQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // Check if a gun type is selected
            if (replenishAmmo.SelectedItem == null)
            {
                MessageBox.Show("Please select a gun type.");
                return;
            }

            // Get the selected gun ID and quantity to add
            int selectedGunID = replenishAmmo.SelectedIndex + 1; // Assuming the ComboBox items start from index 0
            int quantityToAdd;
            if (!int.TryParse(tbxUpdateQuantity.Text, out quantityToAdd))
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            try
            {
                // Update the quantity for the selected gun ID in the database
                myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
                string query = "UPDATE Ammo SET Quantity = Quantity + @QuantityToAdd WHERE AmmoID = @GunID";
                cmd = new OleDbCommand(query, myConn);
                cmd.Parameters.AddWithValue("@QuantityToAdd", quantityToAdd);
                cmd.Parameters.AddWithValue("@GunID", selectedGunID);

                myConn.Open();
                cmd.ExecuteNonQuery();
                myConn.Close();

                MessageBox.Show($"Quantity added successfully for Gun ID: {selectedGunID}");

                // Reload the database to reflect the changes
                LoadAmmoDatabase(); // Call your method to load the database here
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating quantity: " + ex.Message);
            }
        }

        private void LoadAmmoDatabase()
        {
            try
            {
                // Reload the Ammo database
                myConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Dell\\Documents\\FiringRange.accdb");
                da = new OleDbDataAdapter("SELECT * FROM Ammo", myConn); // Updated table name to Ammo
                ds = new DataSet();

                myConn.Open();
                da.Fill(ds, "Ammo"); // Updated table name to Ammo
                dataGridView4.DataSource = ds.Tables["Ammo"]; // Updated table name to Ammo
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Ammo database: " + ex.Message);
            }
        }
    }
}
