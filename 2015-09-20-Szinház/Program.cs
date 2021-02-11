using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szinház
{
    class Program
    {
        static int ÁR (int index)
        {
            int ár = 7000;
            if (index <= 6) ár = 10000;
            if (index > 14) ár = 5000;
            return ár;
        }
        static void kiírsor(int a,char[,] m,int hossz)
        {
            for(int i = a; i <= m.GetLength(1); i += 2)
            {
                if (i == a) Console.Write("{0,-4}   ", i.ToString().PadLeft(hossz));
                else Console.Write("{0,-4}", i);
            }
        }
        static void Main(string[] args)
        {
            Random r = new Random();
            char[,] m = new char[20, 20];
            int x = 0;
            //for (int i = 0; i < m.GetLength(1); i++)
            //{
            //    x = (i % 10) + 1;
            //    if (x == 10) x = 0;
            //    if (i == 0) Console.Write("{0,-2} ",x.ToString().PadLeft(5));
            //    else Console.Write("{0,-2}",x);
            //}
            kiírsor(1, m, 5);
            Console.WriteLine();
            kiírsor(2, m, 7);
            Console.WriteLine();
            int összeg = 0;
            int összegfőátló = 0;
            int összegmellékátló = 0;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                if (i <= 6) Console.BackgroundColor = ConsoleColor.DarkRed;
                if (i <= 14 && i < 6) Console.BackgroundColor = ConsoleColor.DarkGreen;
                if (i >= 15) Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Write((i+1).ToString().PadRight(4));
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    m[i, j] = r.Next(0,2) == 0 ? ' ' : 'X';
                    Console.Write("{0,-2}",m[i,j]);
                    if (m[i, j] == 'X')
                    {
                        összeg += ÁR(i);
                        if (i == j) összegfőátló += ÁR(i);
                        if (i + j == 19) összegmellékátló += ÁR(i);
                    }
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Bevétel: {0}Ft",összeg);
            Console.WriteLine("Méglehetet volna: {0}Ft",(6*30*10000+8*30*7000+6*30*5000)-összeg);
            Console.WriteLine(összegfőátló > összegmellékátló ? "A fő átlóban volt több bevétel, összesen: {0}Ft" : "A mellék átlóban volt több bevétel, összesen: {1}Ft", összegfőátló, összegmellékátló);
            int sor = 0;
            bool ell = false;
            do
            {
                ell = false;
                try
                {
                    Console.Write("Hányadik sor?:");
                    sor = int.Parse(Console.ReadLine());
                }
                catch
                {
                    ell = true;
                }
                x = ÁR(sor);
            } while (sor > m.GetLength(0) || sor < 1 && ell);
            int oszlop = 0;
            do
            {
                ell = false;
                try
                {
                    Console.Write("Hányadik szék?:");
                    oszlop = int.Parse(Console.ReadLine());
                }
                catch
                {
                    ell = true;
                }
            } while (oszlop > m.GetLength(1) || oszlop < 1 && ell);
            Console.WriteLine(m[sor - 1,oszlop - 1] == 'X'? "Sajnos a hely már foglalt" : "A kiválszott helyre {0}Ft",x );
            Console.ReadKey();
        }
    }
}
//1. Ne lehessen kiakasztani
//2. Legyen 20x20-as színház és határozzuk meg hogy melyik átlóban volt több bevétel (átló neve, bevétel összege)
//3. Fejléc számok megcsinálása
