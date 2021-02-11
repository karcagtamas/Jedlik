using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Játék
    {
        ConsoleColor szín = ConsoleColor.Gray;
        public ConsoleColor Szín
        {
            get { return this.szín; }
            set { this.szín = value; }
        }

        public void Vezérlés()
        {
            Menü m = new Menü(1, 1, new List<string>() { "Játék", "Kígyó színe", "Kilépés" });            
            int válasz = 1;
            int válasz1 = 1;
            Csemege cs = new Csemege();
            while (válasz > -1)
            {
                válasz = m.Frissítés();
                switch (válasz)
                {
                    case 0: Console.Clear();
                        Kígyó k = new Kígyó();
                        do
                        {
                            Console.ForegroundColor = Szín;
                            k.Mozgat();
                            if (k.Hossz > 12) k = new Szuperkígyó(k);
                        }
                        while (true);
                    case 1: Menü m1 = new Menü(15, 1, new List<string>() { "Piros", "Fehér", "Zöld", "Sárga", "Bíbor" }); válasz1 = m1.Frissítés(); break;
                    case 2: Environment.Exit(0); break;
                }
                switch(válasz1)
                {
                    case 0: Szín = ConsoleColor.Red; break;
                    case 1: Szín = ConsoleColor.White; break;
                    case 2: Szín = ConsoleColor.Green; break;
                    case 3: Szín = ConsoleColor.Yellow; break;
                    case 4: Szín = ConsoleColor.Magenta; break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Játék j = new Játék();
            j.Vezérlés();
        }
    }
}
