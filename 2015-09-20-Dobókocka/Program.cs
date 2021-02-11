using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dodbókocka
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int szám = r.Next(2, 13);
            int sorozat12akt = 1,sorozat12 = 0;
            int sorozatakt = 1, sorozat = 0;
            int előző = szám;
            int db = szám == 10? 1 : 0;
            Console.Write("{0}",szám.ToString().PadLeft(3));
            for (int i = 1; i < 100; i++)
            {
                szám = r.Next(2, 13);
                Console.Write("{0}", szám.ToString().PadLeft(3));
                if ((i + 1) % 10 == 0) Console.WriteLine();
                if (szám == 12)
                {
                    db++;
                    if (szám == előző) sorozat12akt++;
                    else sorozat12akt = 1;
                }
                if (szám == előző) sorozatakt++;
                else sorozatakt = 1;
                if (sorozat12 < sorozat12akt) sorozat12 = sorozat12akt;
                if (sorozat < sorozatakt) sorozat = sorozatakt;
                előző = szám;
            }
            Console.WriteLine("Mind a két dobás 6-os volt: {0} alkalommal",db);
            Console.WriteLine("Leghosszabb 12-es sorozat : {0}",sorozat12);
            Console.WriteLine("Leghosszabb sorozat amikor a dobások értéke azonos volt: {0}",sorozat);
            Console.ReadKey();
        }
    }
}
