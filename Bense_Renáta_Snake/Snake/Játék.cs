using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    class Játék
    {
        public List<Pont> pontok = new List<Pont>();
        protected int fejx;
        protected int fejy;
        protected int csemegex;
        protected int csemegey;
        public void Újcsemege()
        {
            Csemege CS  = new Csemege();
        }
        public ConsoleColor alapszín = Console.ForegroundColor;
        private int p = 0;

        public int P
        {
            get { return p; }
            set { p = value; }
        }
        protected int aktívméret;
        protected int aktívszín;
        private int[,] méret = new int[3, 2];
        public int[,] Méret
        {
            get { return méret; }
            set { méret = value; }
        }
        protected void Méretezés()
        {
            this.méret[0, 0] = 30;
            this.méret[0, 1] = 15;
            this.méret[1, 0] = 60;
            this.méret[1, 1] = 30;
            this.méret[2, 0] = 110;
            this.méret[2, 1] = 55;

        }
        //Mik kellenek ide? Méret, szín, csemege x y
        public Játék()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
         {
             string[] menük = { "Start", "Pálya mérete:  ->", "Kígyó színe: <- Alapértelmezett ->", "Kilépés" };
            Menü menu = new Menü(menük);
            ConsoleColor[] tömb = new ConsoleColor[3];
            tömb[0] = ConsoleColor.Red;
            tömb[1] = ConsoleColor.Green;
            tömb[2] = ConsoleColor.Blue;
            Szuperkígyó ketto;
            menu.Színalmenük(tömb);
            if (menu.Frissítés() == 1)
            {
                Kígyó egy = new Kígyó();
                Console.Clear();
                if (menu.Aktívszín == 0) Console.ForegroundColor = menu.alapszín;
                else Console.ForegroundColor = tömb[menu.Aktívszín - 1];
                Console.SetWindowSize(menu.Méret[menu.Aktívméret, 0], menu.Méret[menu.Aktívméret, 1]);
                Console.SetBufferSize(menu.Méret[menu.Aktívméret, 0], menu.Méret[menu.Aktívméret, 1]);
                
                egy.Mozgat();
                if (egy.P == 10 && !egy.vege) { Console.Clear(); ketto = new Szuperkígyó(egy); ketto.Mozgat(); }
            }
            Console.ReadLine();
        }
    }
}
