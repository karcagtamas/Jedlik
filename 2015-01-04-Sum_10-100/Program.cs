using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Házi_feladat
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ulong x;
                ulong összeg = 0;
                do
                {
                    do
                    {
                        Console.Write("Adja meg x-et:");
                        x = ulong.Parse(Console.ReadLine());
                    } while (x < 10 || x > 99);
                    összeg = összeg + x;
                } while (x != 99);
                összeg = összeg - 99;
                Console.WriteLine("Összeg:{0}", összeg);
                Console.ReadKey();
            }
        }
    }
}
