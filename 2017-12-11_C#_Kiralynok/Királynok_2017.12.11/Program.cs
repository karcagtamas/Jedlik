using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Királynok_2017._12._11
{
    class Tábla
    {
        char[,] T;
        char ÜresCella;

        public int ÜresOszlopokSzáma { get; set; }
        public int ÜresSorokszáma { get; set; }
        public char ÜresCella1 { get => ÜresCella; set => ÜresCella = value; }

        public Tábla(char a)
        {
            T = new char[8, 8];
            ÜresCella1 = a;
            for (int i = 0; i < T.GetLength(0); i++)
            {
                for (int j = 0; j < T.GetLength(1); j++)
                {
                    T[i, j] = ÜresCella1;
                }
            }
        }
        public void Megjelenít()
        {
            for (int i = 0; i < T.GetLength(0); i++)
            {
                for (int j = 0; j < T.GetLength(1); j++)
                {
                    Console.Write(T[i,j]);
                }
                Console.WriteLine();
            }
        }
        public void Elhelyez(int N)
        {
            Random r = new Random();
            for (int i = 0; i < N; i++)
            {
                int x;
                int y;
                do
                {
                    x = r.Next(0, 8);
                    y = r.Next(0, 8);
                } while (T[x, y] != ÜresCella);
                T[x, y] = 'K';
            }
        }
        public bool ÜresOszlop(int oszlop)
        {
            bool f = true;
            for (int i = 0; i < T.GetLength(0); i++)
            {
                if (T[i, oszlop] == 'K') f = false;
            }
            return f;
        }
        public bool ÜresSor(int sor)
        {
            bool f = true;
            for (int i = 0; i < T.GetLength(1); i++)
            {
                if (T[sor, i] == 'K') f = false;
            }
            return f;
        }
        public void FájlbaÍr()
        {
            StreamWriter sw = new StreamWriter("tablak64.txt", true);
            string[] s = new string[T.GetLength(0)];
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < T.GetLength(1); j++)
                {
                    s[i] += T[i,j];
                }
                sw.WriteLine(s[i]);
            }
            
            
            sw.Close();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("tablak64.txt")) File.Delete("tablak.txt");
            Tábla t = new Tábla('#');
            Console.WriteLine("4. feladat: Az üres tábla:");
            t.Megjelenít();
            Console.WriteLine();
            t.Elhelyez(8);
            Console.WriteLine("6. feladat: A feltöltött tábla:");
            t.Megjelenít();
            Console.WriteLine();

            int x = 0;
            int y = 0;
            for (int i = 0; i < 8; i++)
            {
                
                if (!t.ÜresOszlop(i)) x++;
                if (!t.ÜresSor(i)) y++;
               
            }
            t.ÜresOszlopokSzáma = x;
            t.ÜresSorokszáma = y;

            Console.WriteLine("9. feladat: Üres oszlopok és sorok száma:");
            Console.WriteLine($"Oszlopok: {t.ÜresOszlopokSzáma}");
            Console.WriteLine($"Sorok: {t.ÜresSorokszáma}");
            for (int i = 1; i <= 64; i++)
            {
                Tábla tábla = new Tábla('*');
                tábla.Elhelyez(i);
                tábla.FájlbaÍr();
            }
            Console.ReadKey();
        }
    }
}
