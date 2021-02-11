using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kalapacsvetes2016
{
    class Versenyző
    {
        public List<string> Dobások;
        public bool DöntötFolytathatja { get { if (Dobások.Count > 3) return true; return false; } }
        public string Név { get; set; }
        public string Ország { get; set; }
        public byte SikertelenDobásokSzáma
        {
            get
            {
                byte db = 0;
                foreach (var i in Dobások)
                {
                    if (i == "x") db++;
                }
                return db;
            }
        }
        public byte ÉrvényesDobásokSzáma
        {
            get
            {
                byte db = 0;
                foreach (var i in Dobások)
                {
                    if (i != "x") db++;
                }
                return db;
            }
        }
        public double LegjobbEredmény
        {
            get
            {
                double max = 0;
                foreach (var i in Dobások)
                {
                    if (i != "x" && max < Convert.ToDouble(i)) max = Convert.ToDouble(i);
                }
                return max;
            }
        }
        public Versenyző(string s)
        {
            Dobások = new List<string>();
            string[] t = s.Split(';');
            this.Név = t[0];
            this.Ország = t[1];
            for (int i = 2; i < t.Length; i++)
            {
                Dobások.Add(t[i]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Versenyző> l = new List<Versenyző>();
            string[] t = File.ReadAllLines("kalapacsvetes2016.txt");
            foreach (var i in t)
            {
                l.Add(new Versenyző(i));
            }
            Console.Write("5. feladat: Döntőbe jutott versenyzők száma: ");
            Console.WriteLine(l.Count);
            byte db = 0;
            foreach (var i in l)
            {
                if (i.DöntötFolytathatja) db++;
            }
            Console.WriteLine($"6. feladat: A 3. dobás után {db} versenyző folytathatta a döntőt.");
            Console.WriteLine("7. feladat: Statisztika (név; érvényes_dobás; sikertelen_dobás; legjobb_dobás)");
            foreach (var i in l)
            {
                if (i.DöntötFolytathatja)
                {
                    Console.WriteLine($"{i.Név}; {i.ÉrvényesDobásokSzáma}; {i.SikertelenDobásokSzáma}; {i.LegjobbEredmény}cm");
                }
            }
            foreach (var i in l)
            {
                if (i.Ország == "Magyarország")
                {
                    byte hely = 1;
                    foreach (var j in l)
                    {
                        if (j.DöntötFolytathatja && i.LegjobbEredmény < j.LegjobbEredmény) hely++;
                    }
                    Console.WriteLine($"8. feladat: A magyar versenyző {i.Név} {hely}. lett!");
                }
            }
            string[] s = new string[l.Count];
            for (int i = 0; i < l.Count; i++)
            {
                s[i] = l[i].Név;
                s[i] += ";"+l[i].Ország;
                foreach (var j in l[i].Dobások)
                {
                    if (j == "x")
                    {
                        s[i] += ";" + j;
                    }
                    else
                    {
                        s[i] += ";" + (Math.Round(Convert.ToDouble(j) * 2.54, 2)).ToString();
                    }
                }
            }
            File.WriteAllLines("kalapacsvetes2016inch.txt", s, Encoding.UTF8);
            Console.ReadKey();
        }
    }
}
