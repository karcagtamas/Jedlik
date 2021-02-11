using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adoszam
{
    class Program
    {
        static string adoazon(string szul)
        {
            string s = "8";
            //szul = szul.Remove(szul.Length - 1, 1);
            DateTime most = DateTime.Parse(szul);
            DateTime reg = DateTime.Parse("1867.01.01");
            //string k = most - reg;
            string k ="";
            int z = 0;
            if (k.Length < 6) z = 6 - k.Length;
            for (int i = 0; i < z; i++)
            {
                k.Insert(0, "0");
            }
            Random r = new Random();
            for (int i = 0; i < 3; i++)
            {
                s = s + r.Next(9).ToString();
            }
            s = s + k;
            return s;
        }
        static string tizedik(string s)
        {
            long x = 0;
            for (int i = 1; i < 10; i++)
            {
                x += Convert.ToInt64(s[i - 1]) + (long)i;
            }
            if (x % 11 == 10) return "-1";
            return (x % 2).ToString();
        }
        static void Main(string[] args)
        {
            Console.WriteLine(adoazon("2012.12.11"));
            Console.ReadKey();
        }
    }
}
