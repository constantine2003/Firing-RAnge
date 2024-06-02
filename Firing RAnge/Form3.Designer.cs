namespace Firing_RAnge
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            pictureBox1 = new PictureBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            button1 = new Button();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            label1 = new Label();
            pictureBox5 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(450, 166);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(449, 251);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = SystemColors.HotTrack;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Times New Roman", 9F);
            txtUsername.ForeColor = SystemColors.Info;
            txtUsername.Location = new Point(55, 215);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(280, 28);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.HotTrack;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Times New Roman", 9F);
            txtPassword.ForeColor = SystemColors.Info;
            txtPassword.Location = new Point(55, 274);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(280, 28);
            txtPassword.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(48, 324);
            button1.Name = "button1";
            button1.Size = new Size(295, 41);
            button1.TabIndex = 3;
            button1.Text = "LOG IN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Black;
            pictureBox2.Location = new Point(440, 155);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(19, 276);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Black;
            pictureBox3.Location = new Point(895, 155);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(19, 276);
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(146, 414);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(446, 282);
            pictureBox4.TabIndex = 7;
            pictureBox4.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Modern No. 20", 26F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(496, 110);
            label1.Name = "label1";
            label1.Size = new Size(371, 53);
            label1.TabIndex = 8;
            label1.Text = "SHOOTIN DEN";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.BackgroundImage = (Image)resources.GetObject("pictureBox5.BackgroundImage");
            pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox5.Location = new Point(245, 49);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(50, 50);
            pictureBox5.TabIndex = 9;
            pictureBox5.TabStop = false;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(955, 599);
            Controls.Add(pictureBox5);
            Controls.Add(label1);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(button1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(pictureBox1);
            DoubleBuffered = true;
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button button1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label label1;
        private PictureBox pictureBox5;
    }
}