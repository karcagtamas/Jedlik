using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace autók
{
    class Autó
    {
        List<string> l = new List<string>();
        Random r = new Random();
        public Autó(string s)
        {
            StreamReader sr = new StreamReader(s);
            while (!sr.EndOfStream)
            {
                l.Add(sr.ReadLine());
            }
            sr.Close();
            Console.WriteLine();
            Console.WriteLine(random1());
            Console.WriteLine();
            foreach (var i in random2(r.Next(l.Count)))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            foreach (var i in random3(r.Next(l.Count)))
            {
                Console.WriteLine(i);
            }
        }
        public string random1()
        {
            return l[r.Next(l.Count)];
        }
        public virtual string[] random2(int x)
        {
            string[] t = new string[x];
            for (int i = 0; i < t.Length; i++)
            {
                bool volte = false;
                string a;
                do
                {
                    volte = false;
                    a = l[r.Next(l.Count)];
                    for (int j = 0; j < t.Length; j++)
                    {
                        if (t[j] == a) volte = true;
                    }
                } while (volte);
                t[i] = a;
                Thread.Sleep(100);
            }
            return t;
        }
        public virtual List<string> random3(int x)
        {
            List<string> la = new List<string>();
            for (int i = 0; i < x; i++)
            {
                string a = l[r.Next(l.Count)];
                if (!la.Contains(a)) la.Add(l[r.Next(l.Count)]);
                else i--;
                Thread.Sleep(100);
            }
            return la;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Add meg a fájl nevét: ");
            Autó a = new Autó(Console.ReadLine());
            Console.ReadKey();
        }
    }
}
//egy osztály beolvassa a fájlt - új random osztály
//metódus randomizál 1 elemet
//n generálás úgy hogy nem lehetnek ismétlések (metódus legyen - egyik listával a másik string tömbbel térjen vissza(túl töltés))