using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Snake
{
    class Kigyó 
    {
        //protected List<Kordináta> l = new List<Kordináta>();
        protected List<Adatok> l = new List<Adatok>();
        protected List<Csemege> csl = new List<Csemege>();
        protected int Long = 10;
        protected ConsoleColor c = ConsoleColor.White;
        protected char head = 'O';
        //protected char body = 'O';
        protected char lj = '┌';
        protected char lb = '┐';
        protected char fj = '└';
        protected char fb = '┘';
        protected char vizszint = '─';
        protected char függ = '│';
        protected int speed = 100;
        private int steps = 0;

        protected int Steps
        {
            get { return steps; }
            set { if (value >= 0) steps = value; }
        }
        public int Speed
        {
            get { return speed; }
            set {if (value > 20 && value <= 200) speed = value; }
        }
        private int irány = 1;
        protected int Irány
        {
            get { return irány; }
            set { if (value >= 1 && value <= 4) irány = value; }
        }
        private int last = 1;
        protected int Last
        {
            get { return last; }
            set { if(value >= 1 && value <= 4) last = value; }
        }
        private int gold = 0;
        protected int GOLD
        {
            get { return gold; }
            set 
            { 
                try
                {
                    gold = value;
                }
                catch
                {
                    gold = 0;
                }
            }
        }
        protected int növelés = 0;
        public Kigyó(int seb)
        {
            this.fal();
            this.GOLD = this.Gold();
            this.Speed = seb;
            for (int i = 0; i < 30; i++)
            {
                Csemege cs = new Csemege();
                Random r = new Random();
                do
                {
                    cs.X = r.Next(3, Console.WindowWidth - 3);
                    cs.Y = r.Next(3, Console.WindowHeight - 3);
                } while (this.csk(cs.X,cs.Y));
                Thread.Sleep(5);
                csl.Add(cs);
                cs.Csemege_Kirajzol();
            }
            for (int i = 0; i < this.Long; i++)
            {
                //Kordináta k = new Kordináta();
                //k.X = Console.WindowWidth / 2;
                //k.Y = 50 - i;
                //this.l.Add(k);
                Adatok a = new Adatok();
                a.X = Console.WindowWidth / 2;
                a.Y = 25 - i;
                if (i == this.Long - 1) a.Ch = this.head;
                else a.Ch = this.függ;
                this.l.Add(a);
            }
            this.Rajz();
            this.Gombok();
        }//Kigyó adatait generálja
        protected Kigyó(Kigyó k)
        {
            this.l = k.l;
            this.csl = k.csl;
            this.c = ConsoleColor.Magenta;
            this.Long = k.Long;
            this.Speed = k.Speed;
            this.Irány = k.Irány;
            this.Last = k.Last;
            this.GOLD = k.GOLD;
            this.növelés = k.növelés;

        }
        protected virtual void Rajz()
        {
            foreach (Adatok i in this.l)
            {
                Console.ForegroundColor = this.c;
                Console.SetCursorPosition(i.X, i.Y);
                Console.Write(i.Ch);
            }
            this.karakter(0);
        }//Kirajzolja az alapkigyót
        protected virtual void Rajzol()
        {
            Console.ForegroundColor = c;
            Console.SetCursorPosition(this.l[0].X, this.l[0].Y);
            Console.WriteLine(" ");
            this.Bevitel();
            Console.SetCursorPosition(this.l[this.l.Count - 2].X, this.l[this.l.Count - 2].Y);
            Console.Write(this.l[this.l.Count - 2].Ch);
            Console.SetCursorPosition(this.l[this.l.Count - 1].X, this.l[this.l.Count - 1].Y);
            Console.Write(this.l[this.l.Count - 1].Ch);
        }//A kigyót mozgatását rajzolja
        protected virtual void Bevitel()
        {
            l.RemoveRange(0, 1);
            this.karakter(1);
            Adatok a = new Adatok();
            int x = this.l[this.l.Count - 1].X;
            int y = this.l[this.l.Count - 1].Y;
            switch (this.Irány)
            {
                case 1: a.X = x; a.Y = y - 1; this.Last = this.Irány; break;
                case 2: a.X = x + 1; a.Y = y; this.Last = this.Irány; break;
                case 3: a.X = x; a.Y = y + 1; this.Last = this.Irány; break;
                case 4: a.X = x - 1; a.Y = y; this.Last = this.Irány; break;
            }
            this.Steps++;
            a.Ch = this.head;
            this.l.Add(a);
        }//Új fej meghatározása
        protected virtual void Gombok()
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
                if (SzuperKigyó()) k = ConsoleKey.F1;
            } while (k != ConsoleKey.Escape && k != ConsoleKey.F1);
            if (k == ConsoleKey.Escape) Environment.Exit(0);
        }//Gomb érzékelés
        protected virtual void Mozgás()
        {
            Thread.Sleep(this.Speed);
            if (this.Kintvane()) this.Halál();
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
            //if (this.l.Count == 15 || this.l.Count == 55) { falszint++; this.fal(falszint); }
            //else if (this.l.Count == 40 || this.l.Count == 35 || this.l.Count == 30) this.Speed = this.Speed - 5;
            //if (this.Long == 40 || this.Long == 35 || this.Long == 30) this.Speed = this.Speed - 2;
            if ((double)this.Long % 5 == 0 && this.Long >= 20 && növelés == this.Long / 5 - 4) { this.Speed = this.Speed - 2; növelés++; };
        }//Mozgást hangolja össze
        protected bool ÖnHarapás()
        {
            int db = 0;
            foreach (var i in this.l)
            {
                //if (i == this.l[this.l.Count - 1]) db++;
                if (i.X == this.l[this.l.Count - 1].X && i.Y == this.l[this.l.Count - 1].Y) db++;
            }
            if (db == 2) return false;
            return true;
        }//Önharapást ellenörzi
        protected void Halál()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - ("Meghaltál!".Length / 2), Console.WindowHeight / 2 - 5);
            Console.WriteLine("Meghaltál!");
            Console.SetCursorPosition((Console.WindowWidth / 2) - ("Eddig összesen összegyűjtött arany:     ".Length / 2), Console.WindowHeight / 2);
            Console.WriteLine("Eddig összesen összegyűjtött arany: " + this.GOLD.ToString());
            Console.SetCursorPosition((Console.WindowWidth / 2) - ("(Nyomj Entert)".Length / 2), Console.WindowHeight / 2 + 5);
            Console.WriteLine("(Nyomj Entert)");
            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - ("Eredménye:    ".Length / 2), Console.WindowHeight / 2);
            Console.WriteLine("Eredménye: {0}",this.l.Count);
            Console.SetCursorPosition((Console.WindowWidth / 2) - ("Adja meg a nevét:           ".Length / 2), Console.WindowHeight / 2 + 5);
            Console.Write("Adja meg a nevét: ");
            this.Stat(Console.ReadLine());
            StreamWriter sw = new StreamWriter("gold.txt",false);
            sw.WriteLine(this.GOLD.ToString());
            sw.Flush();
            sw.Close();
            //Environment.Exit(0);
            Console.Clear();
            Játék j = new Játék();
        }//Halál
        protected void Stat(string s)
        {
            StreamWriter sw = new StreamWriter("stat.txt",true);
            sw.WriteLine(s +";"+ this.l.Count.ToString()+";"+this.Steps.ToString());
            sw.Flush();
            sw.Close();
        }//Statisztika elmentése
        protected bool Kintvane()
        {
            //foreach (Kordináta i in this.l)
            //{
            //    if (i.X <= falszint + 1 || i.X >= Console.WindowWidth - (2 * (falszint + 1)) || i.Y <= falszint + 1 || i.Y >= Console.WindowHeight - (2 * (falszint + 1))) return true;
            //}
            if (this.l[this.l.Count - 1].X <= 1 || this.l[this.l.Count - 1].X >= Console.WindowWidth - 2 || this.l[this.l.Count - 1].Y <=  1 || this.l[this.l.Count - 1].Y >= Console.WindowHeight - 2) return true;
            return false;
        }//Azt ellenörzi hogy kilépet-e a kigyó a pályáról
        protected bool Csemegek()
        {
            bool igaze = false;
            int sz = -1;
            int n = 0;
                foreach (Csemege j in this.csl)
                {
                    sz++;
                    if (j.X == this.l[this.l.Count - 1].X && j.Y == this.l[this.l.Count - 1].Y) 
                    {
                        n = sz;
                        igaze = true; 
                    }
                }
                if (igaze)
                {
                    if (csl[n].C == ConsoleColor.Red)
                    {
                        this.Speed = this.Speed - 2;
                    }
                    if (csl[n].C == ConsoleColor.Blue)
                    {
                        this.Speed = this.Speed + 2;
                    }
                    if (csl[n].C == ConsoleColor.Yellow)
                    {
                        this.GOLD++;
                        for (int i = 0; i < 4; i++)
                        {
                            this.Long++;
                            Adatok a = new Adatok();
                            a.X = l[0].X;
                            a.Y = l[0].Y;
                            a.Ch = l[0].Ch;
                            this.l.Insert(0, a);
                        }
                    }
                    if (csl[n].C == ConsoleColor.Cyan)
                    {
                        this.Halál();
                    }
                    if (this.l.Count == 100 || this.l.Count == 150 || this.l.Count == 200)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            this.cst();
                        }
                    }
                    csl.RemoveAt(n);
                    Csemege cs = new Csemege();
                    Random r = new Random();
                    do
                    {
                        cs.X = r.Next(3, Console.WindowWidth - 3);
                        cs.Y = r.Next(3, Console.WindowHeight - 3);
                    } while (this.csk(cs.X, cs.Y));
                    Thread.Sleep(5);
                    csl.Add(cs);
                    cs.Csemege_Kirajzol();
                }
            return igaze;
        }//Azt ellenörzi hogy nem ért-e egy csemegéhez
        protected bool SzuperKigyó()
        {
            if (this.Long >= 35) return true;
            return false;
        }//Azt ellenörzi hogy mikor kell aktiválni a Szuperkigyót
        protected int Gold()
        {
            StreamReader sr = new StreamReader("gold.txt");
            int x = int.Parse(sr.ReadLine());
            sr.Close();
            if (x >= 150) this.c = ConsoleColor.Green;
            else if (x >= 100) this.c = ConsoleColor.DarkCyan;
            else if (x >= 50) this.c = ConsoleColor.Yellow;
            return x;
        }
        protected void fal()
        {
            Fal f = new Fal(1, 1, Console.WindowWidth - 2, Console.WindowHeight - 2);
        }
        protected void karakter(int x)
        {
            if (x == 1)
            {
                if ((this.Irány == 1 && this.Last == 1) || (this.Irány == 3 && this.Last == 3)) this.l[l.Count - 1].Ch = this.függ;
                if ((this.Irány == 2 && this.Last == 2) || (this.Irány == 4 && this.Last == 4)) this.l[l.Count - 1].Ch = this.vizszint;
                if ((this.Irány == 2 && this.Last == 1) || (this.Irány == 3 && this.Last == 4)) this.l[l.Count - 1].Ch = this.lj;
                if ((this.Irány == 4 && this.Last == 1) || (this.Irány == 3 && this.Last == 2)) this.l[l.Count - 1].Ch = this.lb;
                if ((this.Irány == 1 && this.Last == 4) || (this.Irány == 2 && this.Last == 3)) this.l[l.Count - 1].Ch = this.fj;
                if ((this.Irány == 1 && this.Last == 2) || (this.Irány == 4 && this.Last == 3)) this.l[l.Count - 1].Ch = this.fb;
            }
            else
            {
                if ((this.Irány == 1 && this.Last == 1) || (this.Irány == 3 && this.Last == 3)) this.l[0].Ch = this.függ;
                if ((this.Irány == 2 && this.Last == 2) || (this.Irány == 4 && this.Last == 4)) this.l[0].Ch = this.vizszint;
                if ((this.Irány == 2 && this.Last == 1) || (this.Irány == 3 && this.Last == 4)) this.l[0].Ch = this.lj;
                if ((this.Irány == 4 && this.Last == 1) || (this.Irány == 3 && this.Last == 2)) this.l[0].Ch = this.lb;
                if ((this.Irány == 1 && this.Last == 4) || (this.Irány == 2 && this.Last == 3)) this.l[0].Ch = this.fj;
                if ((this.Irány == 1 && this.Last == 2) || (this.Irány == 4 && this.Last == 3)) this.l[0].Ch = this.fb;
            }
        }
        protected bool csk(int x, int y)
        {
            foreach (Adatok i in this.l)
            {
                if (i.X == x && i.Y == y) return true;
            }
            foreach (Csemege i in this.csl)
            {
                if (i.X == x && i.Y == y) return true;
            }
            return false;
        }
        protected void cst()
        {
            Console.SetCursorPosition(this.csl[0].X,this.csl[0].Y);
            Console.WriteLine(" ");
            this.csl.RemoveAt(0);
        }
    }
}
