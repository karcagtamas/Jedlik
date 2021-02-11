using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amöba
{
    class Program
    {
        static int belső_vizsgálat(char[,] m, int érték,int j, int i)
        {
            int db = 0;
            switch (j)
            {
                case 0: if (m[i, j] + m[i, j + 1] + m[i, j + 2] == érték) db++; break;
                case 1: if (m[i, j] + m[i, j + 1] + m[i, j - 1] == érték) db++; break;
                case 2: if (m[i, j] + m[i, j - 1] + m[i, j - 2] == érték) db++; break;
            }
            switch (i)
            {
                case 0: if (m[i, j] + m[i + 1, j] + m[i + 2, j] == érték) db++; break;
                case 1: if (m[i, j] + m[i + 1, j] + m[i - 1, j] == érték) db++; break;
                case 2: if (m[i, j] + m[i - 1, j] + m[i - 2, j] == érték) db++; break;
            }
            if(m[0, 0] + m[1, 1] + m[2, 2] == érték) db++;
            if (m[1, 1] + m[0, 2] + m[2, 0] == érték) db++;
            return db;
        }
        static void Main(string[] args)
        {
            int értékx = 360;
            int értéko = 333;
            int dbx = 0;
            int dbo = 0;
            char[,] m = new char[3, 3];
            Random r = new Random();
            int x = r.Next(3);
            int y = r.Next(3);
            char akt = r.Next(2) == 0 ? 'x' : 'o';
            m[x, y] = akt;
            int db = 1;
            do
            {
                x = r.Next(3);
                y = r.Next(3);

                if (m[x, y] == '\0')
                {
                    akt = akt == 'x' ? 'o' : 'x';
                    m[x, y] = akt;
                    db++;
                    dbx = belső_vizsgálat(m, értékx, y, x);
                    dbo = belső_vizsgálat(m, értéko, y, x);
                    if (dbx >= 1 || dbo >= 1) break;
                }
            } while (db < 9);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (m[i, j] == 'x') Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    if (m[i, j] == 'o') Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(m[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (dbx == 0 && dbo == 0) Console.WriteLine("Döntetlen!");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            if (dbx == 1 && dbo == 0) Console.WriteLine("X játékos nyert!");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            if (dbx == 0 && dbo == 1) Console.WriteLine("O játékos nyert!");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (dbx == 2 && dbo == 0) Console.WriteLine("X Double win!");
            if (dbx == 0 && dbo == 2) Console.WriteLine("O Double win!");
            Console.ReadKey();
        }
    }
}
//222, 231, 240
//231 = x + o
//222 = o + o
//240 = x + x
//360 = x + x + x
//333 = o + o + o