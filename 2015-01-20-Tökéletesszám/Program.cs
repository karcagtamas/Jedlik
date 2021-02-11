using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tökéletesszám
{
    class Program
    {
        static bool Tökéletes(ulong x)
        {
            ulong összeg = 0;
            for (ulong osztó = 1; osztó <= x / 2; osztó++)
            {
                if (x % osztó == 0)
                    összeg = összeg + osztó;
            }
            if (összeg == x)
                return true;
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Tökéletes számok");
            ulong db = 1;
            ulong vszám = 1;
            DateTime Start = DateTime.Now;
            do
            {
                if (Tökéletes(vszám))
                {
                    Console.WriteLine("{0}.:{1}", db, vszám);
                    db++;
                }
                vszám++;
            } while (db < 6);
            DateTime Stop = DateTime.Now;
            Console.WriteLine("{0}",Stop - Start);
        }
    }
}
