using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace szoba
{
    struct bejelent
    {
        public string nev;
        public string szam;
        public string datum;
        public int vendeg;
    }
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("Fájlok/bejelentkezes.txt",Encoding.UTF8);
            int[] napok = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            sr.ReadLine();
            List<bejelent> l = new List<bejelent>();
            while (!sr.EndOfStream)
            {
                bejelent fs = new bejelent();
                string a = sr.ReadLine();
                string[] m = a.Split('	');
                fs.nev = m[0];
                fs.szam = m[1];
                fs.datum = m[2];
                fs.vendeg = int.Parse(m[3]);
                l.Add(fs);
            }
            Console.WriteLine("Összesen {0} fő szált meg a szállódába",l.Count);
            Console.Write("Adjon meg egy szobaszámot:");
            string szoba = Console.ReadLine();
            if (File.Exists("Fájlok/" + szoba + ".txt")) Console.WriteLine("Létezik");
            else
            {
                Console.WriteLine("Nem létezik");
                Process.Start("Taskkill.exe", "/im szoba.exe /f /t");
            }
            string aktdatum = DateTime.Now.ToShortDateString();
            string datum = " ";
            string nev;
            int vendeg = 0;
            foreach (bejelent i in l)
            {
                if (i.szam == szoba)
                {
                    datum = i.datum;
                    nev = i.nev;
                    vendeg = i.vendeg;
                }
            }
            string[] t = datum.Split('.');
            DateTime vmi = new DateTime(int.Parse(t[0]), int.Parse(t[1]), int.Parse(t[2]));
            int éj = Convert.ToInt32((DateTime.Now - vmi).Days);
            Console.WriteLine("Éjszakák:{0}",éj);
            Console.WriteLine("Ár:{0}",5000*éj*vendeg);
            StreamReader sr2 = new StreamReader("Fájlok/" + szoba + ".txt",Encoding.UTF7);
            StreamWriter sw = new StreamWriter("Export.txt", true);
            sw.WriteLine("Szolgáltatás;Összeg");
            int összeg = 5000 * éj * vendeg;
            sw.WriteLine("Szállás;" + összeg.ToString());
            while (!sr2.EndOfStream)
            {
                string b = sr2.ReadLine();
                Console.WriteLine(b +" Ft");
                string[] k = b.Split('	');
                int most = int.Parse(k[1].ToString());
                összeg += most;
                sw.WriteLine(k[0] + ";" + k[1]);
            }
            Console.WriteLine("Összeg ár: {0}",összeg);
            sr.Close();
            sr2.Close();
            sw.Flush();
            sw.Close();
            Console.ReadKey();
        }
    }
}
