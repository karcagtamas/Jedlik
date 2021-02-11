using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    
    class Kígyó
    {
        struct Pont
        {
            int x;
            int y;
            public int X
            {
                get { return this.x; }
                set { if (value > 0 && value < Console.WindowWidth) this.x = value; }
            }
            public int Y 
            { 
                get { return this.y; }
                set { if (value > 0 && value < Console.WindowHeight) this.y = value; }
            }
            public Pont(int ax, int ay)
            {
                x = ax;
                y = ay;
            }
        }
        int hossz;
        int csx;
        int csy;
        public int Hossz
        {
            get { return this.hossz; }
            set { this.hossz = value; }
        }
        List<Pont> pontok = new List<Pont>();

        public Kígyó()
        {
            this.hossz = 5;
            Csemege cs = new Csemege();
            cs.Letesz();
            this.csx = cs.X;
            this.csy = cs.Y;

        }
        public Kígyó(Kígyó rhossz)
        {
            rhossz.hossz = this.hossz;
        }

        public virtual void Mozgat()
        {            
            ConsoleKeyInfo ch = new ConsoleKeyInfo();
            pontok.Add(new Pont(20, 12));

            do
            {
                int db = 0;
                foreach (Pont p in pontok)
                {
                    if (p.X == pontok.Last().X && p.Y == pontok.Last().Y && pontok.Last().X != csx && pontok.Last().Y != csy) db++;
                    if (db > 1)
                    {
                        Console.SetCursorPosition(15, 5);
                        Console.Write("GAME OVER!");
                        Console.ReadKey();
                        //Environment.Exit(0);
                    }
                }
                
                foreach (Pont p in pontok)
                {                    
                    Console.SetCursorPosition(p.X, p.Y);
                    if (pontok.IndexOf(pontok.Last()) == pontok.IndexOf(p)) Console.Write('☺');
                    else Console.Write('¤');
                }                
                if (Console.KeyAvailable) ch = Console.ReadKey(true);
                if (ch.Key == ConsoleKey.LeftArrow) pontok.Add(new Pont(pontok.Last().X - 1, pontok.Last().Y));
                if (ch.Key == ConsoleKey.RightArrow) pontok.Add(new Pont(pontok.Last().X + 1, pontok.Last().Y));
                if (ch.Key == ConsoleKey.DownArrow) pontok.Add(new Pont(pontok.Last().X, pontok.Last().Y + 1));
                if (ch.Key == ConsoleKey.UpArrow) pontok.Add(new Pont(pontok.Last().X, pontok.Last().Y - 1));
                if (ch.Key == ConsoleKey.Escape) Environment.Exit(0);
                System.Threading.Thread.Sleep(150);

                if (pontok.Last().Y == csy && pontok.Last().X == csx)
                {
                    Hossz++;
                    pontok.Add(new Pont(pontok.Last().X, pontok.Last().Y));
                    Csemege cs = new Csemege();
                    cs.Letesz();
                    this.csx = cs.X;
                    this.csy = cs.Y;
                }
                if (pontok.Count() > Hossz)
                {
                    Console.SetCursorPosition(pontok.First().X, pontok.First().Y);
                    Console.Write(" ");
                    pontok.RemoveAt(0);
                }
                if (pontok.Last().X == Console.WindowWidth || pontok.Last().Y == Console.WindowHeight || pontok.Last().X == 0 || pontok.Last().Y == 0)
                {
                    Console.SetCursorPosition(15, 5);
                    Console.Write("GAME OVER!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            } 
            while (pontok.Last().X != Console.WindowWidth || pontok.Last().Y != Console.WindowHeight || pontok.Last().X != 0 || pontok.Last().Y != 0);
        }
    }

    class Szuperkígyó : Kígyó
    {
        public Szuperkígyó(Kígyó rhossz):base(rhossz)
        {
        }
        public override void Mozgat()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            base.Mozgat();
        }
    }
}
