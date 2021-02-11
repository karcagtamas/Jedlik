using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INPUTellenőrzés
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input ellenőrzés! Írj be egy kétjegyű számot!");
            int a = 0;
            do
            {
                Console.Write("a= ");
                try
                {
                    a = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hibás adatbevitel! Kérem adja meg újra!");
                }
            } while (!(a >= 10 && a <= 99));

            int b;
            bool siker = false;
            //do
            //{
            //    Console.Write("b= ");
            //    siker = int.TryParse(Console.ReadLine(), out b);
            //} while (!(siker && b >= 10 && b <= 99));
            do
            {
                Console.Write("b= ");
                siker = int.TryParse(Console.ReadLine(), out b);
            } while (!siker || b < 10 || b > 99);// || --> VAGY logikai müvelet   &&--> ÉS logikai müvelet  !-->TAGADÁS operátor


            Console.WriteLine("a * b = {0}", a * b);
            Console.ReadKey();
        }
    }
}