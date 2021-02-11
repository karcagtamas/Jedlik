using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faktoriális
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Faktoriális kiszámolása 1-től 20-ig");
                for (int n = 1; n <= 20; n++)
                {
                    ulong faktor = 1;
                    for (int i = 2; i <= n; i++)
                    {
                        {
                            faktor = faktor * (ulong)i;
                        }
                        // teljes programra a túl alulcsordulás bekapcs.
                        //project/properties/build kategoria/advanced/pipa a check 
                    }
                    Console.WriteLine("{0,-2}!={1}", n, faktor);
                }

                Console.ReadKey();
            }
        }
    }
}
