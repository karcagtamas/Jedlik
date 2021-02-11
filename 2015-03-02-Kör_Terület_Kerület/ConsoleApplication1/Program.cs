using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            double r, t, k;
            Console.Write("Add meg a kör sugarát!  ");
            r = double.Parse(Console.ReadLine());
            k = 2 * r * Math.PI;
            t = r * r * Math.PI;
            Console.WriteLine("A kör kerülete: " + k);
            Console.WriteLine("A kör területe: " + t);
            Console.ReadKey();
        }
    }
}
