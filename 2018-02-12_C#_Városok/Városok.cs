using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Városok
{
    class Város
    {
        public int Lakosság { get; set; }

        public double MLakosság { get => (double)Lakosság / 1000; set => Lakosság = (int)value; }
        public string Név { get; set; }
        public string Ország { get; set; }

        public Város(string sor)
        {
            string[] m = sor.Split(';');
            Név = m[0];
            Ország = m[1];
            Lakosság = int.Parse(m[2]);
        }
    }
    class Városok
    {
        static void Main()
        {
            // 2. feladat: adatok beolvasása
            List<Város> v = new List<Város>();
            foreach (var i in File.ReadAllLines("varosok.txt").Skip(1))
            { //.Skip(1) -> Első sor elhagyása
                v.Add(new Város(i));
            }

            Console.WriteLine($"3. feladat: Városok száma: {v.Count} db");

            // 4. feladat:
            int indiaFő = 0;
            foreach (var i in v)
            {
                if (i.Ország=="India")
                {
                    indiaFő += i.Lakosság * 1000;
                }
            }
            Console.WriteLine($"4. feladat: indiai nagyvárosok lakosságának összege: {indiaFő} fő");

            // Linq:
            Console.WriteLine($"4. feladat: indiai nagyvárosok lakosságának összege: {v.Where(x=>x.Ország=="India").Sum(x=>x.Lakosság)*1000} fő");

            // 5. Legnagyobb város adatai
            Console.WriteLine("5. feladat: A legnagyobb város adatai");
            int maxi = 0; // Legelső legyen a legnagyobb
            for (int i = 1; i < v.Count; i++)
            {
                if (v[i].Lakosság>v[maxi].Lakosság)
                {
                    maxi = i;
                }
            }
            Console.WriteLine($"\tNév: {v[maxi].Név}");
            Console.WriteLine($"\tOrszág: {v[maxi].Ország}");
            Console.WriteLine($"\tLakosság: {v[maxi].Lakosság} ezer fő");

            //Linq: 
            var legnagyobb = v.OrderByDescending(x => x.Lakosság).First();
            Console.WriteLine("5. feladat: A legnagyobb város adatai");
            Console.WriteLine($"\tNév: {legnagyobb.Név}");
            Console.WriteLine($"\tOrszág: {legnagyobb.Ország}");
            Console.WriteLine($"\tLakosság: {legnagyobb.Lakosság} ezer fő");

            // 6. Van-e magyar város?
            bool nincsMagyar = true;
            foreach (var i in v)
            {
                if (i.Ország=="Magyarország")
                {
                    nincsMagyar = false;
                    break;
                }
            }
            Console.WriteLine($"6. feladat: {(nincsMagyar?"Nincs":"Van")} magyar város az adatok között.");
            Console.WriteLine($"6. feladat: {(v.Exists(x=>x.Ország=="Magyarország") ? "Van" : "Nincs")} magyar város az adatok között.");

            // 7. Városok egy szóközzel
            int városDb = 0;
            foreach (var i in v)
            {
                //if (i.Név.Split().Length == 2)
                //    városDb++;
                // "Favágó" megoldás:
                int szóközDb = 0;
                foreach (var j in i.Név)
                {
                    if (j == ' ') szóközDb++;
                }
                if (szóközDb == 1) városDb++;
            }
            Console.WriteLine($"7 .feladat: Városok egy szóközzel: {városDb} db");
            Console.WriteLine($"7 .feladat: Városok egy szóközzel: {v.Count(x=>x.Név.Split().Length==2)} db");

            // Statisztika - Szótárral (Dictionary)
            Dictionary<string, int> stat = new Dictionary<string, int>();
            foreach (var i in v)
            {
                if (stat.ContainsKey(i.Ország))
                {
                    stat[i.Ország]++;
                } else
                {
                    stat.Add(i.Ország, 1);
                }
            }
            Console.WriteLine("8. feladat: Ország statisztika");
            foreach (var i in stat)
            {
                if (i.Value > 5)
                {
                    Console.WriteLine($"\t{i.Key} - {i.Value} db");
                }
            }
            
            // Linq:
            Console.WriteLine("8. feladat: Ország statisztika");
            Console.WriteLine(v.GroupBy(g=>g.Ország).Where(x=>x.Count()>5).Aggregate("",(c,n)=>c+$"\t{n.Key} - {n.Count()} db\n"));


            // Statisztika halmaz + szótár
            HashSet<string> h = new HashSet<string>();
            foreach (var i in v) h.Add(i.Ország);
            
            Dictionary<string, int> stat2 = new Dictionary<string, int>();
            foreach (var i in h) stat2.Add(i, 0);
            foreach (var i in v) stat2[i.Ország]++;
            Console.WriteLine("8. feladat: Ország statisztika");
            foreach (var i in stat2)
            {
                if (i.Value > 5)
                {
                    Console.WriteLine($"\t{i.Key} - {i.Value} db");
                }
            }

            Console.WriteLine("9. feladat: kina.txt");
            List<string> ki = new List<string>();
            foreach (var i in v)
            {
                if (i.Ország == "Kína")
                    ki.Add($"{i.Név};{i.Lakosság}");
            }
            File.WriteAllLines("kina.txt", ki);

            //Megoldás linq:
            File.WriteAllText("kina2.txt", v.Where(x => x.Ország == "Kína").Aggregate("",(c, n) => c + $"{n.Név}-{n.Lakosság}\r\n"));


            // 10. Feladat:
            // Orosz nagyvárosok közül melyik a legkisebb?

            Város V = v[68];

            foreach (var i in v)
            {
                if (i.Ország == "Oroszország" && i.Lakosság < V.Lakosság)
                {
                    V = i;
                }
            }

            Console.WriteLine("10. Feladat:");
            Console.WriteLine($"A legkisebb orosz város: {V.Név}");

            // 11. feladat:
            // Hány ország neve végződik "a" karakterre?

            int vdb = 0;
            foreach (var i in v)
            {
                if (i.Név.Last() == 'a') vdb++;
            }

            Console.WriteLine("11. feladat:");
            Console.WriteLine($"Városok száma, amik 'a'-ra végződnek: {vdb}");

            // 12. feladat:
            // Készíts valós típusú jellemzőt a Város osztályba,
            // ami a város lakosságát millió főben adja meg!



            // 13. feladat:
            // Döntsed el és írjad ki a képenyőre,
            // hogy az USA-ban van-e 6 milló
            // főnél népesebb város!

            bool f = true;

            for (int i = 0; i < v.Count && f; i++)
            {
                if (v[i].Ország == "USA" && v[i].MLakosság > 6)
                {
                    f = false;
                }
            }
            Console.WriteLine("12. feladat:");
            Console.Write("Van-e népesebb város az USA-ban 6 milliónál: ");
            Console.WriteLine(!f? "Van népesebb város" : "Nincs népesebb város");

            // 14. feladat:
            // varosook2.txt állomány létrehozása
            // adatok sorrendje fordított, pontosvessző
            // fejlécsor a mezőnevekkel legyen
            // Lakosság millió főben, két tizedesjegyre
            // kerekítve

            if (File.Exists("varosook2.txt")) File.Delete("varosook2.txt");
            List<string> l = new List<string>();
            l.Add("Lakosság;Ország;Város");
            foreach (var i in v)
            {
                l.Add(i.MLakosság + ";" + i.Ország + ";" + i.Név);
            }
            File.AppendAllLines("varosook2.txt", l);

            // 15. feladat:
            // Statisztika, képernyőre
            // Összetett adatszerkezet használata
            // 5 millió alatti
            // 5-10 közötti
            // 10 millió feletti városok száma
            int db1 = 0;
            int db2 = 0;

            foreach (var i in v)
            {
                if (i.MLakosság < 5) db1++;
                if (i.MLakosság > 10) db2++;
            }

            Console.WriteLine("15. feladat:");
            Console.WriteLine($"5 millió alatti országok: {db1}");
            Console.WriteLine($"5 millió és 10 millió közötti országok: {v.Count - db1 - db2}");
            Console.WriteLine($"10 millió feletti országok: {db2}");

            // 16. feladat:
            // Határozza meg és írja ki a képernyőre 
            // az európai nagyvárosok városok lakosságának átlagát

            string[] eu = File.ReadAllLines("europa12D.txt");
            int sum = 0;
            int count = 0;

            foreach (var i in v)
            {
                if (eu.Contains(i.Ország))
                {
                    sum += i.Lakosság;
                    count++;
                }
            }
            Console.WriteLine("16. feladat:");
            Console.WriteLine($"Európai országok lakosságának átlaga: { sum / (double)count}");

            Console.ReadKey();
        }
    }
}
