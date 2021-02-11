using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eldöntés_for_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            char[] t = new char[10];
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = (char)r.Next(65, 91);
                Console.WriteLine("t[{0}]={1}",i,t[i]);
            }
            string magánhangzók = "AEIUO";
            int j = 0;
            for (; j < t.Length; j++)
            {
                if (magánhangzók.Contains(t[j])) break;
            }
            if (j < t.Length) Console.WriteLine("Van benne magánhangzó!");
            else Console.WriteLine("Nincs benne magánhangzó!");
            Console.ReadKey();
        }
    }
}
