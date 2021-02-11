using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPalapok
{
    //Ős osztály: Object (implicit ős)
    class Pont
    {
        //Tag típusok:
        //Adattagok: mezők, indexerek
        //Kódtagok: metódusok, konstruktorok
        //Adattag+kódtag: jellemzők

        //Protected mezők
        protected int Ssz;
        protected int Px;
        protected int Py;
        protected string Szín;

        //Jellemző
        public int Sorszám
        {
            get { return Ssz; }
            set
            {
                if (value >= 1) Ssz = value;
                else throw new Exception("A sorszám nem lehet negatív!");
            }
        }

        //Konstruktor(ok)
        //Speciáls metódus
        //Szerepe: osztálypéldány (objektum) inicializálása
        public Pont(int ssz, int x, int y, string szín)
        {
            Sorszám = ssz;
            Px = x;
            Py = y;
            Szín = szín;
        }

        //Metódus
        //Virtuális metódusok alkalmazásával
        //valósul meg teljes mértékben a zártság tulajdonság
        //(saját metódus elsőbbséget élvez az örökölt metódussal szemben)
        virtual public void Rajzol()
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
            Console.Write("P");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public double Távolság(Pont másik)
        {
            int deltaX = másik.Px - this.Px;
            int deltaY = másik.Py - this.Py;
            return Math.Sqrt(Math.Pow(deltaX,2)+ Math.Pow(deltaY, 2));
        }
    }
}
