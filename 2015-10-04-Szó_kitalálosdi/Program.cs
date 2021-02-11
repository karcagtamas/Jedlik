using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szó_kitalálosdi
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] szavak = {"alma","körte","barack","dobókocka","számitógép","kecske","attila","nits","program","máté","billenytüzet","nyár","egyetem","nemtudommilyenszó","pillangó","lepkhe","butha","kurfa","nitslaci","terminátor","cisco","mikrotik","ds"};
            Random r = new Random();
            string szó = szavak[r.Next(0, szavak.Length - 1)];
            char[] betűk = szó.ToCharArray();
            char[] betűcopy = new char[betűk.Length];
            char érték = 'a';
            string megoldás = "A";
            bool feltétel = true,volte = false, jóe = true,megoldásf = true;
            int db = 0;
            for (int i = 0; i < betűcopy.Length; i++)
            {
                betűcopy[i] = '*';
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Ebben a programban ki kell találnia a szót a csillagok mögöt!");
            Console.WriteLine("Összesen {0}db probálkozása a van!",betűk.Length * 2);
            Console.WriteLine("(Ha tudod a megoldást irj be egy '1'-est és probáld meg, de ha elrontod akkor a játéknak vége!)");
            Console.WriteLine();
            Console.WriteLine();
            do
            {
                feltétel = false;
                volte = false;
                jóe = true;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                foreach (var i in betűcopy)
                {
                    Console.Write(i);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Kérek egy betűt: ");
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    érték = char.Parse(Console.ReadLine());
                }
                catch
                {
                    jóe = false;
                }
                if (érték == '1')
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Megoldás: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    megoldás = Console.ReadLine();
                    if (megoldás == szó)
                    {
                        megoldásf = true;
                        break;
                    }
                    else
                    {
                        megoldásf = false;
                        break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                if (jóe)
                {
                    for (int i = 0; i < betűk.Length; i++)
                    {
                        if (betűk[i] == érték)
                        {
                            betűcopy[i] = érték;
                            volte = true;
                        }
                    }
                    if (!volte) Console.WriteLine("Ez a betű nem található a szóban ({0})", érték);
                }
                else Console.WriteLine("Rossz formátum!");
                foreach (var i in betűcopy)
                {
                    if (i == '*') feltétel = true;
                }
                db++;
            } while (feltétel && db <= betűk.Length * 2);
            if (db > betűk.Length * 2) megoldásf = false;
            Console.ForegroundColor = ConsoleColor.Red;
            if (megoldásf)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Gratulálok ön kitalálta a szót!({0})", szó);
            }
            else Console.WriteLine("Önnek nem sikerült kitalálni a szót! A játéknak vége! A szó a '{0}' volt", szó);
            Console.ReadKey();
        }
    }
}
