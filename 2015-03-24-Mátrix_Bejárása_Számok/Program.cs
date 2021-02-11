using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mátrix_bejárása
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            byte[,] m = new byte[6, 5];
            Random r = new Random();
            for (int sor = 0; sor < m.GetLength(0); sor++)
            {
                for (int oszlop = 0; oszlop < m.GetLength(1); oszlop++)
                {
                    m[sor, oszlop] = (byte)r.Next(0, 10);
                }
            }
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write("{0,-2}",m[i,j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            int osz = m.GetLength(1);
            for (int i = 0; i < m.Length; i++)
            {
                int sor = i / osz;
                int oszlop = i % osz;
                Console.Write("{0,-2}",m[sor,oszlop]);
                if (oszlop == osz - 1) Console.WriteLine();    
            }
            byte pszdb = 0;//páratlan számok darab száma
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j] % 2 == 1) pszdb++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("{0} páratlan szám van a mátrixban!!!",pszdb);
            Console.ReadKey();
        }
    }
}
