using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Egyszámjáték_Linq
{
    class Játékos
    {
        public string Név { get; private set; }
        public List<int> Tippek { get; private set; }

        public Játékos(string[] m)
        {
            Név = m[0];
            Tippek = new List<int>();
            foreach (var i in m.Skip(1)) Tippek.Add(int.Parse(i));
        }
    }
    class Egyszámjáték_Linq
    {
        static void Main()
        {
            List<Játékos> t = new List<Játékos>();
            foreach (var i in File.ReadAllLines("egyszamjatek.txt"))
            {
                t.Add(new Játékos(i.Split()));
            }

            Console.WriteLine($"3. feladat: Játékosok száma: {t.Count}");

            Console.WriteLine($"4. feladat: Fordulók száma: {t[0].Tippek.Count}");

            Console.WriteLine($"5. feladat: Az első fordulóban {(t.Count(i => i.Tippek[0] == 1) > 0 ? "" : "nem " )}volt egyes tipp!");

            Console.WriteLine($"6. feladat: A legnagyobb tipp a fordulók során: {t.Max(i => i.Tippek.Max())}");

            Console.Write($"7. feladat: Kérem a forduló sorszámát [1 -{t[0].Tippek.Count}]: ");
            int fordnum = int.Parse((Console.ReadLine()));
            if (fordnum < 1 || fordnum > t[0].Tippek.Count) fordnum = 1;

            var egyeditippek = t.GroupBy(g => g.Tippek[fordnum - 1]).Where(i => i.Count() == 1).OrderBy(i => i.Key);
            if (egyeditippek.Count() > 0) Console.WriteLine($"8. feladat: A nyertes tipp a megadott fordulóban: {egyeditippek.First().Key}");
            else Console.WriteLine($"8. feladat: Nem volt egyedi tipp a megadott fordulóban!");

            string fordulonyertese = "";
            if (egyeditippek.Count() > 0)
            {
                fordulonyertese = t.Where(i => i.Tippek[fordnum - 1] == egyeditippek.First().Key).First().Név;
                Console.WriteLine($"9. feladat: A megadott forduló nyertese: {fordulonyertese}");
            }
            else Console.WriteLine($"9. feladat: Nem volt nyerte a megadott fordulóban!");

            if (egyeditippek.Count() > 0)
            {
                List<string> ki = new List<string>();
                ki.Add($"Forduló sorszáma: {fordnum}");
                ki.Add($"Nyertes tipp: {egyeditippek.First().Key}");
                ki.Add($"Forduló sorszáma: {fordulonyertese}");
                File.WriteAllLines("nyertes.txt", ki);
            }

            Console.ReadKey();


        }
    }
}
