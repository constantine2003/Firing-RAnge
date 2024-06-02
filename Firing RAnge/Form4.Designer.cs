namespace Firing_RAnge
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            dataGridView1 = new DataGridView();
            tbxTrainerID = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tbxUpdate = new Button();
            tbxAvailability = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(49, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(512, 245);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // tbxTrainerID
            // 
            tbxTrainerID.BackColor = SystemColors.WindowFrame;
            tbxTrainerID.Font = new Font("Times New Roman", 9F);
            tbxTrainerID.Location = new Point(91, 311);
            tbxTrainerID.Name = "tbxTrainerID";
            tbxTrainerID.Size = new Size(150, 28);
            tbxTrainerID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 11F);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(114, 281);
            label1.Name = "label1";
            label1.Size = new Size(103, 25);
            label1.TabIndex = 3;
            label1.Text = "Trainer ID";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Times New Roman", 11F);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(346, 281);
            label2.Name = "label2";
            label2.Size = new Size(115, 25);
            label2.TabIndex = 5;
            label2.Text = "Availability";
            label2.Click += label2_Click;
            // 
            // tbxUpdate
            // 
            tbxUpdate.BackColor = Color.Linen;
            tbxUpdate.FlatStyle = FlatStyle.Popup;
            tbxUpdate.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbxUpdate.Location = new Point(232, 348);
            tbxUpdate.Name = "tbxUpdate";
            tbxUpdate.Size = new Size(112, 34);
            tbxUpdate.TabIndex = 6;
            tbxUpdate.Text = "Update";
            tbxUpdate.UseVisualStyleBackColor = false;
            tbxUpdate.Click += tbxUpdate_Click;
            // 
            // tbxAvailability
            // 
            tbxAvailability.BackColor = SystemColors.WindowFrame;
            tbxAvailability.Font = new Font("Times New Roman", 9F);
            tbxAvailability.FormattingEnabled = true;
            tbxAvailability.Items.AddRange(new object[] { "Available", "Not Available" });
            tbxAvailability.Location = new Point(329, 309);
            tbxAvailability.Name = "tbxAvailability";
            tbxAvailability.Size = new Size(150, 28);
            tbxAvailability.TabIndex = 7;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(608, 450);
            Controls.Add(tbxAvailability);
            Controls.Add(tbxUpdate);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbxTrainerID);
            Controls.Add(dataGridView1);
            DoubleBuffered = true;
            Name = "Form4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form4";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox tbxTrainerID;
        private Label label1;
        private Label label2;
        private Button tbxUpdate;
        private ComboBox tbxAvailability;
    }
}