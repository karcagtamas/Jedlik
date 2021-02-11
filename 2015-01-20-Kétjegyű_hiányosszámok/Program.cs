using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kérjegyű_hiányoszám
{
    class Program
    {
        static bool hiányos(ulong x)
        {
            ulong összeg = 0;
            for (ulong osztó = 1; osztó <= x/2; osztó++)
            {
                if (x % osztó == 0)
                    összeg = összeg + osztó;
            }
            if (összeg < x)
                return true;
                return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("A számelméletben hiányos számnak nevezünk minden olyan egészt, amelyek nagyobbak osztóik összegénél (önmagukat nem számítva)");
            Console.WriteLine("Az összes kétjegyű hiányosszám!!!");
            ulong db = 1;
            ulong vszám = 10;
            do
	        {
                if (hiányos(vszám))
                {
                    Console.WriteLine("{0}.:{1}",db, vszám);
                    db = db + 1;
                }
                vszám = vszám + 1;
	        } while (vszám <= 99);
            Console.ReadKey();
        }
    }
}
