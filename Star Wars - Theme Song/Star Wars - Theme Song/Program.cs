using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star_Wars___Theme_Song
{
    class Program
    {
        static void kiir()
        {
            Console.Clear();
            Random r = new Random();
            switch (r.Next(0, 5))
            {
                case 0: Console.ForegroundColor = ConsoleColor.White; break;
                case 1: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case 2: Console.ForegroundColor = ConsoleColor.Cyan; break;
                case 3: Console.ForegroundColor = ConsoleColor.Magenta; break;
                case 4: Console.ForegroundColor = ConsoleColor.DarkGreen; break;
            }
            Console.WriteLine("    8888888888  888    88888");
            Console.WriteLine("   88     88   88 88   88  88");
            Console.WriteLine("    8888  88  88   88  88888");
            Console.WriteLine("       88 88 888888888 88   88");
            Console.WriteLine("88888888  88 88     88 88    888888");
            Console.WriteLine();
            Console.WriteLine("88  88  88   888    88888    888888");
            Console.WriteLine("88  88  88  88 88   88  88  88");
            Console.WriteLine("88 8888 88 88   88  88888    8888");
            Console.WriteLine("888  888 888888888 88   88     88");
            Console.WriteLine(" 88  88  88     88 88    8888888");
        }
        static void Main(string[] args)
        {
            while (true)
            {
                int x = 0;
                kiir();
                Console.Beep(440, 500);
                kiir();
                Console.Beep(440, 500);
                kiir();
                Console.Beep(440, 500);
                kiir();
                Console.Beep(349, 350);
                kiir();
                Console.Beep(523, 150);
                kiir();
                Console.Beep(440, 500);
                kiir();
                Console.Beep(349, 350);
                kiir();
                Console.Beep(523, 150);
                kiir();
                Console.Beep(440, 1000);
                kiir();
                Console.Beep(659, 500);
                kiir();
                Console.Beep(659, 500);
                kiir();
                Console.Beep(659, 500);
                kiir();
                Console.Beep(698, 350);
                kiir();
                Console.Beep(523, 150);
                kiir();
                Console.Beep(415, 500);
                kiir();
                Console.Beep(349, 350);
                kiir();
                Console.Beep(523, 150);
                kiir();
                Console.Beep(440, 1000);
                kiir();
            }
        }
    }
}
