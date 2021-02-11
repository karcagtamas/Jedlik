using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hőmérséklet
{
    class Program
    {
        static int ell(int[] m, int érték)
        {
            int nap = 0;
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] == érték) nap = i + 1;
            }
            return nap;
        }
        static void Main(string[] args)
        {
            int[] t = new int[31];
            Random r = new Random();
            List<int> l = new List<int>();
            int elöző = r.Next(15,46);
            t[0] = elöző;
            int összeg = elöző;
            int min = elöző;
            int max = elöző;
            for (int i = 1; i < t.Length; i++)
            {
                if (elöző >= 20 && elöző <= 40) t[i] = r.Next(elöző - 5, elöző + 6);
                else if (elöző < 20) t[i] = r.Next(15, elöző + 6);
                else if (elöző > 40) t[i] = r.Next(elöző - 5, 46);
                elöző = t[i];
                összeg = összeg + t[i];
                if (min > t[i]) min = t[i];
                if (max < t[i]) max = t[i];
                if (t[i] >= 40) l.Add(i);
            }
            int átlag = összeg / t.Length;
            Console.WriteLine("Augusztusi átlag hőmérséklet: {0:#.##}",(double)összeg / t.Length);
            Console.WriteLine("Augusztusi legnagyobb hőmérséklet: {0} a {1}. napon", max,ell(t, max));
            Console.WriteLine("Augusztusi legkisebb hőmérséklet: {0} a {1}. napon", min, ell(t, min));
            for (int i = 0; i < l.Count; i++)
            {
                Console.WriteLine("40 fok feletti hőmérséklet a {0}. napon",l[i]);
            }
            for (int i = 0; i < t.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (t[i] == max) Console.ForegroundColor = ConsoleColor.Red;
                if (t[i] == min) Console.ForegroundColor = ConsoleColor.Blue;
                double szám = (átlag + 1) - (double)összeg / t.Length;
                if (szám < 0.5) átlag++;
                if (t[i] == átlag) Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("{0} ",t[i]);
            }
            Console.ReadKey();
        }
    }
}
