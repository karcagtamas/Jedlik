using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    
    class Csemege
    {
        Random r = new Random();
        int x;
        int y;
        public int X
        {
            get { return this.x; }
            set { if (value != 20) this.x = value; }
        }
        public int Y
        {
            get { return this.y; }
            set { if (value != 12) this.y = value; }
        }
        
        public void Letesz()
        {
            this.x = r.Next(2, Console.WindowWidth - 1);
            this.y = r.Next(2, Console.WindowHeight - 1);
            Console.SetCursorPosition(X, Y);
            Console.Write('■');
        }        
    }
}
