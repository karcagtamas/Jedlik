using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eldöntés_for_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] t = new int[10];
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = r.Next(-2, 15);
                Console.WriteLine("t[{0}]={1}",i,t[i]);
            }
            bool nincs = true;
            for (int i = 0; i < t.Length && nincs; i++)
            {
                if (t[i] < 0) nincs = false;
            }
            if (nincs) Console.WriteLine("Nincs benne negatív szám!");
            else Console.WriteLine("Van benne negatív szám!");
            Console.WriteLine("{0} negatív szám a vektorban!",nincs?"Nincs":"Van");
            Console.ReadKey();
        }
    }
}
