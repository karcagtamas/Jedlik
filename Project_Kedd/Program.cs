using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_Kedd
{
    class Program
    {
        static void bekérés1(ref byte v1)
        {
            do
            {
                try
                {
                    Console.Write("1. játékos választása (0=kő, 1=papír, 2=olló): ");
                    v1 = byte.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    v1 = 3;
                }
            } while (v1 < 0 || v1 > 2);
            Console.Clear();

            
        }
        static void bekérés2(ref byte v2)
        {
            do
            {
                try
                {
                    Console.Write("2. játékos választása (0=kő, 1=papír, 2=olló): ");
                    v2 = byte.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    v2 = 3;
                }
            } while (v2 < 0 || v2 > 2);
            Console.Clear();
        }
        static void beolvasás(ref int[] győzelmek, ref int db)
        {
            byte v1;
            byte v2;
            StreamReader sr = new StreamReader("jatek.txt");
            db = 1;
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] t = s.Split('-');
                v1 = (byte)int.Parse(t[0]);
                v2 = (byte)int.Parse(t[1]);
                if ((3 + v1 - v2) % 3 == 0) győzelmek[0]++;
                if ((3 + v1 - v2) % 3 == 1) győzelmek[1]++;
                if ((3 + v1 - v2) % 3 == 2) győzelmek[2]++;
                db++;
            }
        }
        static void Main(string[] args)
        {
            string[] kpo = { "kő", "papir", "olló" };
            string[] eredmény_szöveg = { "Döntetlen!", "1. játékos nyert!", "2. játékos nyert!" };
            int[] győzelmek = { 0, 0, 0 };
            Console.WriteLine("kö-papir-olló szimulátor");
            Console.WriteLine("Kérem a 2. játékos forduljon el!");
            Console.WriteLine("Az 1. játékos  üsse le az ENTERT!");
            Console.ReadKey();
            Console.Clear();
            byte v1 = 0;
            bekérés1(ref v1);
            Console.WriteLine("Kérem a 1. játékos forduljon el!");
            Console.WriteLine("Az 2. játékos  üsse le az ENTERT!");
            Console.ReadKey();
            Console.Clear();
            byte v2 = 0;
            bekérés2(ref v2);
            Console.WriteLine("Eredmény: {0} vs. {1} ---> {2}", kpo[v1], kpo[v2], eredmény_szöveg[(3 + v1 - v2) % 3]);
            if ((3 + v1 - v2) % 3 == 0) győzelmek[0]++;
            if ((3 + v1 - v2) % 3 == 1) győzelmek[1]++;
            if ((3 + v1 - v2) % 3 == 2) győzelmek[2]++;
            int db = 1;
            beolvasás(ref győzelmek, ref db);
           
            Console.WriteLine("További játékok: {0}db",db - 1);
            Console.WriteLine("Döntetlenek: {0}db",győzelmek[0]);
            Console.WriteLine("Első játékos nyert: {0}db", győzelmek[1]);
            Console.WriteLine("Második játékos nyert: {0}db", győzelmek[2]);

            Console.ReadKey();
        }
    }
}
