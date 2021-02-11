using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faktoriális_rekurziv
{
    class Program
    {
        static long ifactor(long n)
        {
            if (n >= 0 && n <= 1) return n;
            if (n < 0 || n > 20) return -1;
            long factor = 1;
            for (long i = 2; i <= n; i++) factor *= i;
            return factor;
        }
        static long rfactor(long n)
        {
            if (n >= 0 && n <= 1) return n;
            if (n < 0 || n > 20) return -1;
            return n * rfactor(n - 1);
        }
        static long rfactor2(long n)
        {
            if (n >= 0 && n <= 1) return n;
            if (n < 0) return -1;
            try
            {
                checked
                {
                    return n * rfactor2(n - 1);
                }
            }
            catch (Exception)
            {
                
                return - 1;
            }
        }
        //önrekurziórol beszélünk ha egy függvény önmagát hivja meg
        static void Main(string[] args)
        {
            Console.WriteLine(rfactor(20));
            Console.WriteLine(ifactor(20));
            Console.WriteLine(rfactor2(20));
            Console.ReadKey();
        }
    }
}
