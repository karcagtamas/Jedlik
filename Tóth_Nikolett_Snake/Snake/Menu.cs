using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Keret
    {
        private int x;
        private int y;
        private int szélesség;
        private int magasság;

        public virtual int Szélesség
        {
            get { return szélesség; }
            set
            {
                if (value >= 0 && value < Console.WindowWidth - 2)
                {
                    if (this.X + value > Console.WindowWidth - 2)
                    {
                        this.szélesség = Console.WindowWidth - 2 - this.X;
                    }
                    else this.szélesség = value;
                }
            }
        }
        public virtual int Magasság
        {
            get { return magasság; }
            set
            {
                if (value >= 0 && value < Console.WindowHeight - 2)
                {
                    if (this.Y + value > Console.WindowHeight - 2)
                    {
                        this.magasság = Console.WindowHeight - 2 - this.Y;
                    }
                    else this.magasság = value;
                }
            }
        }
        public virtual int Y
        {
            get { return y; }
            set { if (this.y + this.magasság < Console.WindowHeight) y = value; }
        }
        public virtual int X
        {
            get { return x; }
            set { if (this.x + this.szélesség < Console.WindowWidth) x = value; }
        }

        public virtual void Rajzol()
        {
            int akty = this.y;
            Console.SetCursorPosition(this.x, this.y);
            for (int i = 0; i < this.magasság; i++)
            {
                if (i == 0 || i == this.magasság - 1)
                {
                    if (i == 0) Console.Write("╔{0}╗", "".PadLeft(this.szélesség - 2, '═'));
                    else Console.Write("╚{0}╝", "".PadLeft(this.szélesség - 2, '═'));
                }

                else
                {
                    Console.WriteLine("║{0}║", " ".PadLeft(this.szélesség - 2));
                }
                akty++;
                Console.SetCursorPosition(this.x, akty);
            }
        }

        public virtual void Töröl()
        {
            Console.SetCursorPosition(this.x, this.y);
            for (int i = 0; i < this.magasság; i++)
            {
                Console.WriteLine(" ".PadLeft(this.szélesség));
            }
        }
    }
    class Menü : Keret
    {
        private List<string> menüpontok;
        private int aktív = 0;

        public int Aktív
        {
            get
            {
                return aktív;
            }
            set
            {
                if (value >= 0 && value < this.menüpontok.Count()) aktív = value;
                this.Rajzol();
            }
        }
        public Menü(int x, int y, List<string> list)
        {
            this.X = x;
            this.Y = y;
            this.menüpontok = list;

            int maxszélesség = 0;
            foreach (string menüpont in this.menüpontok)
            {
                if (menüpont.Length > maxszélesség) maxszélesség = menüpont.Length;
            }
            this.Szélesség = maxszélesség + 2;
            this.Magasság = this.menüpontok.Count() + 2;
            this.Rajzol();
        }

        public override void Rajzol()
        {
            base.Rajzol();

            int db = 0;
            foreach (string menüpont in menüpontok)
            {
                if (db == this.Aktív)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.SetCursorPosition(this.X + 1, this.Y + 1 + db++);
                Console.WriteLine(menüpont);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        public int Frissítés()
        {
            this.Rajzol();
            ConsoleKey ch;
            do
            {
                ch = Console.ReadKey(true).Key;
                if (ch == ConsoleKey.UpArrow) this.Aktív--;
                if (ch == ConsoleKey.DownArrow) this.Aktív++;
                if (ch == ConsoleKey.Enter) return this.Aktív;
            }
            while (ch != ConsoleKey.Escape);
            return -1;
        }
    }
}

