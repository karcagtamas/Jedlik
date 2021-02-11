using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    class Játék
    {
        public Játék()//Fő menü
        {
            Console.Title = "Snake by TOM";
            Console.WindowWidth = Console.LargestWindowWidth - 50;
            Console.WindowHeight = Console.LargestWindowHeight - 10;
            Console.SetWindowPosition(0,0);
            Menü m = new Menü((Console.WindowWidth / 2) - 6, Console.WindowHeight / 2 - 2, new List<string> { "Inditás", "Beállítások", "Rangsor","Súgó","Bezárás" });
            int válasz = 1;
            while (válasz > -1)
            {
                válasz = m.Frissités();
                switch (válasz)
                {
                    case 0: kigyó(); break;
                    case 1: this.Beállítás(); break;
                    case 2: this.Stat(); break;
                    case 3: this.Súgó(); break;
                    case 4: Environment.Exit(0); break;
                }
            }
        }
        private void kigyó() //A kigyót elinditó függvény
        {
            Console.Clear();  Kigyó k = new Kigyó(100);
            Szuperkigyó szk = new Szuperkigyó(k);
            SzivárványKigyó szivk = new SzivárványKigyó(szk);
        }
        private void Stat()//Statisztika kiiró függvény
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            List<string> l1 = new List<string>();
            List<int> l2 = new List<int>();
            List<int> l3 = new List<int>();
            Console.Clear();
            int sz = 5;
            int top = 1;
            Console.SetCursorPosition((Console.WindowWidth / 2) - ("Statisztika".Length / 2),sz - 1);
            Console.WriteLine("Statisztika");
            StreamReader sr = new StreamReader("stat.txt");
            do
            {
                string s = sr.ReadLine();
                if (s != "")
                {
                    string[] t = s.Split(';');
                    l1.Add(t[0]);
                    l2.Add(int.Parse(t[1]));
                    l3.Add(int.Parse(t[2]));
                }
            } while (!sr.EndOfStream);
            int meddig = l2.Count > 10 ? 10 : l2.Count;
            for (int j = l2.Max(); j >= meddig; j--)
            {
                for (int i = 0; i < l2.Count; i++)
                {
                    if (j == l2[i] && top < 11)
                    {
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 20, sz);
                        Console.WriteLine(top.ToString() +". "+ l1[i]);
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 5, sz);
                        Console.WriteLine("Pontok: " + l2[i]);
                        Console.SetCursorPosition((Console.WindowWidth / 2) + 10, sz);
                        Console.WriteLine("Lépések: " + l3[i]);
                        sz++;
                        top++;
                    }
                }
            }
            Menü m = new Menü(2, 2, new List<string> { "Vissza", "Bezárás" });
            int válasz = 1;
            while (válasz > -1)
            {
                válasz = m.Frissités();
                switch (válasz)
                {
                    case 0: Console.Clear(); Játék j = new Játék(); break;
                    case 1: Environment.Exit(0); break;
                }
            }
        }
        private void Beállítás()//Beállítást kiiró függvény
        {
            Console.Clear();
            Menü m = new Menü((Console.WindowWidth / 2) - 6, Console.WindowHeight / 2 - 2, new List<string> { "Könnyű", "Közepes", "Nehéz","Vissza"});
            int válasz = 1;
            while (válasz > -1)
            {
                válasz = m.Frissités();
                switch (válasz)
                {
                    case 2: Console.Clear(); Kigyó k = new Kigyó(80); break;
                    case 1: Console.Clear(); Kigyó k1 = new Kigyó(90); break;
                    case 0: Console.Clear(); Kigyó k2 = new Kigyó(100); break;
                    case 3: Console.Clear(); Játék j = new Játék(); break;
                }
            }
        }
        private void Súgó()
        {
            int számláló = 0;
            StreamReader sr = new StreamReader("sugo.txt",Encoding.UTF7);
            List<string> l = new List<string>();
            while (!sr.EndOfStream)
            {
                l.Add(sr.ReadLine());
                számláló++;
            }
            Console.Clear();
            foreach (var i in l)
            {
                Console.WriteLine(i);
            }
            Menü m = new Menü((Console.WindowWidth / 2) - 6, számláló + 1, new List<string> {"Értem"});
            int válasz = 1;
            while (válasz > -1)
            {
                válasz = m.Frissités();
                switch (válasz)
                {
                    case 0: Console.Clear(); Játék j = new Játék(); break;
                }
            }
        }
    }
}
