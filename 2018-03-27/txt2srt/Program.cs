using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace txt2srt
{
    class IdozitettFelirat
    {
        public string Időzítés;
        public string Felirat;

        public IdozitettFelirat(string i, string f)
        {
            this.Időzítés = i;
            this.Felirat = f;
        }

        public int SzavakSzama()
        {
            return Felirat.Split(' ').Length;
        }
        public void SrtIdozites()
        {
            Időzítés = Időzítés.Insert(Időzítés.IndexOf('-') + 1, "->");
            string[] S = Időzítés.Split(' ');
            string[] s1 = S[0].Split(':');
            string[] s2 = S[2].Split(':');
            int x1 = Convert.ToInt32(s1[0]);
            int x2 = Convert.ToInt32(s2[0]);
            string a1;
            if (x1 > 59)
            {
                a1 = (x1 / 60).ToString() + ":";
                if (a1.Length != 3)
                {
                    a1 = a1.Insert(0, "0");
                }
            }
            else
            {
                a1 = "00:";
            }
            a1 += (x1 - ((x1 / 60) * 60)).ToString() + ":";
            a1 += s1[1];
            if (a1.Length != 8)
            {
                a1 = a1.Insert(a1.IndexOf(':') + 1, "0");
            }
            string a2;
            if (x2 > 59)
            {
                a2 = (x2 / 60).ToString() + ":";
                if (a2.Length != 3)
                {
                    a2 = a2.Insert(0, "0");
                }
            }
            else
            {
                a2 = "00:";
            }
            a2 += (x2 - ((x2 / 60) * 60)).ToString() + ":";
            a2 += s2[1];
            if (a2.Length != 8)
            {
                a2 = a2.Insert(a2.IndexOf(':') + 1, "0");
            }
            Időzítés = a1 + " " + S[1] + " " + a2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<IdozitettFelirat> l = new List<IdozitettFelirat>();

            string[] s = File.ReadAllLines("feliratok.txt",Encoding.UTF8);

            for (int i = 0; i < s.Length - 1; i += 2)
            {
                IdozitettFelirat IF = new IdozitettFelirat(s[i], s[i + 1]);
                l.Add(IF);
            }
            Console.Write("5. feladat - Feliratok száma: ");
            Console.WriteLine(l.Count);
            int index = 0;
            int max = 0;
            for (int i = 0; i < l.Count -1 ; i++)
            {
                if (max < l[i].SzavakSzama())
                {
                    max = l[i].SzavakSzama();
                    index = i;
                }
            }
            Console.WriteLine("7. feladat - Legtöbb szóból álló felirat: ");
            Console.WriteLine(l[index].Felirat);

            List<string> ls = new List<string>();
            for (int i = 0; i < l.Count - 1; i++)
            {
                ls.Add((i + 1).ToString());
                l[i].SrtIdozites();
                ls.Add(l[i].Időzítés);
                ls.Add(l[i].Felirat);
                ls.Add(" ");
            }
            File.WriteAllLines("felirat.srt", ls, Encoding.UTF8);
            Console.ReadKey();
        }
    }
}
