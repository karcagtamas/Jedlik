using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNKO_Euklidész
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("LNKO eulkidészi algoritmus");//CW+TAB+TAB
            Console.WriteLine("m= {0}",ulong.MaxValue);//ulong.MaxValue = a legnagyobb érték.
            Console.Write("a= ");
            ulong a = ulong.Parse(Console.ReadLine());//ulong legnagyobb.
            Console.Write("b= ");
            ulong b = ulong.Parse(Console.ReadLine());
            do
            {
                ulong m = a % b; //maradékos osztás.
                a = b;//elezö maradék.
                b = m;//uj maradék.
            } while (b!=0);
            Console.WriteLine("LNKO= {0}", a);
            Console.ReadKey();

        }
    }
}
