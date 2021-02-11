using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Kordináta
    {
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
    }
}
