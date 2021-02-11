using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mersenne_prímek
{
    class Program
    {
        static void Main(string[] args)
        {
            int db = 0;
            int a = 1;
            int b = 1;
            do
            {
                for (a = 1; a < 100000000; a++)
                {
                    for (b = 1; b < a - 1; b++)
                    {
                        int szorzat = a * b;
                        int i = 0;
                        for (i = 2; i < a * b; i = i + 0)
                        {
                            i = i * i;
                        }
                        int mersenne = i - 1;
                        Console.WriteLine("Mersenne={0}",mersenne);
                        db++;
                    }
                }
            } while (db < 2);
            Console.ReadKey();
        }
    }
}
