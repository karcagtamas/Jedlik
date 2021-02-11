using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPalapok
{
    class Program
    {
        static void Main(string[] args)
        {
            //Saját osztály példányosítása
            //Pont myPont = new Pont(1, 119, 4, "Piros");
            //myPont.Sorszám = 3;
            //myPont.Rajzol();
            //Pont myPont2 = new Pont(1, 10, 10, "KéK");
            //myPont2.Rajzol();
            //Console.WriteLine();
            //Console.WriteLine("Két pont távolsága: {0}",myPont.Távolság(myPont2));

            //List<Pont> myList = new List<Pont>();
            //myList.Add(new Pont(1, 5, 5, "Piros"));
            //myList.Add(new Pont(2, 2, 5, "Zöld"));
            //myList.Add(new Kör(3, 7, 8, "Kék", 10));

            //foreach (var i in myList)
            //{
            //    i.Rajzol();
            //}


            Random r = new Random();
            string[] s = new string[] { "zöld", "kék", "piros", "fehér" };
            List<Pont> myList = new List<Pont>();

            for (int i = 1; i < 500; i++)
            {
                int ssz = i;
                int x = r.Next(0, 120);
                int y = r.Next(0, 30);
                string szín = s[r.Next(0, 4)];
                if (r.Next(2)==0)
                {//0 -> pont
                    myList.Add(new Pont(ssz, x, y, szín));
                } 
                else
                { //1 -> kör
                    int sugár = r.Next(5, 21);
                    myList.Add(new Kör(ssz, x, y, szín, sugár));
                }
            }

            foreach (var i in myList)
            {
                i.Rajzol();
            }

            Console.ReadKey();
        }
    }
}
