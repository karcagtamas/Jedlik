using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kö_papir_olló_számitás
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kpo = { "kő", "papir", "olló" };
            string[] eredmény_szöveg = { "Döntetlen!", "1. játékos nyert!", "2. játékos nyert!" };
            Console.WriteLine("kö-papir-olló szimulátor");
            Console.WriteLine("Kérem a 2. játékos forduljon el!");
            Console.WriteLine("Az 1. játékos  üsse le az ENTERT!");
            Console.ReadKey();
            Console.Clear();

            Console.Write("1. játékos választása (0=kő, 1=papír, 2=olló): ");
            byte v1 = byte.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Kérem a 1. játékos forduljon el!");
            Console.WriteLine("Az 2. játékos  üsse le az ENTERT!");
            Console.ReadKey();
            Console.Clear();

            Console.Write("2. játékos választása (0=kő, 1=papír, 2=olló): ");
            byte v2 = byte.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Eredmény: {0} vs. {1} ---> {2}", kpo[v1], kpo[v2],eredmény_szöveg[(3+v1-v2) % 3]);
            Console.ReadKey();
        }
    }
}
