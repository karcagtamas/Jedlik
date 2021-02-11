using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gazdaság
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("terulet.txt",Encoding.UTF8);
            List<List<char>> me = new List<List<char>>();
            int L = 0;
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                List<char> ls = new List<char>();
                for (int i = 0; i < s.Length; i++)
                {
                    ls.Add(s[i]);
                    if (s[i] == 'L') L++;
                }
                me.Add(ls);
            }

            Console.WriteLine("2. feladat:");
            Console.WriteLine("{0}m x {1}m, területe: {2}ha", me[0].Count * 100, me.Count * 100, (me[0].Count * 100) * (me.Count * 100) / 10000);
            Console.WriteLine("3. feladat:");
            Console.WriteLine("{0:##.##}%", (double)L / (me[0].Count * me.Count) * 100);
            Console.WriteLine("4. feladat:");
            bool feltétel = false;
            int k = 1;
            for (k = 0; k < me.Count; k++)
            {
                for (int j = 0; j < me[0].Count; j++)
                {
                    if (me[k][j] == 'L') { feltétel = true; break; }
                }
                if (feltétel) break;
            }
            Console.WriteLine("{0}m",k * 100);
            Console.WriteLine("5. feladat:");
            int lhossz = 0;
            int lhosszmax = 0;
            int db = 0;
            int maxt = 0;
            for (int i = 0; i < me.Count; i++)
            {
                for (int j = 0; j < me[0].Count; j++)
                {
                    if (me[i][j] == 'L') lhossz++;
                    else 
                    {
                        if (lhossz > lhosszmax) lhosszmax = lhossz;
                        lhossz = 0;
                    }
                    if (me[i][j] == 'L' && me[i - 1][j] == 'M' && me[i][j-1] == 'M')
                    {
                        int y = i;
                        int x = j;
                        int sz = 0;
                        int m = 0;
                        for (int g = y; g < me.Count; g++)
                        {
                            if (me[g][x] == 'L') m++;
                            else break;
                        }
                        for (int g = x; g < me[0].Count; g++)
                        {
                            if (me[y][g] == 'L') sz++;
                            else break;
                        }
                        db++;
                        if (maxt < (sz * 100) * (m * 100)) maxt = (sz * 100) * (m * 100);
                    }
                }
            }
            Console.WriteLine("{0}m",lhosszmax * 100);
            Console.WriteLine("6. feladat:");
            Console.WriteLine("{0}db",db);
            Console.WriteLine("7. feladat:");
            Console.WriteLine("{0}ha",maxt / 10000);
            Console.ReadKey();

        }
    }
}
