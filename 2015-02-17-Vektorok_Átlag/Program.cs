using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vektorok_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jegyek átlaga!!!");
            Console.Write("Kérem a tantárgy nevét: ");
            string tantárgy = Console.ReadLine();
            Console.Write("Kérem a jegyek darabszámát: ");
            int jegyekszáma = int.Parse(Console.ReadLine());
            //dekalaráció + inicializáció
            byte[] jegyek = new byte[jegyekszáma];
            //tömb feltöltése feltöltése
            Console.WriteLine("Kérem a számokat: ");
            for (int i = 0; i < jegyek.Length; i++)
            {
                Console.Write("{0}. ",i + 1);
                jegyek[i] = byte.Parse(Console.ReadLine());
            }
            //összegzés
            int összeg = 0;
            for (int i = 0; i < jegyek.Length; i++)
            {
                összeg = összeg + jegyek[i];
            }
            double átlag = (double)összeg / jegyekszáma;
            Console.WriteLine("{0} Tantárgyból az Átlag:{1:F2} ",tantárgy,átlag);
            Console.ReadKey();
        }
    }
}
//egész osztás: 5:2=2 //akkor lesz egész osztás ha mindkát operandus (osztó és osztandó) egész szám
//valós osztás: 5:2=2.5
//Házi feladat: egész típusok megtnaulása -> nevük, hány bitesek -> lehet e negativ vagy sem
//int és uint 10 jegyü
//long és ulong 20 jegyü
//byte és sbyte
//short és ushort