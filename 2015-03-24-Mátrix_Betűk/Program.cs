using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feladat
{
    class Program
    {
        static void Main(string[] args)
        {
            int db = 0;
            char[,] m = new char[100, 100];
            string abc = "öüóqwertzuiopőúasdfghjkléáűíyxcvbnm";
            string maganhangzó = "öüóeuioőúaéáűí";
            Random r = new Random();
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    m[i, j] = abc[r.Next(0,abc.Length-1)];
                }
            }
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write("{0,-2}",m[i,j]);
                    if (maganhangzó.Contains(m[i, j])) db++;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("{0}db magánhangzó van a mátrixban!!!",db);
            Console.ReadKey();
        }
    }
}
