using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Keret
    {
        protected int x;
        public virtual int X
        {
            get { return x; }
            set { x = value; }
        }

        protected int y;
        public virtual int Y
        {
            get { return y; }
            set { y = value; }
        }

        protected int m;
        public virtual int M
        {
            get { return m; }
            set { m = value; }
        }

        protected int sz;
        public virtual int SZ
        {
            get { return sz; }
            set { sz = value; }
        }

        public Keret()
        { }

        public virtual void Rajzol()
        {
            Console.SetCursorPosition(this.x, this.y);
            for (int i = 0; i < this.m; i++)
            {
                Console.SetCursorPosition(this.x, this.y + i);
                if (i == 0 || i == this.m - 1)
                {
                    for (int j = 0; j < this.sz; j++)
                    {
                        bool feltétel = true;
                        if (i == 0 && j == 0)
                        {
                            Console.Write('┌');
                            feltétel = false;
                        }
                        if (i == 0 && j == this.sz - 1)
                        {
                            Console.WriteLine('┐');
                            feltétel = false;
                        }
                        if (i == this.m - 1 && j == 0)
                        {
                            Console.Write('└');
                            feltétel = false;
                        }
                        if (i == this.m - 1 && j == this.sz - 1)
                        {
                            Console.WriteLine('┘');
                            feltétel = false;
                        }
                        if (feltétel) Console.Write('─');
                    }
                }
                else
                {
                    Console.Write('│');
                    Console.WriteLine(('│').ToString().PadLeft(this.sz - 1));
                }
            }
        }

        protected void Töröl()
        {
            Console.Clear();
        }
    }
}
