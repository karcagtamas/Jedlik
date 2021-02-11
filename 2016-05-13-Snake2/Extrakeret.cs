using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class ExtraKeret : Keret
    {
        public ExtraKeret()
        {

        }

        public override void Rajzol()
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
    }
}
