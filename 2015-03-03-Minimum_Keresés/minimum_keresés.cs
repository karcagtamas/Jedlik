using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// KÉszíts új projektet a maximum algoritmussal
// Módosítjuk a minimum keresés projektet úgy hogy a legkisebb elem (elemek sorát) más színnel jelöljük
namespace minimum_keresés
{
    class minimum_keresés
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Minimum keresés!");
            Console.WriteLine("t[] vektor feltöltéshe véletlenszerű kétjegyű számokkal!");
            byte[] t = new byte[10];
            Random r = new Random();
            for (int i = 0; i < t.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                t[i] = (byte)r.Next(10, 100);
                Console.WriteLine("t[{0}]={1}",i,t[i]);
            }
            int mini = 0;
            for (int i = 1; i < t.Length; i++)
            {
                // t[i] < t[mini] esetén a legelső legkisebb elemet találja meg
                // t[i] <= t[mini] esteén a legutolsó legkisebb elemet találja meg
                if (t[i] < t[mini])
                {
                    mini = i;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("A legkisebb szám:t[{0}]={1}", mini, t[mini]);
            Console.ReadKey();
        }
    }
}
