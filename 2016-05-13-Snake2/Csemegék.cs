using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Csemegék
    {
        //public List<Kordináta> f = new List<Kordináta>();
        char csemege = '*';
        private int x;
        public int X
        {
            get { return x; }
            set { if (value > 0 && value < Console.WindowWidth) x = value; }
        }

        private int y;
        public int Y
        {
            get { return y; }
            set { if (value > 0 && value < Console.WindowHeight) y = value; }
        }

        ConsoleColor[] cm = { ConsoleColor.Yellow,ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Green };

        private ConsoleColor c;
        public ConsoleColor C
        {
            get { return c; }
            set { c = value; }
        }
        public Csemegék()
        {
                Kordináta k = new Kordináta();
                Random r = new Random();
                k.X = r.Next(3, Console.WindowWidth - 3);
                this.x = k.X;
                k.Y = r.Next(3, Console.WindowHeight - 3);
                this.y = k.Y;
                this.c = cm[r.Next(cm.Length)];
                Thread.Sleep(10);
            //cskirajzol();
                this.csemegekirajzol();
        }
        //public void cskirajzol()
        //{
        //    foreach (Kordináta i in this.f)
        //    {
        //        Console.ForegroundColor = c;
        //        Console.SetCursorPosition(i.x, i.y);
        //        Console.Write(this.csemege);
        //    }
        //}
        public void csemegekirajzol()
        {
            Console.ForegroundColor = this.c;
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(this.csemege);
        }
    }
}
