using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace henger_V_A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Henger palást, térfogat számitás!");
            Console.Write("r:");
            double r = double.Parse(Console.ReadLine());   //r: "12" ---- string   ---- konvertálás double.Parse("12") --- 12
            Console.Write("M:");
            double M = double.Parse(Console.ReadLine());
            Console.WriteLine("pi =" + Math.PI);
            double A = 2 * r * r * Math.PI + 2 * r * Math.PI * M;
            double V = 2 * r * r * Math.PI * M;
            Console.WriteLine("A =" + A);
            Console.WriteLine("V =" + V);
            Console.ReadKey();
        }
    }
}
