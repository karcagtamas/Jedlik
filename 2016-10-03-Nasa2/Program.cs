using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace nasa2
{
    class adatok
    {
        string forrás;
        string dátum;
        string adat;
        int szám;
        int menyiség;

        public string Forrás
        {
            get
            {
                return forrás;
            }

            set
            {
                forrás = value;
            }
        }

        public string Dátum
        {
            get
            {
                return dátum;
            }

            set
            {
                dátum = value;
            }
        }

        public string Adat
        {
            get
            {
                return adat;
            }

            set
            {
                adat = value;
            }
        }

        public int Szám
        {
            get
            {
                return szám;
            }

            set
            {
                szám = value;
            }
        }

        public int Menyiség
        {
            get
            {
                return menyiség;
            }

            set
            {
                menyiség = value;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader sr = new StreamReader("05_Jul_1995.txt");
            List<adatok> la = new List<adatok>();
            ulong össz = 0;
            while (!sr.EndOfStream)
            {
                adatok a = new adatok();
                string s = sr.ReadLine();
                string[] t = s.Split(' ');
                a.Forrás = t[0];
                a.Dátum = t[3].TrimStart('[');
                a.Adat = t[5] + " " + t[6] + " " +t[7];
                try
                {
                    a.Szám = int.Parse(t[8]);
                }
                catch (Exception)
                {
                    a.Szám = 0;
                }
                try
                {
                    a.Menyiség = int.Parse(t[9]);
                }
                catch (Exception)
                {
                    a.Menyiség = 0;
                }
                össz += (ulong)a.Menyiség;
                la.Add(a);
            }
            Console.WriteLine("Elérések száma: {0}",la.Count);
            Console.WriteLine("Ennyi bájtnyi adat volt: {0}",össz);
            foreach (var i in la)
            {
                foreach (var j in i.Forrás)
                {
                    if (j == '.') Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
//statisztika
//1. elérések száma
//2. hány bájtnyi adatot töltöttek le?
//3. Határozd meg hogy az elérések hány százalékánál nem volt ismert a domain név
//4. Óránkénti elérések száma
//5. Fájlba tároljuk a log fájlt új formátum szerint (név*elérésideje*utolsó_előtti_szám(szövegesen a hibát)*adatmenyiség(2 jegy és kéttizedes jegy))