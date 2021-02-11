using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maximum_számítás
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] t = new byte[10];
            Random r = new Random();
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = (byte)r.Next(10, 100);
                Console.WriteLine("t[{0}]={1}",i,t[i]);
            }
            int max = 0;
            for (int i = 1; i < t.Length; i++)
            {
                if (t[i] > t[max])
                {
                    max = i;
                }
            }
            Console.WriteLine("A legnagyobb szám: t[{0}]={1}",max,t[max]);
            Console.ReadKey();
        }
    }
}
