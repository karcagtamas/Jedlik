using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace egyszamjatek
{
    class Player
    {
        string name;
        byte[] t;

        public Player()
        {
            t = new byte[10];
        }

        public string Name { get => name; set => name = value; }
        public byte[] T { get => t; set => t = value; }

        public bool volte(byte a)
        {
            if (t[0] == a) return true;
            return false;
        }
        public byte maximum(byte a)
        {
            for (int i = 0; i < t.Length; i++)
            {
                if (a < t[i]) a = t[i];
            }
            return a;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> l = new List<Player>();   
            StreamReader sr = new StreamReader("egyszamjatek.txt");
            while (!sr.EndOfStream)
            {
                Player p = new Player();
                string[] s = sr.ReadLine().Split(' ');
                for (int i = 1; i < s.Length - 1; i++)
                {
                    p.T[i - 1] = byte.Parse(s[i]);
                }
                p.Name = s[0];
                l.Add(p);
            }

            Console.Write("3. Feladat: ");
            Console.WriteLine($"Játékosok száma: {l.Count}");
            Console.Write("4. Feladat: ");
            Console.WriteLine($"Fordulók száma: {l[0].T.Length}");
            bool feltetel = false;
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].volte(1)) feltetel = true;
            }

            Console.Write("5. Feladat: ");
            Console.WriteLine(feltetel?"Az első fordulóban volt egyes tipp!":"Az első fordulóban nem volt egyes tipp!");
            byte max = 0;
            for (int i = 0; i < l.Count; i++)
            {
                max = l[i].maximum(max);
            }

            Console.Write("6. Feladat: ");
            Console.WriteLine($"A legnagyobb tipp a fordulók során: {max}");

            Console.Write("7. Feladat: ");
            Console.Write($"Kérem a forduló sorszámát [1-{l[0].T.Length}]: ");
            byte mford;
            try
            {
                mford = byte.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                mford = 1;                
            }
            if (mford > l[0].T.Length || mford < 1) mford = 1;
            int nyertesertek = 0;
            for (int i = 1; i <= max; i++)
            {
                byte ertek = 0;
                for (int j = 0; j < l.Count; j++)
                {
                    if (l[j].T[mford - 1] == i) ertek++;
                }
                if (ertek == 1) { nyertesertek = i; break; }
            }

            Console.Write("8. Feladat: ");
            Console.WriteLine(nyertesertek != 0? $"A nyertes tipp a megadott fordulóban: {nyertesertek}" : "A nyertes tipp a megadott fordulóban: Nincs győztes");

            string nyertesname = "";
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].T[mford - 1] == nyertesertek) nyertesname = l[i].Name;
            }

            Console.Write("9. Feladat: ");
            Console.WriteLine(nyertesname != ""?$"A megadott forduló nyertese: {nyertesname}" : "A megadott forduló nyertese: Nincs győztes");

            if (nyertesertek != 0)
            {
                string[] st = new string[3];
                st[0] = $"Forduló sorszáma: {mford}";
                st[1] = $"Nyertes tipp: {nyertesertek}";
                st[2] = $"Nyertes játékos: {nyertesname}";

                if (!File.Exists("nyertes.txt")) File.Create("nyertes.txt");
                File.WriteAllLines("nyertes.txt", st);
            }

            Console.ReadKey();

        }
    }
}
