using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Szuperkigyó : Kigyó
    {
        public Szuperkigyó(Kigyó k):base (k)
        {
            this.Gombok();
        }
        protected override void Gombok()
        {
             ConsoleKey k;
            do
            {
                while (!Console.KeyAvailable)
                {
                    Console.Title = "Pontok: " + this.l.Count.ToString() + "    " + "Lépések: " + this.Steps.ToString() + "    " + "Sebesség: " + this.Speed.ToString();
                    //Console.Title = "Pontok: " + this.Long.ToString();
                    this.Mozgás();
                }
                k = Console.ReadKey(true).Key;
                if (k == ConsoleKey.UpArrow || k == ConsoleKey.W) if(this.Last != 3) Irány = 1;
                if (k == ConsoleKey.RightArrow || k == ConsoleKey.D) if (this.Last != 4) Irány = 2;
                if (k == ConsoleKey.DownArrow || k == ConsoleKey.S) if (this.Last != 1) Irány = 3;
                if (k == ConsoleKey.LeftArrow || k == ConsoleKey.A) if (this.Last != 2) Irány = 4;
                if (Szivárvány()) k = ConsoleKey.F1;
            } while (k != ConsoleKey.Escape && k != ConsoleKey.F1);
            if (k == ConsoleKey.Escape) Environment.Exit(0);
        }
        protected override void Mozgás()
        {
            Thread.Sleep(this.Speed);
            if (this.Csemegek())
            {
                this.Long++;
                Adatok a = new Adatok();
                a.X = l[0].X;
                a.Y = l[0].Y;
                a.Ch = l[0].Ch;
                this.l.Insert(0, a);
            }
            if (this.ÖnHarapás()) this.Rajzol();
            else this.Halál();
            if ((double)this.Long % 5 == 0 && this.Long >= 20 && növelés == this.Long / 5 - 4) { this.Speed = this.Speed - 2; növelés++; };
        }
        protected override void Bevitel()
        {
            l.RemoveRange(0, 1);
            this.karakter(1);
            Adatok a = new Adatok();
            int x = this.l[this.l.Count - 1].X;
            int y = this.l[this.l.Count - 1].Y;
            switch (this.Irány)
            {
                case 1: a.X = x; if (y - 1 <= 1) a.Y = Console.WindowHeight - 3; else a.Y = y - 1; this.Last = this.Irány; break;
                case 2: if (x + 1 >= Console.WindowWidth - 2) a.X = 2; else a.X = x + 1; a.Y = y; this.Last = this.Irány; break;
                case 3: a.X = x; if (y + 1 >= Console.WindowHeight - 2) a.Y = 2; else a.Y = y + 1; this.Last = this.Irány; break;
                case 4: if (x - 1 <= 2) a.X = Console.WindowWidth - 3; else a.X = x - 1; a.Y = y; this.Last = this.Irány; break;
            }
            this.Steps++;
            a.Ch = this.head;
            l.Add(a);
        }
        private bool Szivárvány()
        {
            if (this.Long >= 100) return true;
            return false;
        }
    }
}
