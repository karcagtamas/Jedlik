using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_v3
{
    class Menu
    {
        private List<string> ListItems;
        int active = 0;
        private int x;
        private int y;
        private int h;
        private int w;
        public int Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int H { get => h; set => h = value; }
        public int W { get => w; set => w = value; }

        public Menu(int x, int y, List<string> list)
        {
            this.Clear();
            this.X = x;
            this.Y = y;
            ListItems = list;
            H = ListItems.Count + 2;
            W = 0;
            foreach (var i in ListItems)
            {
                if (i.Length > W) W = i.Length;
            }
            W += 2;
            Border();
            Draw();
        }
        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int db = 0;
            foreach (var i in ListItems)
            {
                if (Active == db) Console.BackgroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(this.X + 1, this.Y + 1 + db);
                Console.Write(i);
                Console.BackgroundColor = ConsoleColor.Black;
                db++;
            }

        }
        public void Border()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write('┌');
            for (int i = 0; i < W - 2; i++)
            {
                Console.Write('─');
            }
            Console.WriteLine('┐');
            for (int i = 1; i <= H - 2; i++)
            {
                Console.SetCursorPosition(this.X, this.Y + i);
                Console.Write('│');
                Console.SetCursorPosition(this.X + W - 1, this.Y + i);
                Console.Write('│');
            }
            Console.SetCursorPosition(this.X, this.Y + H - 1);
            Console.Write('└');
            for (int i = 0; i < W - 2; i++)
            {
                Console.Write('─');
            }
            Console.Write('┘');
        }
        public void Clear()
        {
            Console.Clear();
        }
        public int Update()
        {
            ConsoleKey ck;
            do
            {
                ck = Console.ReadKey(true).Key;
                if (ck == ConsoleKey.UpArrow) if (this.Active > 0) this.Active--; else this.Active = this.ListItems.Count - 1;
                if (ck == ConsoleKey.DownArrow) if (this.Active < this.ListItems.Count - 1) this.Active++; else this.Active = 0;
                if (ck == ConsoleKey.Enter) return this.Active;
                this.Draw();
            } while (ck != ConsoleKey.Escape);
            return -1;
        }
    }
}
