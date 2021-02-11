using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random
{
    class Program
    {
        static void Main(string[] args)
        {
            int b, c;           
            Random a = new Random();
            
            
                do
                {
                    c = a.Next(6);
                    if (c == 0) { Console.ForegroundColor = ConsoleColor.Red; };
                    if (c == 1) { Console.ForegroundColor = ConsoleColor.Green; };
                    if (c == 2) { Console.ForegroundColor = ConsoleColor.Blue; };
                    if (c == 3) { Console.ForegroundColor = ConsoleColor.Yellow; };
                    if (c == 4) { Console.ForegroundColor = ConsoleColor.Gray; };
                    if (c == 5) { Console.ForegroundColor = ConsoleColor.Black; };
                    if (c == 0) { Console.BackgroundColor = ConsoleColor.Red; };
                    if (c == 1) { Console.BackgroundColor = ConsoleColor.Green; };
                    if (c == 2) { Console.BackgroundColor = ConsoleColor.Blue; };
                    if (c == 3) { Console.BackgroundColor = ConsoleColor.Yellow; };
                    if (c == 4) { Console.BackgroundColor = ConsoleColor.Gray; };
                    if (c == 5) { Console.BackgroundColor = ConsoleColor.Black; };
                    b = a.Next(1,10);
                    Console.Write("{0}  ", b);
                } while (1 == 1);           
        }
    }
}
