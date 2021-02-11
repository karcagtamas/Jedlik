using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hét_próba
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] m = new int[7, 20];
            int[] t = new int[7];
            string[] probák = { "60 m síkfutás", "távolugrás", "súlylökés", "magasugrás", "60 m gátfutás", "rúdugrás", "1000 m síkfutás" };
            Random r = new Random();
            int probaösszeg = 0,probaösszegmax = 0,probaindex = 0;
            for (int i = 0; i < m.GetLength(1); i++)
            {
                for (int j = 0; j < m.GetLength(0); j++)
                {
                    m[j, i] = r.Next(500, 1201);
                    probaösszeg += m[j, i];
                }
                if (probaösszegmax < probaösszeg)
                {
                    probaösszegmax = probaösszeg;
                    probaösszeg = 0;
                    probaindex = i;
                }
            }
            Console.WriteLine("Legtöbb pontot szerzett játékos: a {0}. játékos",probaindex);
            probaösszegmax = 0;
            probaösszeg = 0;
            probaindex = 0;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j] > probaösszeg)
                    {
                        probaösszeg = m[i,j];
                        probaindex = j;
                    }
                    Console.Write("{0} ", m[i, j]);
                }
                Console.WriteLine();
                t[i] = probaindex;
                probaösszeg = 0;
            }
            for (int i = 0; i < t.Length; i++)
            {
                Console.WriteLine("A/AZ {0} probában a legtöbb pontot a {1}. játékos érte el!",probák[i],t[i] + 1);
            }
            Console.ReadKey();
        }
    }
}
