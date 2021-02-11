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
                Console.WriteLine("Faktoriális meghatározása!");
                bool siker;//sikeres volt az adatbevitel?
                int n;
                do
                {
                    Console.Write("n=");
                    siker = int.TryParse(Console.ReadLine(), out n);//tryparse kétparaméteres //out visszahat az n-re(hozzá tud nyúlni)
                } while (!siker || n<1 || n>20);//ez egy összetett logikai kifejezés
                Console.Write("{0}!=1", n); //helyörző (5!=1)
                ulong faktor = 1;
                for (int i = 2; i <= n; i++)
                {
                    Console.Write("*{0}", i);//*2 *3 *4 *5 ... *n
                    checked //túl és alul csordulás elleni(bekapcsolása)
                    {
                        faktor = faktor * (ulong)i;
                    }
                }
                Console.Write("={0}", faktor);
                Console.ReadKey();
            }
        }
    }
}
