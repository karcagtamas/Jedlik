using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armstrong
{
    class Program
    {
        static bool IsArmstrong(uint szám)
        {
            string számS = szám.ToString();
            uint öszeg = 0;
            int hoszz = számS.Length;
            for (int i = 0; i < hoszz; i++)
            {
                //uint jegy = uint.Parse(számS[i].ToString());
                uint jegy = (uint)számS[i] - 48;
                öszeg += (uint)Math.Pow(jegy, hoszz);
            }
            return öszeg == szám;
            //IsArmstrong = öszeg;
        }
        //static bool IsArmstrongII(uint szám)
        //{
            //uint s = szám;
            //uint db = 0;
            //double összeg = 0;
            //int hossz = szám.ToString().Length;
            //do
            //{
                //uint jegy = s % 10;
                //összeg += Math.Pow(jegy, hossz);
                //jegy = s / 10;
                //db++;
            //} while (db != 0);
            //return összeg == szám;
        //}
        static void Main(string[] args)
        {
            uint db3 = 0;
            for (uint c = 0; c < int.MaxValue; c++)
            {
                if (IsArmstrong(c))
                {
                    db3++;
                    Console.WriteLine("{0}.  {1}", db3 ,c);
                }
            }
            Console.ReadKey();
            for (int i = 100; i <= 999; i++)
            {
                int egyes = i % 10;
                int tizes = (i / 10) % 10;
                int százas = i / 100;
                int összeg = egyes * egyes * egyes + tizes * tizes * tizes + százas * százas * százas;
                if (összeg == i)
                {
                    Console.Write("egyes számjegy:{0}     ", egyes);
                    Console.Write("tizes számjegy:{0}     ", tizes);
                    Console.Write("százas számjegy:{0}     ", százas);
                    Console.WriteLine("maga a szám:{0}     ", összeg);
                }
            }
            Console.ReadKey();
            int db = 0;
            int db2 = 0;
            int összeg2 = 0;
            for (int k = 0; k < int.MaxValue; k++)
            {
                Console.Write("{0} ",k);
                db++;
                if (db == 10)
                {
                    Console.WriteLine("");
                    db = 0;
                }
                db2++;
                összeg2 = k;
            }
            Console.WriteLine("Az utolsó szám:{0}",összeg2);
            Console.WriteLine("Ennyi szám van",db2);
            Console.ReadKey();

        }
    }
}
