using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karcag_Tamás
{
    class Program
    {
        static void hegylánc (int[] t)
        {
            int db = 0;
            int összeg = 0;
            int legnagyobb = 0,legkisebb = 16,középső = 0;
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] != 0) db++;
                else db = 0;
                if (db == 3 && t[i + 1] == 0)
                {
                    for (int j = i-2; j <= i; j++)
                    {
                        if (j == i -2) összeg = 3 * j + 3;
                        if (legnagyobb < t[j]) legnagyobb = j;
                        if (legkisebb > t[j]) legkisebb = j;
                    }
                    középső = összeg - (legnagyobb + legkisebb);
                    int legnagyobbé = t[legkisebb], legkisebbé = t[legkisebb], középsőé = t[középső];
                    t[i - 2] = középsőé;
                    t[i - 1] = legnagyobbé;
                    t[i] = legkisebbé;
                }
            }
        }
        static void Main(string[] args)
        {
            int[] t = new int[80];
            Random r = new Random();
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = r.Next(1, 16);
            }
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] % 2 == 0) t[i] = 0;
            }
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = 0;
                if (i == 3) i = t.Length - 3;
            }
            hegylánc(t);
            int db = 0;
            bool szin = false;
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] != 0) db++;
                else db = 0;
                if (db == 3 && t[i + 1] == 0)
                {
                    Console.Write("\b\b\b\b");
                    
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (t[i] < 10)
                        {
                            Console.Write("{0},", t[i]);
                        }
                        if (t[i - 1] < 10)
                        {
                            Console.Write("{0},", t[i - 1]);
                        }
                        if (t[i - 2] < 10)
                        {
                            Console.Write("{0},", t[i - 2]);
                        }
                        switch (t[i])
                        {
                            case 11: Console.Write("B,"); break;
                            case 13: Console.Write("D,"); break;
                            case 15: Console.Write("F,"); break;
                        }
                        switch (t[i - 1])
                        {
                            case 11: Console.Write("B,"); break;
                            case 13: Console.Write("D,"); break;
                            case 15: Console.Write("F,"); break;
                        }
                        switch (t[i - 2])
                        {
                            case 11: Console.Write("B,"); break;
                            case 13: Console.Write("D,"); break;
                            case 15: Console.Write("F,"); break;
                        }
                    szin = true;
                }
                if (!szin)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (t[i] < 10) Console.Write("{0},", t[i]);
                    switch (t[i])
                    {
                        case 11: Console.Write("B,"); break;
                        case 13: Console.Write("D,"); break;
                        case 15: Console.Write("F,"); break;
                    }
                }
                szin = false;

            }
            Console.WriteLine("\b");
            db = 0;
            int hossz = 0;
            int max = 1;
            bool elözö = false;
            for (int i = 0; i < t.Length; i++)
            {
                    if (t[i] != 0)
                    {
                        if (t[i - 1] == 0 && t[i + 1] == 0)db++;
                        if (t[i - 1] == 0 && t[i + 1] != 0) db++;
                        elözö = true;
                    }
                    if (elözö) hossz++;
                    if (t[i] == 0)
                    {
                        elözö = false;
                        if (max <= hossz) max = hossz;
                        hossz = 0;
                    }
                    elözö = false;
            }
            Console.WriteLine("hegyek száma: {0}",db);
            Console.WriteLine("Leghosszabb hegylánc: {0}",max);
            Console.ReadKey();
        }
    }
}
