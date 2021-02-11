using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Menü : ExtraKeret
    {
        private List<string> menüpontok;
        int aktiv = 0;

        public int Aktiv
        {
            get
            {
                return aktiv;
            }
            set
            {
                aktiv = value;
                this.Rajzol();
            }
        }
        public Menü(int x, int y, List<string> list)
        {
            this.X = x;
            this.Y = y;
            this.menüpontok = list;
            int maxsz = 0;
            foreach (string menüpont in this.menüpontok)
            {
                if (menüpont.Length > maxsz) maxsz = menüpont.Length;
            }
            this.SZ = maxsz + 2;
            this.M = this.menüpontok.Count + 2;
            this.Rajzol();
        }
        public override void Rajzol()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            base.Rajzol();
            int db = 0; ;
            foreach (string menüpont in this.menüpontok)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Random r = new Random();
                if (db == this.Aktiv)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                }
                Console.SetCursorPosition(this.X + 1, this.Y + 1 + db++);
                Console.WriteLine(menüpont);
                Console.BackgroundColor = ConsoleColor.Black;
            }

        }
        public int Frissités()
        {
            ConsoleKey ck;
            do
            {
                ck = Console.ReadKey(true).Key;
                if (ck == ConsoleKey.UpArrow) if (this.aktiv > 0) this.Aktiv--; else this.Aktiv = this.menüpontok.Count - 1;
                if (ck == ConsoleKey.DownArrow) if (this.aktiv < this.menüpontok.Count - 1) this.Aktiv++; else this.Aktiv = 0;
                if (ck == ConsoleKey.Enter) return this.Aktiv;
            } while (ck != ConsoleKey.Escape);
            return -1;
        }
    }
}
