using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Telefonos_segitség
{
    class Hívás
    {
        public int sorszám { get; set; }
        public int kóra { get; set; }
        public int kperc { get; set; }
        public int kmásodperc { get; set; }
        public int vóra { get; set; }
        public int vperc { get; set; }
        public int vmásodperc { get; set; }
        public int időtartam { get; set; }
        public TimeSpan kts { get; set; }
        public TimeSpan vts { get; set; }

        public Hívás()
        {

        }
        public void tomásodperc()
        {
            int x1 = vmásodperc + (vperc * 60) + (vóra * 3600);
            int x2 = kmásodperc + (kperc * 60) + (kóra * 3600);
            időtartam = x1 - x2;
        }
        public void todatetime()
        {
            kts = new TimeSpan(kóra, kperc, kmásodperc);
            vts = new TimeSpan(vóra, vperc, vmásodperc);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Hívás> l = new List<Hívás>();
            int[] bejövődb = new int[24];
            StreamReader sr = new StreamReader("hivas.txt");
            
            //2. feladat
            int db = 0;
            while (!sr.EndOfStream)
            {
                db++;
                Hívás h = new Hívás();
                string s = sr.ReadLine();
                string[] t = s.Split(' ');
                h.kóra = int.Parse(t[0]);
                h.kperc = int.Parse(t[1]);
                h.kmásodperc = int.Parse(t[2]);
                h.vóra = int.Parse(t[3]);
                h.vperc = int.Parse(t[4]);
                h.vmásodperc = int.Parse(t[5]);
                h.tomásodperc();
                h.todatetime();
                h.sorszám = db;
                l.Add(h);
            }
            sr.Close();
            
            //3. feladat / 4. feladat
            int leghosszidötartam = 0;
            int leghosszsorszám = 0;
            foreach (var i in l)
            {
                bejövődb[i.kóra]++;
                if (leghosszidötartam < i.időtartam)
                {
                    leghosszidötartam = i.időtartam;
                    leghosszsorszám = i.sorszám;
                }
            }
            Console.WriteLine("3. feladat:");
            for (int i = 0; i < bejövődb.Length; i++)
            {
                if (bejövődb[i] != 0) Console.WriteLine("{0} óra: {1}db hívás",i,bejövődb[i]);
            }
            Console.WriteLine("4. feladat:");
            Console.WriteLine("Leghosszabb hívás sorszáma: {0}",leghosszsorszám);
            Console.WriteLine("Leghosszabb hívás időtartama: {0} másodperc",leghosszidötartam);
            
            //5. feladat
            Console.WriteLine("5. feladat:");
            Console.Write("Adjon meg egy időpontot! (óra perc másodperc):");
            string bekérés = Console.ReadLine();
            string[] t2 = bekérés.Split();
            TimeSpan ts = new TimeSpan(int.Parse(t2[0]), int.Parse(t2[1]), int.Parse(t2[2]));
            int rsorszám = 0;
            int rvárakozók = -1;
            foreach (var i in l)
            {
                if (i.kts < ts && i.vts > ts)
                {
                    if (rvárakozók == -1)
                    {
                        rsorszám = i.sorszám;
                        rvárakozók++;
                    }
                    else
                    {
                        rvárakozók++;
                    }
                }
            }
            Console.WriteLine("A várakozók szama: {0} ",rvárakozók >= 0? rvárakozók : 0);
            if (rsorszám > 0) Console.WriteLine("A beszelo a {0}. hívó",rsorszám);
            else Console.WriteLine("Nem beszélt ekkor senki!");
            
            //6. feladat
            Hívás utolsó = l[l.Count - 1];
            TimeSpan eltérés = l[l.Count - 2].vts - utolsó.kts;
            int eltéréss = (eltérés.Hours * 3600) + (eltérés.Minutes * 60) + eltérés.Seconds;
            Console.WriteLine("6. feladat:");
            Console.WriteLine("Az utolsó telefonaló adatai a(z) {0}. sorban vannak, {1} másodpercig várt.",utolsó.sorszám, eltéréss >= 0? eltéréss : 0);
            
            //7. feladat
            StreamWriter sw = new StreamWriter("sikeres.txt",false);
            Hívás h2 = l[0];
            foreach (var i in l)
            {
                if (i.kóra >= 8 && i.kóra < 12)
                {
                    if (h2.vts < i.kts)
                    {
                        sw.WriteLine($"{i.sorszám} {i.kóra} {i.kperc} {i.kmásodperc} {i.vóra} {i.vperc} {i.vmásodperc}");
                        h2 = i;
                    }
                }
            }
            Console.WriteLine("sikeres.txt fájl elkészült! :D");
            sw.Flush();
            sw.Close();
            Console.ReadKey();
        }
    }
}
