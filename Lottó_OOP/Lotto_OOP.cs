using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lottó_OOP
{
    class Húzás
    {
        private byte[] t;

        public Húzás(string sor, bool rendezés)
        {
            t = new byte[5];
            string[] m = sor.Split();
            for (int i = 0; i < m.Length; i++)
            {
                t[i] = byte.Parse(m[i]);
            }
            if (rendezés) Rendez();
        }
        private void Rendez()
        {
            Array.Sort(t);
            
        }
        public void kiir()
        {
            for (int i = 0; i < t.Length; i++)
            {
                Console.Write(t[i] + " ");
            }
            Console.WriteLine();
            
        }
        public bool vane(int x)
        {
            bool feltétel = false;
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == x) feltétel = true;
            }
            return feltétel;
        }
        public int páratlan()
        {
            int db = 0;
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] % 2 == 1) db++;
            }
            return db;
        }
        public override string ToString()
        {
            return String.Join(" ", t);
        }
        public void hozzaadd(ref int[] m)
        {
            for (int i = 0; i < t.Length; i++)
            {
                m[t[i] - 1]++;
            }
        }
    }
    class Lotto_OOP
    {
        static void Main(string[] args)
        {
            Dictionary<int, Húzás> h = new Dictionary<int, Húzás>();

            string[] s = File.ReadAllLines("lottosz.dat");
            for (int i = 0; i < s.Length; i++)
            {
                h.Add(i + 1, new Húzás(s[i], true));
            }

            Console.WriteLine("Adja meg a Lottó számait Space-el elválasztva!");
            h.Add(52, new Húzás(Console.ReadLine(), true));
            h[52].kiir();

            Console.WriteLine("Adjon meg egy számot 1 és 51 között");
            h[int.Parse(Console.ReadLine())].kiir();

            int lv = 0;
            bool feltétel = true;
            do
            {
                lv++;
                for (int i = 1; i < 91; i++)
                {
                    feltétel = h[lv].vane(i);
                }
                
            } while (feltétel || lv != 52);

            Console.WriteLine(lv != 0?"Van olyan szám":"Nincs olyan szám");

            int pdb = 0;
            for (int i = 1; i < h.Count; i++)
            {
                pdb += h[i].páratlan();
            }

            Console.WriteLine(pdb);

            //List<string> l = new List<string>(File.ReadAllLines("lottosz.dat"));
            List<string> l = new List<string>();
            for (int i = 1; i < h.Count; i++)
            {
                l.Add(h[i].ToString());
            }
            File.WriteAllLines("lotto52.ki", l);
            Console.WriteLine(h[1].ToString());

            int[] m = new int[90];

            for (int i = 1; i < h.Count; i++)
            {
                h[i].hozzaadd(ref m);
            }
            for (int i = 0; i < m.Length; i++)
            {
                Console.Write("{0} ", m[i]);
                if (i % 15 == 0) Console.WriteLine();
            }
            Console.WriteLine();

            int[] pm = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89 };
            bool[] pmb = new bool[pm.Length];

            for (int i = 0; i < pm.Length; i++)
            {
                for (int j = 1; j < h.Count; j++)
                {
                    if (h[j].vane(pm[i])) pmb[i] = true;
                    else pmb[i] = false;
                }
            }


            for (int i = 0; i < pm.Length; i++)
            {
                if (pmb[i]) Console.WriteLine(pm[i]);
            }
            



            Console.ReadKey();
        }
    }
}
