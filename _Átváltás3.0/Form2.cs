using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Átváltás
{
    public partial class Form2 : Form
    {
        int számláló = 0;
        public Form2()
        {
            InitializeComponent();
            if (számláló == 0)
            {
                label1.Text = "Tömeg";
                label2.Text = "1t = 1000kg";
                label3.Text = "1kg = 100dkg";
                label4.Text = "1dkg = 10g";
                label5.Text = "1kg = 1000g";
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            számláló++;
            if (számláló == 1)
            {
                label1.Text = "Ürmérték";
                label2.Text = "1hl = 100l";
                label3.Text = "1l = 10dl";
                label4.Text = "1dl = 10cl";
                label5.Text = "1cl = 10ml";
                label6.Text = "1l = 100cl";
                label7.Text = "1l = 1000ml";
                label8.Text = "1cl = 100ml";
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                button4.Visible = true;
                button2.Visible = false;
                button1.Visible = true;
                button3.Visible = false;
            }
            if (számláló == 2)
            {
                label1.Text = "Hosszúság";
                label2.Text = "1km = 1000m";
                label3.Text = "1m = 10dm";
                label4.Text = "1dm = 10cm";
                label5.Text = "1cm = 10mm";
                label6.Text = "1m = 100cm";
                label7.Text = "1m = 1000mm";
                label8.Text = "1cm = 100mm";
                button4.Visible = false;
                button2.Visible = false;
                button1.Visible = false;
                button3.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            számláló--;
            if (számláló == 0)
            {
                label1.Text = "Tömeg";
                label2.Text = "1t = 1000kg";
                label3.Text = "1kg = 100dkg";
                label4.Text = "1dkg = 10g";
                label5.Text = "1kg = 1000g";
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                button4.Visible = false;
                button2.Visible = true;
                button1.Visible = false;
                button3.Visible = false;
            }
            if (számláló == 1)
            {
                label1.Text = "Ürmérték";
                label2.Text = "1hl = 100l";
                label3.Text = "1l = 10dl";
                label4.Text = "1dl = 10cl";
                label5.Text = "1cl = 10ml";
                label6.Text = "1l = 100cl";
                label7.Text = "1l = 1000ml";
                label8.Text = "1cl = 100ml";
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                button4.Visible = true;
                button2.Visible = false;
                button1.Visible = true;
                button3.Visible = false;
            }
        }
    }
}
