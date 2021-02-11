using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rulett
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            int szám = 0;
            int db = 0;
            int páratlan = 0, páros = 0, nulla = 0;
            Random r = new Random();
            for (int i = 1; i <= 200; i++)
            {
                szám = r.Next(36);
                db++;
                if (szám == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("{0}", szám.ToString().PadLeft(3));
                    nulla++;
                }
                if (szám % 2 == 0 && szám != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("{0}", szám.ToString().PadLeft(3));
                    páros++;
                }
                if (szám % 2 == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", szám.ToString().PadLeft(3));
                    páratlan++;
                }
                if (db % 20 == 0) Console.WriteLine();
            }
            Console.WriteLine("{0}db nulla van",nulla);
            Console.WriteLine("{0}db páros van",páros);
            Console.WriteLine("{0}db páratlan van",páratlan);
            Console.ReadKey();
        }
    }
}
