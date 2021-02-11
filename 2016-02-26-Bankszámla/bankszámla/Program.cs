using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankszámla
{
    class Program
    {
        static bool ellbank(string b)
        {
            if (b.Length != 16) return false;
            int összeg = 0;
            int x;
            for (int i = 0; i < b.Length; i ++)
            {
                if (i % 2 == 0)
                {
                    x = int.Parse(b[i].ToString()) * 2;
                    if (x > 9) x = x - 9;
                    összeg += x;
                }
                else
                {
                    x = int.Parse(b[i].ToString());
                    összeg += x;
                }
            }
            if (összeg % 10 == 0) return true;
            return false;
        }
        static void Main(string[] args)
        {
            Random r = new Random();
            while(true)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(ellbank("5425903142657353"));
            Console.WriteLine(ellbank("4000001234567899"));
            Console.WriteLine(ellbank("7214667658178472"));
            }
            //Console.WriteLine(ellbank(Console.ReadLine()));
            //Console.ReadKey();
        }
    }
}
