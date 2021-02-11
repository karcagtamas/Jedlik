using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bináris_keresés
{
    class Program
    {
        static void Main(string[] args)
        {
            //c#-ban

            int[] m = new int[20];
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = i + 1;
            }
            int e = 0, v = m.Length - 1, k = 0;
            Console.Write("Add meg a keresett számot: ");
            int x = int.Parse(Console.ReadLine());
            do
            {
                k = ((v - e) / 2) + e;
                if (x < m[k]) v = k - 1;
                if (x > m[k]) e = k + 1;
            } while (e <= v && m[k] != x);
            Console.WriteLine(m[k] == x?"Található ilyen elem a tömben" : "Nem található ilyen elem a tömben");
            Console.ReadKey();

            //algoritmus szövegesen

            /*
             * Egy rendezett tömben keresünk egy megadott számot
             * Megnézzük a tömb közepét hogy a keresett szám kisebb vagy nagyobb nála
             * Majd megfelezzük a maradék lehetséges halmazt egészen addig míg meg nem találjuk a keresett számot vagy el nem fogynak a számok és nem találtunk semmit
             * Így csak két kimenet lehet - van vagy nincs 
             */

             //mondatszerű leírás

            /*
             * Program bináris keresés
             *      Változó: e,k,v,x,i:egész
             *      Változó tömb: m[0...19]:egész
             *      Ciklus i:= 0 tól t.Hossz-ig 1 lépésközzel
             *          m[i]:= i + 1
             *      Ciklus vége
             *      e:= 0
             *      v:= t.Hossz
             *      Be: x
             *      Ciklus
             *          k:= ((v - e) / 2) + e
             *          Ha m[k] > x akkor v:= k - 1
             *          Ha m[k] < x akkor e:= k + 1
             *      Ciklus amíg m[k] <> 0 ÉS e <= v
             *      Ha m[k] = x akkor Ki:"Található ilyen elem a tömben"
             *      különben Ki: "Nem található ilyen elem a tömben"
             * Program vége.
             */
        }
    }
}
//bináris keresés
//main függvénybe: 
//  keresd meg a bináris keresés algoritmusát az interneten
//  irjad le az algoritmus szövegesen
//  készítsed el az algoritmus folyamatábráját (jelölések: rendezett t vektor, input x, diagram desinger-rel)
//  készítsed el a mondatszerű leírását is
