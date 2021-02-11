using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Menü : Játék
    {
        
        
        protected string[] Méretek = { "Kicsi", "Közepes", "Nagy" };
        public int Aktívméret
        {
            get { return base.aktívméret; }
            set
            {
                if (value >= 0 && value < this.Méretek.Length)
                { 
                    base.aktívméret = value;
                    this.Sortörlés();
                    this.Menük[1] = "Pálya mérete: <- " + this.Méretek[value] + " ->";
                    this.Kirajzolás();
                }
                else
                {
                    if (value < 0)
                    {
                        base.aktívméret = this.Méretek.Length - 1; 
                        this.Sortörlés();
                        this.Menük[1] = "Pálya mérete: <- " + this.Méretek[this.Méretek.Length - 1] + " ->";
                        this.Kirajzolás();
                    }
                    else
                    {
                        base.aktívméret = 0;
                        this.Sortörlés();
                        this.Menük[1] = "Pálya mérete: <- " + this.Méretek[0] + " ->";
                        this.Kirajzolás();
                    }
                }
            }
        }
        string[] színek;
        public void Színalmenük(ConsoleColor[] tömb)
        {
            színek = new string[tömb.Length + 1];
            színek[0] = "Alapértelmezett";
            for (int i = 1; i < színek.Length; i++)
            {
                színek[i] = Convert.ToString(tömb[i - 1]);
            }

        }
        private int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        private int szelesseg;
        public int Szelesseg
        {
            get { return szelesseg; }
            set { szelesseg = value; }
        }
        private int magassag;
        public int Magassag
        {
            get { return magassag; }
            set { magassag = value; }
        }
        string[] menük;
        public string[] Menük
        {
            get { return menük; }
            set { menük = value; }
        }
        int aktív;
        public int Aktív
        {
            get { return aktív; }
            set
            {
                if (value <= this.Menük.Count() && value >= 1)
                {
                    aktív = value;
                    this.Kirajzolás();
                }
                else
                {
                    if (value <= 0) Aktív = this.Menük.Count();
                    else Aktív = 1;
                }
            }
        }
        public int Aktívszín
        {
            get { return aktívszín; }
            set
            {
                if (value >= 0 && value < színek.Length)
                {
                    aktívszín = value;
                    this.Sortörlés();
                    this.Menük[2] = "Kígyó színe: <- " + színek[value] + " ->";
                    this.Kirajzolás();
                }
                else
                {
                    if (value < 0)
                    {
                        aktívszín = színek.Length - 1;
                        this.Sortörlés();
                        this.Menük[2] = "Kígyó színe: <- " + színek[színek.Length - 1] + " ->";
                        this.Kirajzolás();
                    }
                    else
                    {
                        aktívszín = 0;
                        this.Sortörlés();
                        this.Menük[2] = "Kígyó színe: <- " + színek[0] + " ->";
                        this.Kirajzolás();
                    }
                }

            }
        }
        public Menü(string[] menüpontok)
        {
            
            this.Menük = menüpontok;
            this.Szelesseg = this.Menük.Max(x => x.Length);
            this.Szelesseg += 4;
            this.Magassag = this.Menük.Length+2;
            this.X = 0;
            this.Y = 0;
            this.Aktívméret = 0;
            this.Aktív = 1;
            this.Kirajzolás();
            base.Méretezés();
        }
        private void Keret()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetWindowSize(this.Szelesseg+X, this.Magassag + 1+Y);
            Console.SetBufferSize(this.Szelesseg+X, this.Magassag + 1+Y);
            Console.SetCursorPosition(X, Y);
            Console.Write("╔{0}{1}", "═".PadLeft((this.Szelesseg - 2), '═'), "╗");
            for (int i = 0; i < this.Magassag - 2; i++)
            {
                Console.SetCursorPosition(X, Y+1+i);
                Console.Write("║");
                Console.SetCursorPosition(X+this.Szelesseg - 1, Y+1 + i);
                Console.Write("║");
            }
            Console.SetCursorPosition(X, Y+this.Magassag - 1);
            Console.Write("╚{0}{1}", "".PadLeft((this.Szelesseg - 2), '═'), "╝");
        }
        private void Menübeír()
        {
            for (int i = 1; i <= Menük.Length; i++)
            {
                if (i == Aktív) Console.BackgroundColor = ConsoleColor.Blue;
                else Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(X+1, Y+i);
                Console.Write(Menük[i-1]);
            }
        }
        public int Frissítés()
        {
            ConsoleKey ch;
            do
            {
                ch = Console.ReadKey(true).Key;
                if (ch == ConsoleKey.UpArrow) this.Aktív--;
                if (ch == ConsoleKey.DownArrow) this.Aktív++;
                if (ch == ConsoleKey.LeftArrow && Aktív == 2) Aktívméret--;
                if (ch == ConsoleKey.RightArrow && Aktív == 2) Aktívméret++;
                if (ch == ConsoleKey.LeftArrow && Aktív == 3) Aktívszín--;
                if (ch == ConsoleKey.RightArrow && Aktív == 3) Aktívszín++;
                if (ch == ConsoleKey.Enter && Aktív == 1) return this.Aktív;
                if (ch == ConsoleKey.Enter && Aktív == 4) return this.Aktív;
            } while (ch != ConsoleKey.Escape);
            return -1;
        }
        private void Sortörlés()
        {
            Console.SetCursorPosition(1, Aktív);
            Console.WriteLine("".PadLeft(Szelesseg-2));
        }
        private void Kirajzolás()
        {
            this.Menübeír();
            this.Keret();
        }
    }}
