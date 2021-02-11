using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_Csüt
{
    class Program
    {
        static int bekérés()
        {
            Console.Write("Adja meg a lista hosszát: ");
            return int.Parse(Console.ReadLine());
        }
        static void feltöltés(List<int> l,int n)
        {
            Random r = new Random();
            for (int i = 0; i <= n - 1; i++)
            {
                if (i == 0)
                {
                    l.Add(r.Next(10, 31));
                }
                else
                {
                    l.Add(l[i - 1] + r.Next(1,6));
                }
            }
        }
        static void kiirási(List<int> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                
                if (i == l.Count - 1) Console.Write(l[i]);
                else Console.Write(l[i] + ", ");
            }
            Console.WriteLine();
        }
        static void kiirásd(List<string> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (i == l.Count - 1) Console.Write(l[i]);
                else Console.Write(l[i] + ", ");
            }
            Console.WriteLine();
        }
        static double átlag(List<int> l)
        {
            int összeg = 0;
            for (int i = 0; i < l.Count; i++)
            {
                összeg += l[i];
            }
            return összeg / (double)l.Count;
        }
        static void beolvasás(ref List<string> l2, StreamReader sr)
        {
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] t = s.Split(',');

                for (int i = 0; i < t.Length; i++)
                {
                    //t[i].Replace('.',',');
                    //t[i].Remove(t[i].IndexOf('.'), 1);
                    //if (i != 0) t[i].TrimStart(' ');
                    //l2.Add(Convert.ToInt32(t[i]));
                    //double d = Convert.ToDouble(t[i]);
                    //int d = int.Parse(t[i]);
                    l2.Add(t[i]);
                }
            }
        }
        static void Main()
        {
            int n = bekérés();
            List<int> l = new List<int>();
            List<string> l2 = new List<string>();
            List<int> l3 = new List<int>();
            feltöltés(l,n);
            kiirási(l);
            Console.WriteLine();
            Console.WriteLine("Átlag: {0:##.##}",átlag(l));

            Console.WriteLine();
            StreamReader sr = new StreamReader("16.7-1.txt");
            beolvasás(ref l2, sr);
            kiirásd(l2);

            Console.WriteLine();
            int határ = 100;
            int db = 1;
            int összeg = 0;
            while (összeg <= határ)
            {
                Console.Write("Kérem az {0}. számot: ",db);
                int x = int.Parse(Console.ReadLine());
                l3.Add(x);
                összeg += x;
                db++;
            }
            kiirási(l3);
            átlag(l3);
            Console.WriteLine("Átlag: {0:##.##}", átlag(l3));
            Console.ReadKey();
        }
    }
}
