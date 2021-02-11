using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class SzivárványKigyó : Szuperkigyó
    {
        // public Szuperkigyó(Kigyó k):base (k)
        //{
        //    this.Gombok();
        //}
        public SzivárványKigyó(Szuperkigyó k): base(k)
        {
            this.Gombok();
        }
        protected override void Rajz()
        {
            foreach (Adatok i in this.l)
            {
                Console.ForegroundColor = i.C;
                Console.SetCursorPosition(i.X, i.Y);
                Console.Write(i.Ch);
            }
            this.karakter(0);
        }
        protected override void Rajzol()
        {
            Console.SetCursorPosition(this.l[0].X, this.l[0].Y);
            Console.WriteLine(" ");
            this.Bevitel();
            Console.ForegroundColor = this.l[this.l.Count - 2].C;
            Console.SetCursorPosition(this.l[this.l.Count - 2].X, this.l[this.l.Count - 2].Y);
            Console.Write(this.l[this.l.Count - 2].Ch);
            Console.ForegroundColor = this.l[this.l.Count - 1].C;
            Console.SetCursorPosition(this.l[this.l.Count - 1].X, this.l[this.l.Count - 1].Y);
            Console.Write(this.l[this.l.Count - 1].Ch);
        }
    }
}
