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
    public partial class Ammo : Form
    {
        public Ammo()
        {
            InitializeComponent();
            this.Load += Ammo_Load;
        }

        private void Ammo_Load(object sender, EventArgs e)
        {
            this.Size = new Size(754, 1106);
        }
    }
}
