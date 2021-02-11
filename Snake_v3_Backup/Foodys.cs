using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_v3
{
    class Foodys
    {
        int x;
        int y;
        ConsoleColor cc;
        int point;

        public Foodys(int x, int y, ConsoleColor cc)
        {
            this.X = x;
            this.Y = y;
            this.Cc = cc;
            this.Point = PointMaker();
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public ConsoleColor Cc { get => cc; set => cc = value; }
        public int Point { get => point; set => point = value; }

        public int PointMaker()
        {
            int x = 1;
            if (this.Cc == ConsoleColor.Yellow) x = 5;
            if (this.Cc == ConsoleColor.Magenta) x = 3;
            return x;
        }
    
    }
}
