using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace first
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
            Console.Clear();
            Random r = new Random();
            int[,] m = new int[10, 10];
            int átlagösszeg = 0; 
            int összeg = 0;
            int max = 0;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    int x = r.Next(100);
                    m[i, j] = x;
                    összeg += x;
                    átlagösszeg += x;
                    if (m[i, j] > max) max = m[i, j];
                }
                összeg = 0;
            }
            int számláló = 1;
            double különbség = 100;
            double átlag = (double)átlagösszeg / m.Length;
            int közelebbi = 0;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    double y = Math.Abs(átlag - m[i,j]);
                    if (különbség > y && y >= 0) 
                    { 
                        különbség = y;
                        közelebbi = m[i, j];
                    }
                }
            }
            foreach (var i in m)
            {
                if (i == max) Console.ForegroundColor = ConsoleColor.Green;
                if (közelebbi == i) Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("{0,4}", i);
                összeg += i;
                if (számláló % 10 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" {0}",összeg);
                    összeg = 0;
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                számláló++;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    összeg += m[j, i];
                }
                Console.Write("{0,4}", összeg);
                összeg = 0;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("{0:#.##}", átlag);
            Console.ReadKey();
            //Console.WriteLine();
            //Console.Write("".PadLeft(3));
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.Write("{0,3}",i + 1);
            //}
            //Console.WriteLine();
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.Write("{0,3}",i + 1);
            //    for (int j = 0; j < 10; j++)
            //    {
            //        if ((i + 1) % (j + 1) == 0) Console.Write("{0,3}",'X');
            //        else Console.Write("{0,3}","");
            //    }
            //    Console.WriteLine();
            //}
            Thread.Sleep(500);
            }

            //string név = Console.ReadLine();
            //Console.WriteLine(név);
            //Console.WriteLine(név.PadLeft(80));
            ////Console.SetCursorPosition(60,0)
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write("".PadLeft(i));
            //    Console.WriteLine(név);
            //}
            //Console.WriteLine();
            //for (int i = 0; i < név.Length; i++)
            //{
            //    if (i == név.LastIndexOf(' ')) Console.ForegroundColor = ConsoleColor.Green;
            //    Console.Write(név[i]); 
            //    if (név[i] == név[név.Length - 1]) Console.ForegroundColor = ConsoleColor.Gray;
            //}
            Console.ReadKey();
        }
    }
}
