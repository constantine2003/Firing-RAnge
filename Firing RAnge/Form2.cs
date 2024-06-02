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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel2.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel3.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel4.Visible = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel1.Visible = true;
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        private void pictureBox23_Click(object sender, EventArgs e)
        {
            Ammo F5 = new Ammo();
            F5.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            // Build the gun description
            string gunDescription = "Gun Name: Remington 700\n" +
                                    "Manufacturer: Remington Arms Company\n" +
                                    "Type/Category: Bolt-Action Rifle\n" +
                                    "Caliber: .308 Winchester\n" +
                                    "Action: Bolt-Action\n" +
                                    "Magazine Capacity: 4 rounds (internal magazine); detachable magazines available in various capacities\n" +
                                    "Sights: Typically includes iron sights; compatible with various scopes\n" +
                                    "Materials: Steel receiver and barrel; various stock materials (e.g., wood, synthetic)\n" +
                                    "Features: Adjustable trigger, detachable magazine, robust build for accuracy and reliability\n" +
                                    "Usage: Suitable for hunting, target shooting, and long-range precision shooting\n";

            // Update the label text with the gun description
            description.Text = gunDescription;
        }

        private void ar15_Click(object sender, EventArgs e)
        {
            // Build the gun description
            string gunDescription = "Gun Name: AR-15\n" +
                                    "Manufacturer: Various manufacturers (e.g., Colt, Smith & Wesson, Ruger)\n" +
                                    "Type/Category: Semi-automatic rifle\n" +
                                    "Caliber: 5.56x45mm NATO (.223 Remington), .300 Blackout, .308 Winchester, etc.\n" +
                                    "Action: Gas-operated, rotating bolt\n" +
                                    "Magazine Capacity: Typically 30-round detachable magazine (varies by model)\n" +
                                    "Sights: Usually includes iron sights; compatible with various optics and accessories\n" +
                                    "Materials: Aluminum alloy upper and lower receivers, polymer furniture\n" +
                                    "Features: Customizable platform with a wide range of aftermarket parts and accessories\n" +
                                    "Usage: Versatile rifle suitable for various applications including self-defense, sport shooting, and hunting\n";

            // Update the label text with the gun description
            description.Text = gunDescription;
        }

        private void barretm82_Click(object sender, EventArgs e)
        {
            // Build the gun description
            string gunDescription = "Gun Name: Barrett M82\n" +
                                    "Manufacturer: Barrett Firearms Manufacturing\n" +
                                    "Type/Category: Anti-materiel sniper rifle\n" +
                                    "Caliber: .50 BMG (12.7x99mm NATO)\n" +
                                    "Action: Recoil-operated, semi-automatic\n" +
                                    "Magazine Capacity: 10-round detachable box magazine\n" +
                                    "Sights: Usually equipped with high-powered optics for long-range precision shooting\n" +
                                    "Materials: Steel receiver and barrel; various stock materials (e.g., aluminum alloy, polymer)\n" +
                                    "Features: High firepower, long effective range, heavy-duty construction\n" +
                                    "Usage: Primarily used for anti-materiel and long-range sniper applications\n";

            // Update the label text with the gun description
            description.Text = gunDescription;
        }

        private void trg42_Click(object sender, EventArgs e)
        {
            // Build the gun description
            string gunDescription = "Gun Name: TRG-42\n" +
                                    "Manufacturer: Sako (a subsidiary of Beretta)\n" +
                                    "Type/Category: Bolt-Action Sniper Rifle\n" +
                                    "Caliber: .338 Lapua Magnum, .300 Winchester Magnum, .308 Winchester\n" +
                                    "Action: Bolt-Action\n" +
                                    "Magazine Capacity: 10-Round detachable box magazine \n" +
                                    "Sights: Usually equipped with high-powered optics for long-range precision shooting\n" +
                                    "Materials: Steel receiver and barrel; various stock materials (e.g., aluminum alloy, synthetic)\n" +
                                    "Features: Adjustable trigger, ergonomic design, accuracy-enhancing features\n" +
                                    "Usage: Primarily used by military and law enforcement snipers, as well as civilian long-range shooters\n";

            // Update the label text with the gun description
            description.Text = gunDescription;
        }


        private void pictureBox18_Click(object sender, EventArgs e)
        {
            // Build the gun description
            string gunDescription = "Gun Name: Glock 19\n" +
                                    "Manufacturer: Glock Ges.m.b.H.\n" +
                                    "Type/Category: Semi-automatic Pistol\n" +
                                    "Caliber: 9x19mm Parabellum\n" +
                                    "Action: Short recoil, locked breech\n" +
                                    "Magazine Capacity: Standard 15-round magazine (varies by region)\n" +
                                    "Sights: Fixed sights; compatible with various aftermarket sights\n" +
                                    "Materials: Polymer frame, steel slide\n" +
                                    "Features: Safe-action trigger system, lightweight, compact size\n" +
                                    "Usage: Popular choice for law enforcement, military, and civilian self-defense\n";

            // Update the label text with the gun description
            description.Text = gunDescription;
        }

        private void beretta92x_Click(object sender, EventArgs e)
        {
            // Build the gun description
            string gunDescription = "Gun Name: Beretta 92X\n" +
                                    "Manufacturer: Fabbrica d'Armi Pietro Beretta S.p.A.\n" +
                                    "Type/Category: Semi-automatic Pistol\n" +
                                    "Caliber: 9x19mm Parabellum\n" +
                                    "Action: Short recoil, locked breech\n" +
                                    "Magazine Capacity: Standard 15-round magazine\n" +
                                    "Sights: Fixed or adjustable sights\n" +
                                    "Materials: Aluminum alloy frame, steel slide\n" +
                                    "Features: Open-slide design, ambidextrous safety/decocker, ergonomic grip\n" +
                                    "Usage: Used by military, law enforcement, and civilians worldwide\n";

            // Update the label text with the gun description
            description.Text = gunDescription;
        }

        private void czevo3_Click(object sender, EventArgs e)
        {
            // Build the gun description
            string gunDescription = "Gun Name: CZ Evo 3\n" +
                                    "Manufacturer: Česká zbrojovka Uherský Brod\n" +
                                    "Type/Category: Submachine Gun\n" +
                                    "Caliber: 9x19mm Parabellum\n" +
                                    "Action: Blowback-operated, selective-fire\n" +
                                    "Magazine Capacity: Standard 30-round magazine\n" +
                                    "Sights: Adjustable iron sights; compatible with various optics\n" +
                                    "Materials: Polymer frame, steel components\n" +
                                    "Features: Folding stock, ambidextrous controls, compact size\n" +
                                    "Usage: Military, law enforcement, and civilian applications\n";

            // Update the label text with the gun description
            description.Text = gunDescription;
        }

        private void mp5_Click(object sender, EventArgs e)
        {
            // Build the gun description
            string gunDescription = "Gun Name: MP5\n" +
                                    "Manufacturer: Heckler & Koch GmbH\n" +
                                    "Type/Category: Submachine Gun\n" +
                                    "Caliber: 9x19mm Parabellum\n" +
                                    "Action: Roller-delayed blowback, selective-fire\n" +
                                    "Magazine Capacity: Standard 30-round magazine\n" +
                                    "Sights: Adjustable iron sights; compatible with various optics\n" +
                                    "Materials: Steel receiver, polymer furniture\n" +
                                    "Features: Compact design, low recoil, reliable operation\n" +
                                    "Usage: Widely used by military, law enforcement, and special forces\n";

            // Update the label text with the gun description
            description.Text = gunDescription;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
