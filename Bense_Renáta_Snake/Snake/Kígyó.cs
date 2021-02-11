using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    struct Pont
    {
        public int x;
        public int y;
        public Pont(int ax, int ay)
        {
            x = ax;
            y = ay;
        }
    }

    class Kígyó : Játék
    {
        public bool szupere = false;
        Pont kezdop = new Pont(20, 12);
        private int hossz;
        char fej = 'O';
        char test = '¤';
        public int Fejx
        {
            get { return base.fejx; }
            set { base.fejx = value; }
        }
        public int Fejy
        {
            get { return base.fejy; }
            set { base.fejy = value; }
        }
        public bool vege;
        public Kígyó()
        {
            this.hossz = 5;
        }
        public Kígyó(Kígyó rhossz)
        {
            this.hossz = rhossz.hossz;
            this.pontok = rhossz.pontok;
            kezdop = rhossz.pontok.Last();
        }
        public virtual void Mozgat()
        {
            vege = false;
            ConsoleKeyInfo ch = new ConsoleKeyInfo();
            
            if(!szupere)pontok.Add(kezdop);
            Csemege cs = new Csemege();
            do
            {
                foreach (Pont p in pontok)
                {
                    if ((p.x >= 0 && p.y >= 0) && (p.x < Console.WindowWidth && p.y < Console.WindowHeight)) Console.SetCursorPosition(p.x, p.y);
                    else 
                    {
                        Console.Clear();
                        Console.WriteLine("Vége a játéknak");
                        Console.WriteLine("Pontszám: {0}", pontok.Count);
                        vege = true;
                        break;
                    }
                    if (pontok.IndexOf(p) != pontok.Count - 1) Console.Write(test);
                    else Console.Write(fej);
                    
                }
                    
                    
                    if (Console.KeyAvailable) ch = Console.ReadKey(true);
                    if (ch.Key == ConsoleKey.LeftArrow) pontok.Add(new Pont(pontok.Last().x - 1, pontok.Last().y));
                    if (ch.Key == ConsoleKey.RightArrow) pontok.Add(new Pont(pontok.Last().x + 1, pontok.Last().y));
                    if (ch.Key == ConsoleKey.DownArrow) pontok.Add(new Pont(pontok.Last().x, pontok.Last().y + 1));
                    if (ch.Key == ConsoleKey.UpArrow) pontok.Add(new Pont(pontok.Last().x, pontok.Last().y - 1));
                    System.Threading.Thread.Sleep(150);
                    Fejx = pontok[pontok.IndexOf(pontok.Last())].x;
                    Fejy = pontok[pontok.IndexOf(pontok.Last())].y;
                    if (pontok.Contains(new Pont(fejx, fejy)) && pontok.IndexOf(new Pont(fejx, fejy)) != pontok.Count - 1 && !szupere)
                    {
                        Console.Clear();
                        Console.WriteLine("Vége a játéknak");
                        Console.WriteLine("Pontszám: {0}", pontok.Count);
                        vege = true;
                        break;
                    }

                    if (Fejx == cs.X1 && Fejy == cs.Y1)
                    {
                        hossz++;
                        cs = new Csemege();
                    }
                    if (pontok.Count() > hossz && (pontok.First().x >= 0 && pontok.First().y >= 0) && (pontok.First().x < Console.WindowWidth && pontok.First().y < Console.WindowHeight))
                    {
                        Console.SetCursorPosition(pontok.First().x, pontok.First().y);
                        Console.Write(" ");
                        pontok.RemoveAt(0);
                }
                base.P = hossz;
            }
            while (ch.Key != ConsoleKey.Escape && ((hossz<10 && !szupere) || (hossz>=10 && szupere)));
        }
    }

    class Szuperkígyó : Kígyó
    {
        public Szuperkígyó(Kígyó rhossz)
            : base(rhossz)
        {
        }
        public override void Mozgat()
        {
            base.szupere = true;
            Console.ForegroundColor = ConsoleColor.Magenta;
            base.Mozgat();
        }
    }


    //    '✿';


}
