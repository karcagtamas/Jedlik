using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mono
{
    public partial class Form1 : Form
    {
        terület[] teruletek = new terület[16];
        játékos[] játékosok = new játékos[2];
        PictureBox[] képtomb = new PictureBox[16];
        int kikovetkezik = 0;
        
        public Form1()
        {
            InitializeComponent();
            this.teruletletrehozo();
            this.játékoslétrehozó();
            this.képtömb();
            if (kikovetkezik == 0) LabelKiJon.Text = "Ez a játékos dobhat: Kék";
            else LabelKiJon.Text = "Ez a játékos dobhat: Zöld";
            LabelKekPenz.Text = "Kék játékos pénze: " + játékosok[0].Pénz.ToString();
            LabelZoldPenz.Text = "Zöld játékos pénze: " + játékosok[1].Pénz.ToString();

            
        }
        public void teruletletrehozo()
            {
            teruletek[0] = new terület("Start", 0, -2000, false);
            teruletek[1] = new terület("Sziget", 600, 200, true);
            teruletek[2] = new terület("Révfalu", 700, 300, true);
            teruletek[3] = new terület("Ady-város", 1200, 500, true);
            teruletek[4] = new terület("Belváros", 1000, 350, true);
            teruletek[5] = new terület("Szerencsekártya", 0, 0, false);
            teruletek[6] = new terület("Csanak", 900, 400, true);

            teruletek[7] = new terület("Gyirmót", 1400, 350, true);
            teruletek[8] = new terület("Szabadhegy", 2500, 1100, true);
            teruletek[9] = new terület("Szent István út", 1000, 450, true);
            teruletek[10] = new terület("Szentiván", 2200, 700, true);
            teruletek[11] = new terület("Újváros", 2100, 800, true);
            teruletek[12] = new terület("Szerencsekártya", 0, 0, false);

            teruletek[13] = new terület("Marcalváros", 1700, 500, true);
            teruletek[14] = new terület("Nádorváros", 1800, 600, true);
            teruletek[15] = new terület("Gyárváros", 4000, 1500, true);
            }
        public void játékoslétrehozó()
        {
            játékosok[0] = new játékos("kék",PictureBabu1);
            játékosok[1] = new játékos("zöld",PictureBabu2);
        }
        public void képtömb()
        {
            képtomb[0] = pictureBox1;
            képtomb[1] = pictureBox2;
            képtomb[2] = pictureBox3;
            képtomb[3] = pictureBox4;
            képtomb[4] = pictureBox5;
            képtomb[5] = pictureBox6;
            képtomb[6] = pictureBox7;
            képtomb[7] = pictureBox8;
            képtomb[8] = pictureBox9;
            képtomb[9] = pictureBox10;
            képtomb[10] = pictureBox11;
            képtomb[11] = pictureBox12;
            képtomb[12] = pictureBox13;
            képtomb[13] = pictureBox14;
            képtomb[14] = pictureBox15;
            képtomb[15] = pictureBox16;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int dobás = r.Next(1, 7);
            PictureKocka.ImageLocation = "..\\..\\Resources\\kocka" + dobás.ToString() + ".png";
            játékosok[kikovetkezik].lepes(dobás,képtomb,this.kikovetkezik,teruletek,játékosok);
            if (kikovetkezik == 0) kikovetkezik = 1;
            else kikovetkezik = 0;
            if (kikovetkezik == 0) LabelKiJon.Text = "Ez a játékos dobhat: Kék";
            else LabelKiJon.Text = "Ez a játékos dobhat: Zöld";
            LabelKekPenz.Text = "Kék játékos pénze: " + játékosok[0].Pénz.ToString();
            LabelZoldPenz.Text = "Zöld játékos pénze: " + játékosok[1].Pénz.ToString();

        }

        private void PictureBabu1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LabelKekPenz_Click(object sender, EventArgs e)
        {

        }
    }
}
