using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Csemege : Játék
    {
        Random nr = new Random();
        public int X1
        {
            get { return csemegex; }
            set { csemegex = value; }
        }
        public int Y1
        {
            get { return csemegey; }
            set { csemegey = value; }
        }
        private void Rajzol()
        {
            Console.SetCursorPosition(X1, Y1);
            Console.WriteLine("*");
        }
        
        public Csemege()
        {
            Console.SetCursorPosition(X1, Y1);
            Console.WriteLine(" ");
            do
            {
                X1 = nr.Next(0, Console.WindowWidth);
                Y1 = nr.Next(0, Console.WindowHeight);
            } while (pontok.Contains(new Pont(X1,Y1)));
            Rajzol();
        }
    }
}
