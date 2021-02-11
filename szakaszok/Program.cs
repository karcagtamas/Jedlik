using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace szakaszok
{
    class szakaszok
    {
        int sorszám;

        public int Sorszám
        {
            get { return sorszám; }
            set { sorszám = value; }
        }
        double a;

        public double A
        {
            get { return a; }
            set { a = value; }
        }
        double b;

        public double B
        {
            get { return b; }
            set { b = value; }
        }
        double c;

        public double C
        {
            get { return c; }
            set { c = value; }
        }
        string szín;

        public string Szín
        {
            get { return szín; }
            set { szín = value; }
        }
    }
    class Program
    {
        static bool ell(szakaszok sz)
        {
            double s = (sz.A + sz.B + sz.C) / 2;
            if (sz.A * sz.B / 2 == Math.Sqrt(s * (s - sz.A) * (s - sz.B) * (s - sz.C))) return true;
            return false;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("szakaszok.txt");
            List<szakaszok> l = new List<szakaszok>();
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] t = s.Split('#');
                szakaszok sz = new szakaszok();
                sz.Sorszám = int.Parse(t[0]);
                sz.A = Convert.ToDouble(t[1]);
                sz.B = Convert.ToDouble(t[2]);
                sz.C = Convert.ToDouble(t[3]);
                sz.Szín = t[4].ToLower();
                l.Add(sz);
            }
            Console.WriteLine("2. feladat:");
            int db = 0;
            foreach (szakaszok i in l)
            {
                if (i.A + i.B > i.C && i.B + i.C > i.A && i.C + i.A > i.B) db++;
            }
            Console.WriteLine("Megszerkezhető háromszögek száma: {0}db",db);
            Console.WriteLine("3. feladat:");
            double maxt = 0;
            int maxs = 0;
            double összpt = 0;
            for (int i = 0; i < l.Count; i++)
            {
                double s = (l[i].A + l[i].B + l[i].C) / 2;
                double T = Math.Sqrt(s*(s-l[i].A)*(s-l[i].B)*(s-l[i].C));
                if (T > maxt) { maxt = T; maxs = l[i].Sorszám; }
                if (l[i].Szín == "piros") összpt += T;
            }
            Console.WriteLine("Sorszám: {0}.   T={1:####.##}",maxs,maxt);
            Console.WriteLine("4. feladat:");
            Console.WriteLine("T={0:####.##}",összpt);
            Console.WriteLine("5. feladat:");
            foreach (szakaszok i in l)
            {
                if (i.A * i.A + i.B * i.B == i.C * i.C)
                {
                    double s = (i.A + i.B + i.C) / 2;
                    Console.WriteLine("Sorszám: {0}. a={1} b={2} c={3} T={4} Ell:{5} K={6}", i.Sorszám, i.A, i.B, i.C, Math.Sqrt(s * (s - i.A) * (s - i.B) * (s - i.C)), ell(i) ? "Egyenlő!" : "Eltérő!", s * 2);
                }
            }
            Console.ReadKey();
        }
    }
}
