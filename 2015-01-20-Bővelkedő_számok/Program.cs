using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bövelkedőszámok
{
    class Program
    {
        static bool bövelkedő(ulong x)
        {
            ulong összeg = 0;
            for (ulong osztó = 1; osztó <= x/2; osztó++)
            {
                if (x % osztó == 0)
                    összeg = összeg + osztó;
            }
            if (összeg > x)
            return true;
            return false; 
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Az első bövelkedő szám!!!");
            ulong db = 1;
            ulong vszám = 0;
            do
            {
                if (bövelkedő(vszám))
                {
                    Console.WriteLine("{0}.:{1}", db, vszám);
                    db++;
                }
                vszám++;
            } while (db<4);
            Console.ReadKey();
        }
    }
}
