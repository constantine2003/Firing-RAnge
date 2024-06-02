namespace Firing_RAnge
{
    partial class Ammo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ammo));
            SuspendLayout();
            // 
            // Ammo
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(732, 1050);
            DoubleBuffered = true;
            Name = "Ammo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ammo";
            Load += Ammo_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}