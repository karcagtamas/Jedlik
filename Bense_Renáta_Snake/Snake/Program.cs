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

    class Kígyó
    {
        int hossz;
        //char fej = '¤';
        char test = 'o';

        public Kígyó()
        {
            this.hossz = 5;
        }
        public Kígyó(Kígyó rhossz)
        {
            this.hossz = rhossz.hossz;
        }
        public virtual void Mozgat()
        {
            ConsoleKeyInfo ch = new ConsoleKeyInfo();
            List<Pont> pontok = new List<Pont>();
            pontok.Add(new Pont(20,12));
            
            do
            {
                foreach (Pont p in pontok)
                {
                    Console.SetCursorPosition(p.x, p.y);
                    Console.Write(test);
                }
                
                if (Console.KeyAvailable) ch = Console.ReadKey(true);
                if (ch.Key == ConsoleKey.LeftArrow) pontok.Add(new Pont(pontok.Last().x-1, pontok.Last().y));
                if (ch.Key == ConsoleKey.RightArrow) pontok.Add(new Pont(pontok.Last().x+1, pontok.Last().y));
                if (ch.Key == ConsoleKey.DownArrow) pontok.Add(new Pont(pontok.Last().x, pontok.Last().y+1));
                if (ch.Key == ConsoleKey.UpArrow) pontok.Add(new Pont(pontok.Last().x, pontok.Last().y-1));
                System.Threading.Thread.Sleep(150);
                if (pontok.Count() > 5)
                {
                    Console.SetCursorPosition(pontok.First().x, pontok.First().y);
                    Console.Write(" ");
                    pontok.RemoveAt(0);
                }
            } 
            while (ch.Key != ConsoleKey.Escape);
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

    
    //    '✿';

    class Program
    {
        static void Main(string[] args)
        {
            Kígyó k = new Kígyó();
            k.Mozgat();
        }
    }
}
