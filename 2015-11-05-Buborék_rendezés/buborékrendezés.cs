using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buborék_rendezés
{
    class buborékrendezés
    {
        static void kiir(int[] t)
        {
            foreach (var i in t) Console.Write("{0}, ", i);
            Console.WriteLine("\b\b ");
        }
        static void csere(ref int x,ref int y)
        {
            x += y;
            y = x - y;
            x -= y;
        }
        static void Main(string[] args)
        {
            int[] t = new int[10];
            Random r = new Random();

            for (int i = 0; i < t.Length; i++)
            {
                t[i] = r.Next(100, 1000);
            }

            kiir(t);

            bool cserevolt = true;
            for (int ig = t.Length - 1; ig > 0 && cserevolt; ig--)
            {
                cserevolt = false;
                for (int i = 0; i < ig; i++)
                {
                    if (t[i] > t[i + 1])
                    {
                        //int segéd = t[i];
                        //t[i] = t[i + 1];
                        //t[i + 1] = segéd;
                        //t[i] += t[i + 1];
                        //t[i + 1] = t[i] - t[i + 1];
                        //t[i] -= t[i + 1];
                        csere(ref t[i],ref t[i + 1]);
                        cserevolt = true;
                    }
                }
            }
            kiir(t);
            Console.ReadKey();
        }
    }
}
