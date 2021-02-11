using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dátumos
{
    class Program
    {
        //enum Hónapok { január, februrár, március, április, május, június, július, augusztus, szeptember, október, november, decemeber }
        static void szétválasztás(ref int nap, ref int hónap, ref int év, string[] m, string[] hónapok)
        {
            for (int i = 0; i < m.Length; i++)
            {
                if (i % 2 == 0)
                {
                    m[i] = m[i].Trim('.');
                    if (i == 0) év = int.Parse(m[i]);
                    else nap = int.Parse(m[i]);
                }
                else
                {
                    //Hónapok hn = (Hónapok)Enum.Parse(typeof(Hónapok), "FebruÁr", true);
                    //hónap = (int)hn + 1;
                    int index = 0;
                    do
                    {
                        if (m[i] == hónapok[index]) hónap = index + 1;
                        index++;
                    } while (hónap == 0 && index < hónapok.Length);
                }
            }
        }
        static void újdátum(ref int nap, ref int hónap, ref int év, string[] hónapok, int[] t)
        {
            do
            {
                if (év % 4 == 0) t[1] = 29;
                else t[1] = 28;
                if (nap > t[hónap - 1])
                {
                    nap -= t[hónap - 1];
                    hónap++;
                    if (hónap == hónapok.Length + 1)
                    {
                        hónap = 1;
                        év++;
                    }
                }
            } while (nap > t[hónap - 1]);
        }
        static string[] bekérésstring()
        {
            Console.Write("Kérek egy dátumot(év. hónap nap.):");
            string dátum = Console.ReadLine();
            string[] m = dátum.Split(' ');
            return m;
        }
        static int bekérésint()
        {
            Console.Write("Kérem addja meg a napok számát:");
            int x = int.Parse(Console.ReadLine());
            return x;
        }
        static void kiir(int nap, int hónap, int év, string[] hónapok, int x)
        {
            if(x == 0) Console.WriteLine("{0}. {1}. {2}.", év, hónap, nap);
            else Console.WriteLine("{0}. {1} {2}.", év, hónapok[hónap - 1], nap);
        }
        static void Main(string[] args)
        {
            string[] Hónapok = { "január", "február", "március", "április", "május", "június", "július", "augusztus", "szeptember", "október", "november", "decemeber" };
            int[] t = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] m = bekérésstring();
            int nap = 0,hónap = 0, év = 0;
            szétválasztás(ref nap, ref hónap, ref év, m, Hónapok);
            kiir(nap, hónap, év, Hónapok, 0);
            int napokszáma = bekérésint();
            nap += napokszáma;
            újdátum(ref nap, ref hónap, ref év, Hónapok, t);
            kiir(nap, hónap, év, Hónapok, 1);
            Console.ReadKey();
        }
    }
}
//1. string típusú változóba kérje be egy dátumot.
//formátum: "2015. december 3."
//2. év, hónap, nap változó feltöltése (lehet int típus)
//a hónap kódolásának felsorolt típust kell használni
//év -> 2015
//hónap -> 12
//nap -> 3
//3. kérj be "egy napok száma" értéket pl: 40
//4. irjad ki hogy az eredeti dátumhoz hozzá adjuk a "napok száma" változót, akkor milyen dátumot kapunk (felsorolt típus használni)
//formátum: "2016. január 12."
//ellenörzés excelben

//új házi:
//4 függvény
//
//