using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szorzó_program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ez egy szorzó program amivel a szorzótáblát lehet gyakorolni!");
            Console.WriteLine("NYOMJ ENTERT");
            Console.ReadKey();
            int helyes = 0;
            int db = 0;
            int[] szorzó1 = new int[10];
            int[] szorzó2 = new int[10];
            int[] eredmény = new int[10];
            Random számok = new Random();
            DateTime Start = DateTime.Now;
            for (int i = 0; i < eredmény.Length; i++)
            {
                db = i + 1;
                szorzó1[i] = számok.Next(1, 10);
                szorzó2[i] = számok.Next(1, 10);
                if (db % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                    Console.Write("{2}.{0}*{1}=", szorzó1[i], szorzó2[i], db);
                    eredmény[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < eredmény.Length; i++)
            {
                if (eredmény[i] == szorzó1[i] * szorzó2[i])
                {
                    helyes++;
                }
            }
            DateTime Stop = DateTime.Now;
            switch (helyes)
            {
                case 0: Console.ForegroundColor = ConsoleColor.DarkRed; break;
                case 1: Console.ForegroundColor = ConsoleColor.DarkRed; break;
                case 2: Console.ForegroundColor = ConsoleColor.DarkRed; break;
                case 3: Console.ForegroundColor = ConsoleColor.Red; break;
                case 4: Console.ForegroundColor = ConsoleColor.Red; break;
                case 5: Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case 6: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case 7: Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                case 8: Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                case 9: Console.ForegroundColor = ConsoleColor.Green; break;
                case 10: Console.ForegroundColor = ConsoleColor.Green; break;
            }
            Console.Write("   {0}/10", helyes);
            Console.WriteLine("            {0}", Stop - Start);
            Console.ReadKey();
            int dbosztó = 0;
            int helyesosztó = 0;
            int[] osztó = new int[10];
            int[] osztandó = new int[10];
            int[] eredményosztó = new int[10];
            DateTime start = DateTime.Now;
            for (int i = 0; i < eredményosztó.Length; i++)
            {
                dbosztó = i + 1;
                do
                {
                    osztandó[i] = számok.Next(1, 100);
                    osztó[i] = számok.Next(2, 10);
                } while (osztandó[i] % osztó[i] != 0);
                if (dbosztó % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                Console.Write("{0}.{1}/{2}=",dbosztó,osztandó[i],osztó[i]);
                eredményosztó[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < eredményosztó.Length; i++)
            {
                if (osztandó[i] / osztó[i] == eredményosztó[i])
                {
                    helyesosztó++;
                }
            }
            DateTime stop = DateTime.Now;
            switch (helyesosztó)
            {
                case 0: Console.ForegroundColor = ConsoleColor.DarkRed; break;
                case 1: Console.ForegroundColor = ConsoleColor.DarkRed; break;
                case 2: Console.ForegroundColor = ConsoleColor.DarkRed; break;
                case 3: Console.ForegroundColor = ConsoleColor.Red; break;
                case 4: Console.ForegroundColor = ConsoleColor.Red; break;
                case 5: Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case 6: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case 7: Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                case 8: Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                case 9: Console.ForegroundColor = ConsoleColor.Green; break;
                case 10: Console.ForegroundColor = ConsoleColor.Green; break;
            }
            Console.Write("   {0}/10", helyesosztó);
            Console.WriteLine("            {0}", stop - start);
            Console.ReadKey();
        }
    }
}
