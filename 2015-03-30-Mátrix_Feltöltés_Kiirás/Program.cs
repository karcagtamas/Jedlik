using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mátrixok_fel_1
{
    class Program
    {
        static bool prime (int x)
        {
            int db = 0;
            for (int i = 1; i <= x/2; i++)
			{
                if (x % i == 0)
                {
                    db++;
                }
			}
            if (db > 1) return false;
            else return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Add meg a mátrix méretét szóközzel elválasztva!!!");
            Console.WriteLine("Ki irja egy sor végére hogy hány darab prímszám van benn!!!");
            string input = Console.ReadLine();
            string[] m = input.Split(); // "12 15".Split() -> m[0]="12" m[1]="15"
            int sorok = int.Parse(m[0]);
            int oszlopok = int.Parse(m[1]);
            byte[,] mátrix = new byte[sorok, oszlopok];
            Random r = new Random();
            //feltöltés
            for (int i = 0; i < mátrix.GetLength(0); i++)
            {
                for (int j = 0; j < mátrix.GetLength(1); j++)
                {
                    mátrix[i, j] = (byte)r.Next(10, 100);
                }
            }
            //számoljuk meg a páros számok darabszámát az oszlopokban
            //egy oszlopban hány db páros szám van pszdb=páros szám darab
            byte[] pszdb = new byte[oszlopok];
            for (int i = 0; i < mátrix.GetLength(0); i++)
            {
                for (int j = 0; j < mátrix.GetLength(1); j++)
                {
                    if (mátrix[i, j] % 2 == 0) pszdb[j]++;
                }
            }
            //maximum keresés
            byte max = pszdb[0];
            for (int i = 0; i < pszdb.Length; i++)
            {
                if (max < pszdb[i]) max = pszdb[i];
            }
            //mátrix megjelenítése
            bool[] prim = new bool[sorok];
            for (int i = 0; i < mátrix.GetLength(0); i++)
            {
                for (int j= 0; j < mátrix.GetLength(1); j++)
                {
                    Console.Write("{0, -3}",mátrix[i,j]);
                    if (prime(mátrix[i, j]) && !prim[i]) prim[i] = true;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (prim[i]) Console.WriteLine("Van");
                else Console.WriteLine("Nincs");
                Console.ForegroundColor = ConsoleColor.White;
            }
            //párosszámok kiiratása a mátrix oszlopai alá  
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < pszdb.Length; i++)
            {
                Console.Write("{0, -3}",pszdb[i]);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("A legtöbb párost számot tartalmazó oszlopok indexei:");
            for (int i = 0; i < pszdb.Length; i++)
            {
                if (pszdb[i] == max) Console.Write("{0,-3}",i);
            }
            Console.ReadKey();
        }
    }
}
