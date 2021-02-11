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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[] ez;
        Button[] ez2;
        Label[] feladat;
        TextBox[] megoldások;
        string mérték;
        string nehézség;
        int[] tömeg = { 1000, 100, 10 };
        string[] tömegs = { "t", "kg", "dkg", "g" };
        int[] hosszúság = { 1000, 10, 10, 10 };
        string[] hosszúságs = { "km", "m", "dm", "cm", "mm" };
        int[] ürmérték = { 100, 10, 10, 10 };
        string[] ürmértéks = { "hl", "l", "dl", "cl", "ml" };
        int[] megoldás  = new int[10];
        int[] index = new int[10];

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void eltüntetés()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i < 3)
                {
                    ez[i].Visible = false;
                    ez2[i].Visible = false;
                }
                feladat[i].Visible = false;
                megoldások[i].Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                label12.Visible = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ez = new Button[] { button1, button2, button3 };
            ez2 = new Button[] { button4, button5, button6 };
            feladat = new Label[] { label2, label3, label4, label5, label6, label7, label8, label9, label10, label11 };
            megoldások = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10 };
            eltüntetés();
            foreach (var i in ez)
            {
                i.Visible = true;
            }
            button12.Visible = true;
            if (this.Width == Screen.PrimaryScreen.Bounds.Width)
            {
                button13.Visible = false;
            }
            else
            {
                button13.Visible = true;
            }
            button11.Visible = false;
            button10.Visible = false;
            //foreach (var i in megoldások)
            //{
            //    i.Text = null;
            //}
            //for (int i = 0; i < megoldás.Length; i++)
            //{
            //    megoldás[i] = 0;
            //}
        }
        private void button1_Click(object sender, EventArgs e)
        {
            eltüntetés();
            //foreach (var i in megoldások)
            //{
            //    i.Text = null;
            //}
            //for (int i = 0; i < megoldás.Length; i++)
            //{
            //    megoldás[i] = 0;
            //}
            var Senderr = (Button)sender;
            int választott = 0;
            mérték = Senderr.Text;
            label1.Text = mérték;
            for (int i = 0; i != ez.Length; i++)
            {
                ez[i].Visible = false;
                ez2[i].Visible = true;
                if (ez[i] == Senderr) választott = i + 1;
            }
            label1.Text = "Válassz nehézséget!";
            button10.Visible = true;
            ez2[1].Visible = false;
            ez2[2].Visible = false;
            button12.Visible = false;
            button13.Visible = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //eltüntetés();
            var Senderr = (Button)sender;
            int választott = 0;
            nehézség = Senderr.Text;
            for (int i = 0; i != ez2.Length; i++)
            {
                ez2[i].Visible = false;
                if (ez2[i] == Senderr) választott = i + 1;
            }
            label1.Text = mérték + " (" + nehézség + ")";
            button7.Visible = true;
            button11.Visible = true;
            button10.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void könnyű(Random r, int[] megoldás)
        {
            for (int i = 0; i < 10; i++)
            {
                megoldások[i].ForeColor = Color.Black;
                int x = r.Next(100);
                int honnan = r.Next(mérték == "Tömeg" ? 3 : 4);
                int hova = r.Next(honnan + 1, mérték == "Tömeg" ? 4 : 5);
                if (honnan == 0) hova = 1;
                int vált = honnan;
                int szórzandó = 1;
                int y = r.Next(100);
                if (mérték == "Tömeg")
                {
                    while (vált != hova)
                    {
                        szórzandó = szórzandó * tömeg[vált];
                        vált++;
                    }
                    feladat[i].Text = y.ToString() + " " + tömegs[honnan];
                    megoldások[i].Text = " " + tömegs[hova];
                }
                if (mérték == "Űrmérték")
                {
                    while (vált != hova)
                    {
                        szórzandó = szórzandó * ürmérték[vált];
                        vált++;
                    }
                    feladat[i].Text = y.ToString() + " " + ürmértéks[honnan];
                    megoldások[i].Text = " " + ürmértéks[hova];
                }
                if (mérték == "Hosszúság")
                {
                    while (vált != hova)
                    {
                        szórzandó = szórzandó * hosszúság[vált];
                        vált++;
                    }
                    feladat[i].Text = y.ToString() + " " + hosszúságs[honnan];
                    megoldások[i].Text = " " + hosszúságs[hova];
                }
                megoldás[i] = y * szórzandó;
                feladat[i].Visible = true;
                megoldások[i].Visible = true;
                index[i] = hova;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            if (nehézség == "Könnyű") könnyű(r, megoldás);
            label12.Visible = false;
            button7.Visible = false;
            button8.Visible = true;
            button9.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string[] adottstring = new string[10];
            int[] adottint = new int[10];
            int helyes = 0;
            for (int i = 0; i < 10; i++)
            {
                adottstring[i] = megoldások[i].Text.ToString();
                for (int j = 0; j < adottstring[i].Length; j++)
                {
                    if (adottstring[i][j] < 48 || adottstring[i][j] > 57)
                    {
                        adottstring[i] = adottstring[i].Remove(j, 1);
                        j--;
                    }
                }
                string segéd = adottstring[i];
                //string segéd = (adottstring[i].Remove(adottstring[i].IndexOf(' '))).ToString();
                try
                {
                    adottint[i] = int.Parse(segéd);
                }
                catch (Exception)
                {
                    adottint[i] = 0;
                }
                if (adottint[i] == megoldás[i])
                {
                    megoldások[i].ForeColor = Color.Green;
                    if (mérték == "Tömeg") megoldások[i].Text = megoldás[i].ToString() + " " + tömegs[index[i]];
                    if (mérték == "Űrmérték") megoldások[i].Text = megoldás[i].ToString() + " " + ürmértéks[index[i]];
                    if (mérték == "Hosszúság") megoldások[i].Text = megoldás[i].ToString() + " " + hosszúságs[index[i]];
                    helyes++;
                }
                else
                {
                    megoldások[i].ForeColor = Color.Red;
                    if (mérték == "Tömeg") megoldások[i].Text = megoldás[i].ToString() + " " + tömegs[index[i]];
                    if (mérték == "Űrmérték") megoldások[i].Text = megoldás[i].ToString() + " " + ürmértéks[index[i]];
                    if (mérték == "Hosszúság") megoldások[i].Text = megoldás[i].ToString() + " " + hosszúságs[index[i]];
                }
            }
            label12.Text = helyes.ToString() + "/10";
            helyes = 0;
            label12.Visible = true;
            button7.Visible = true;
            button8.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form2 m = new Form2();
            m.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.SetDesktopLocation(0, 0);
            button13.Visible = false;
            //label1.Location.X = (this.Width / 2) - label1.Width;
            //label1.Location.X = 0;
            label1.Location = new Point((this.Width / 2) - (label1.Width / 2), 50);
            int számláló = 1;
            int szorzó = 1;
            int plus = 100;
            foreach (var i in feladat)
            {
                if (számláló % 2 == 1)
                {
                    i.Location = new Point((this.Width / 4) + 25, 50 * szorzó + plus);
                }
                else
                {
                    i.Location = new Point((this.Width / 2) + (i.Width / 4) + 25, 50 * szorzó + plus);
                    szorzó++;
                }
                számláló++;
            }
            számláló = 1;
            szorzó = 1;
            plus = 100;
            foreach (var i in megoldások)
            {
                if (számláló % 2 == 1)
                {
                    i.Location = new Point((this.Width / 4) + 100 + 25, 50 * szorzó + plus);
                }
                else
                {
                    i.Location = new Point((this.Width / 2) + (i.Width / 4) + 100 + 25, 50 * szorzó + plus);
                    szorzó++;
                }
                számláló++;
            }
            label12.Location = new Point(label10.Location.X - 25, label10.Location.Y + 75);
            button7.Location = new Point(label10.Location.X + 50, label10.Location.Y + 75);
            button8.Location = new Point(label10.Location.X + 50,label10.Location.Y + 75);
            button10.Location = new Point(button8.Location.X + 200, button8.Location.Y);
            button11.Location = new Point(button8.Location.X + 200, button8.Location.Y);
            button9.Location = new Point(button11.Location.X + 200, button11.Location.Y);
            button13.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 500, 0);
            button12.Location = new Point(button13.Location.X + 25, button13.Location.Y + 225);
            button1.Location = new Point(button11.Location.X, button11.Location.Y - 250);
            button4.Location = button1.Location;
            button2.Location = new Point(button11.Location.X, button11.Location.Y - 200);
            button5.Location = button2.Location;
            button3.Location = new Point(button11.Location.X, button11.Location.Y - 150);
            button6.Location = button3.Location;
        }
    }
}
