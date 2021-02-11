using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Órarend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Hálózatok gyakorlat(1. óra/203)";
            textBox2.Text = "Hálózatok gyakorlat(2. óra/203)";
            textBox3.Text = "Angol(3. óra/T5)";
            textBox4.Text = "Történelem(4. óra/209)";
            textBox5.Text = "Testnevelés(5. óra)";
            textBox6.Text = "Magyar(6. óra/15)";
            textBox7.Text = "Művészetek(7. óra/15)";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Fizika(1. óra/212)";
            textBox2.Text = "Testnevelés(2. óra)";
            textBox3.Text = "Magyar(3. óra/14)";
            textBox4.Text = "Osztályfőnöki(4. óra/104)";
            textBox5.Text = "Földrajz(5. óra/205)";
            textBox6.Text = "Abs gyakorlat(6. óra/102)";
            textBox7.Text = "Abs gyakorlat(7. óra/102)";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "Hálózatok(1. óra/203)";
            textBox2.Text = "Fizika(2. óra/106)";
            textBox3.Text = "Informatika(3. óra/203)";
            textBox4.Text = "Informatika(4. óra/203)";
            textBox5.Text = "Kémia(5. óra/112)";
            textBox6.Text = "Matek(6. óra/022)";
            textBox7.Text = "Testnevelés(7. óra/15)";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Matek felkészítő(0. óra/14)";
            textBox2.Text = "Biológia(1. óra/14)";
            textBox3.Text = "Angol(2. óra/T4)";
            textBox4.Text = "Angol(3. óra/T4)";
            textBox5.Text = "Matek(4. óra/108)";
            textBox6.Text = "Magyar(5. óra/104)";
            textBox7.Text = "Történelem(6. óra/208)";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Angol(1. óra/104)";
            textBox2.Text = "Angol(2. óra/104)";
            textBox3.Text = "Biológia(3. óra/41)";
            textBox4.Text = "Magyar(4. óra/14)";
            textBox5.Text = "Matek(5. óra/207)";
            textBox6.Text = "Abs elmélet(6. óra/102)";
            textBox7.Text = "Abs elmélet(7. óra/102)";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
    }
}
