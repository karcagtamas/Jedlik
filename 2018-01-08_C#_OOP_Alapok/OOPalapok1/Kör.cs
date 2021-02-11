using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPalapok
{
    class Kör : Pont
    {
        //Mezők
        int R;

        public int Sugár
        {
            get { return R; }
            set
            {
                if (value >= 5) R = value;
                else throw new Exception("A sugár nem lehet 5-nél kisebb!");
            }
        }

        public Kör(int ssz, int x, int y, string szín, int r)
            :base(ssz,x,y,szín)
        {
            Sugár = r;
        }
        
        //a virtuális metódusokat az override foglalt 
        //szóval kell felüldefiniálni
        override public void Rajzol()
        {
            switch (Szín.ToLower())
            {
                case "piros":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "kék":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "zöld":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "fehér":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.SetCursorPosition(Px, Py);
            Console.Write("K");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
