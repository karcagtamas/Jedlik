using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Fal
    {
        public Fal(int x, int y, int sz, int m)
        {
            ExtraKeret ek = new ExtraKeret();
            ek.X = x;
            ek.Y = y;
            ek.SZ = sz;
            ek.M = m;
            Console.ForegroundColor = ConsoleColor.Red;
            ek.Rajzol();
        }
        public void faltöröl(int x)
        {
            for (int i = x + 1; i < Console.WindowWidth - (2 * (x + 1)); i++)
            {
                Console.SetCursorPosition(i, x + 1);
                Console.Write(" ");
                Console.SetCursorPosition(i, Console.WindowHeight - (2 * (x + 1)));
                Console.Write(" ");
            }
            for (int i = x + 1; i < Console.WindowHeight - (2 * (x + 1)); i++)
            {
                Console.SetCursorPosition(x + 1, i);
                Console.Write(" ");
                Console.SetCursorPosition(Console.WindowWidth - (2 * (x + 1)), i);
                Console.Write(" ");
            }
        }
    }
}
