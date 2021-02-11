using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Adatok
    {
        public Adatok()
        {
            Random r = new Random();
            this.c = (ConsoleColor)r.Next(16);
        }
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

        private char ch;
        public char Ch
        {
            get { return ch; }
            set { ch = value; }
        }

        private ConsoleColor c;

        public ConsoleColor C
        {
            get { return c; }
            set
            {
                if (value != ConsoleColor.Black) c = value;
                else c = ConsoleColor.DarkCyan;
            }
        }
    }
}
