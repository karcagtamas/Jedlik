using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Számolás
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Összeadás és Kivonás!!!";
            while (true)
            {
                int százalék = 0;
                int sor = 1;
                int jó = 0;
                int db = 0;
                DateTime Start = DateTime.Now;
                do
                {
                    Random számok = new Random();
                    int a = számok.Next(1, 10);
                    int b = számok.Next(1, 10);
                    if (sor % 2 == 0)
                    {
                        if (a > b)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("{0}. {1}-{2}=",sor,a,b); 
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("{0}. {1}-{2}=", sor, b, a);
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.Write("{0}. {1}+{2}=", sor, a, b);
                    }
                    int c = int.Parse(Console.ReadLine());
                    if (sor % 2 == 0)
                    {
                        if (a > b)
                        { 
                            if (c == a - b)
                            {
                                jó = jó + 1;
                                százalék = százalék + 10;
                            }
                        }
                        else
                        { 
                            if (c== b - a)
                            {
                                jó = jó + 1;
                                százalék = százalék + 10;
                            }
                        }
                    }
                    else
                    {
                        if (c == a + b)
                        {
                            jó = jó + 1;
                        százalék = százalék + 10;
                        }
                    }
                    db++;
                    sor++;
                } while (db < 10);
                DateTime Stop = DateTime.Now;
                Console.WriteLine("");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("Eredmény:{0}/10", jó);
                Console.Write("         {0}%", százalék);
                if (jó == 0 || jó == 2 || jó == 3)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write("Nagyon rossz!!! :(");
                }
                if (jó == 10 || jó == 9 || jó == 8)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write("     Ügyes!!! :)");
                }
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("        {0}",Stop-Start);
                Console.WriteLine("");
                Console.ReadKey();
            }
        }
    }
}
