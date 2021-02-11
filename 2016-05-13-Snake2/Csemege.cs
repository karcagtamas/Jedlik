using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Csemege
    {
        //public List<Kordináta> f = new List<Kordináta>();
        private char csemege = '*';
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
        public Csemege()
        {
                Random r = new Random();
                //k.X = r.Next(3, Console.WindowWidth - 3);
                //this.x = k.X;
                //k.Y = r.Next(3, Console.WindowHeight - 3);
                //this.y = k.Y;
                this.c = cm[r.Next(cm.Length)];
                Thread.Sleep(10);
                //cskirajzol();
                //this.Csemege_Kirajzol();
        }
        public void Csemege_Kirajzol()
        {
            Console.ForegroundColor = this.c;
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(this.csemege);
        }
    }
}
