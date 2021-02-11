using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_v3
{
    class Element
    {
        int x;
        int y;
        char c;
        ConsoleColor cc;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public char C { get => c; set => c = value; }
        public ConsoleColor Cc { get => cc; set => cc = value; }
    }
}
