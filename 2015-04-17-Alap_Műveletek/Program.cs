using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x; 
            int y; 
            int osszeg;
            int kulonbseg;
            int szorzat;
            int hanyados;
            Console.WriteLine("Alapműveletek program");
            Console.Write("Kérem az első számot: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Kérem a második számot: ");
            y = int.Parse(Console.ReadLine());
            osszeg = x + y;
            kulonbseg = x - y;
            szorzat = x * y;
            hanyados = x / y;
            Console.WriteLine("A két szám összege: {0}", osszeg);
            Console.WriteLine("A két szám különbsége: {0}", kulonbseg);
            Console.WriteLine("A két szám szorzata: {0}", szorzat);
            Console.WriteLine("A két szám hányadosa: {0}", hanyados);
            Console.ReadKey();
            xy(x);
        }
        static void xy(int x)
        {
            int szam1;
            int szam2;
            int osszeg;
            int kulonbseg;
            int szorzat;
            int hanyados;
            Console.WriteLine("Alapműveletek program");
            Console.Write("Kérem az első számot: ");
            szam1 = int.Parse(Console.ReadLine());
            Console.Write("Kérem a második számot: ");
            szam2 = int.Parse(Console.ReadLine());
            osszeg = szam1 + szam2;
            szorzat = szam1 * szam2;
            if (szam1 > szam2)
            {
                kulonbseg = szam1 - szam2;
                hanyados = szam1 / szam2;
            }
            else
            {
                kulonbseg = szam2 - szam1;
                hanyados = szam2 / szam1;
            };
            Console.WriteLine("A két szám összege: {0}", osszeg);
            Console.WriteLine("A két szám különbsége: {0}", kulonbseg);
            Console.WriteLine("A két szám szorzata: {0}", szorzat);
            Console.WriteLine("A két szám hányadosa: {0}", hanyados);
            Console.ReadKey();
        }
    }
}
