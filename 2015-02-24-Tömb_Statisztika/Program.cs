using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tömb_stat
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] t = new byte[20];
            Random számok = new Random();
            for (int i = 0; i < t.Length; i++)
			{
			    t[i] = (byte)számok.Next(10, 100);
			}
            int pszám = 0;
            int azonos = 0;
            for (int i = 0; i < t.Length; i++)
			{
                Console.ForegroundColor = ConsoleColor.White;
                if (t[i] % 2 == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    pszám++;
                }
                if (t[i] % 11 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    azonos++; //azonos++; azonos += 1; azonos = azonos + 1;
                }
                Console.WriteLine("t[{0}]={1}", i, t[i]);
			}
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("páratlan számok= {0}",pszám);
            Console.WriteLine("azonos jegyüek= {0}",azonos);
            Console.ReadKey();
        }
    }
}
