using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mono
{
    class játékos
    {
        string név;
        int pénz = 3000;

        public int Pénz
        {
            get { return pénz; }
            set { pénz = value; }
        }
        int pozició = 0;
        PictureBox pb;

        public játékos(string c, PictureBox kép)
        {
            this.név = c;
            this.pb = kép;
        }
        public void lepes(int mennyit, PictureBox[] keptomb, int ki,terület[] t,játékos[] j)
        {
            pozició += mennyit;
            if (pozició > 15) 
            {
                pozició -= 16;
                if (pozició == 0) this.pénz += 1000;
                else this.pénz += 500;
            }
            Point ujhely = keptomb[pozició].Location;
            if (ki == 1) ujhely.Y += 100;
            pb.Location = ujhely;
            if (t[pozició].Birtokos == "bank" && this.pénz >= t[pozició].Vételár && pozició != 12 && pozició !=5 && pozició != 0) this.vásárlás(t,ki);
            if (ki == 0 && t[pozició].Birtokos == "Zöld")
            {
                MessageBox.Show("Ráléptél a Zöld birtokára! Levontunk ennyit: " +t[pozició].Fizetendőár);
                j[0].Pénz -= t[pozició].Fizetendőár;
                j[1].Pénz += t[pozició].Fizetendőár;
            }
            if (ki==1 && t[pozició].Birtokos == "Kék")
            {
                MessageBox.Show("Ráléptél a Kék birtokára! Levontunk ennyit: " + t[pozició].Fizetendőár);
                j[1].Pénz -= t[pozició].Fizetendőár;
                j[0].Pénz += t[pozició].Fizetendőár;
            }
            string s = ki == 0? "Kék játékos!" : "Zöld játékos!";
            if (this.Pénz >= 10000)
            {
                MessageBox.Show("Gratulálunk! Megnyerted a játékot " + s);
                Environment.Exit(0);
            }
            s = ki == 0 ? "Kék játékos!" : "Zöld játékos!";
            if (this.Pénz <= 0)
            {
                MessageBox.Show("Sajnálom de a " + s + " vesztett!");
                Environment.Exit(0);
            }
            if (pozició == 5 || pozició == 12)
            {
                Random r = new Random();
                int x = r.Next(600) - 300;
                if (x >= 0) MessageBox.Show("Szerencsekártyán nyertél ennyit: " + x);
                else MessageBox.Show("Szerencsekártyán vesztettél ennyit: " + x);
                this.Pénz += x;
            }
        }
        public void vásárlás(terület[] t,int ki) 
        {
            DialogResult ered = MessageBox.Show("Megveszed a következőt: " + t[pozició].Név + "? "+ "Ára: "+ t[pozició].Vételár.ToString(),"Vásárlási lehetőség! :)",MessageBoxButtons.YesNo);
            if (ered == DialogResult.Yes)
            {
                t[pozició].Birtokos = ki == 0 ? "Kék" : "Zöld";
                pénz -= t[pozició].Vételár;
            }
        }
    }
}
