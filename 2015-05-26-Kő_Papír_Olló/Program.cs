using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kö_papir_ollo
{
    class Program
    {
        static void Main(string[] args)
        {  
             byte[,] eredmény = {
                                   {0,2,1},
                                   {1,0,2},
                                   {2,1,0},
                               };
            string[] kpo = { "kő", "papír", "olló" };
            string[] eredmény_szöveg = { "Döntetlen", "1. játékos nyert", "2. játékos nyert" };
            Console.WriteLine("Kő-Papír-Olló szimulátor");
            Console.Write("Adja meg a győzelmek számát:");
            int gysz = int.Parse(Console.ReadLine());
            Console.Clear();
            int n1 = 0;
            int n2 = 0;
            do
            {
                Console.WriteLine("Kérem a 2. játékos forduljon el!");
                Console.WriteLine("Majd az 1. játékos üssön le egy billentyűt!");
                Console.ReadKey();
                Console.Clear();
                bool jóinput = true;
                byte v1 = 0;
                do
                {
                    Console.WriteLine("1. játékos választása: 0=kő 1=papír 2=olló");
                    Console.Write("A választás: ");
                    jóinput = byte.TryParse(Console.ReadLine(), out v1);
                    if (jóinput && v1 > 2) jóinput = false;
                } while (!jóinput);
                Console.Clear();
                Console.WriteLine("Kérem a 1. játékos forduljon el!");
                Console.WriteLine("Majd az 2. játékos üssön le egy billentyűt!");
                Console.ReadKey();
                Console.Clear();
                jóinput = true;
                byte v2 = 0;
                do
                {
                    Console.WriteLine("1. játékos választása: 0=kő 1=papír 2=olló");
                    Console.Write("A választás: ");
                    jóinput = byte.TryParse(Console.ReadLine(), out v2);
                    if (jóinput && v2 > 2) jóinput = false;
                } while (!jóinput);
                Console.Clear();
                Console.WriteLine("eredmény: {0} vs. {1} ---> {2}", kpo[v1], kpo[v2], eredmény_szöveg[eredmény[v1, v2]]);
                Console.ReadKey();
                Console.Clear();
                switch(eredmény[v1, v2])
                {
                    case 1: n1++; break;
                    case 2: n2++; break;
                }
            } while (n1 < gysz && n2 < gysz);
        }
    }
}
//lehetne-e számítással mencsinálni?
//2. feladat ---> n darab játszmáig menjen számolni egyik és másik játékos nyert játszmáig
