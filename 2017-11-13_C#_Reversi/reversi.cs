using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Karcag_Tamás_2017._11._13
{
    class Tabla
    {
        public char[,] t;

        public Tabla(string forras)
        {
            t = new char[8, 8];
            string[] s = File.ReadAllLines(forras);
            for (int i = 0; i < t.GetLength(0); i++)
            {
                for (int j = 0; j < t.GetLength(1); j++)
                {
                    t[i, j] = s[i][j];
                }
            }
        }

        public void Megjelenit()
        {
            int x = 1;
            foreach (var i in t)
            {

                if (x != 8)
                {
                    Console.Write(i);
                    x++;
                }
                else
                {
                    Console.WriteLine(i);
                    x = 1;
                }
            }
        }
        public void Stat(string b, char a)
        {
            int s = 0;
            foreach (var i in t)
            {
                if (i == a) s++;
            }
            Console.WriteLine($"{b}: {s}");
        }
        public bool VanForditas(char jatekos, int sor, int oszlop, int iranySor, int iranyOszlop)
        {
            int aktSor;
            int aktOszlop;
            char ellenfel;
            bool nincsEllenfel;

            aktSor = sor + iranySor;
            aktOszlop = oszlop + iranyOszlop;
            ellenfel = 'K';
            if (jatekos == 'K')
            {
                ellenfel = 'F';
            }
            nincsEllenfel = true;

            while (aktSor > 0 && aktSor < 8 && aktOszlop > 0 && aktOszlop < 8 && t[aktSor, aktOszlop] == ellenfel)
            {
                aktSor = aktSor + iranySor;
                aktOszlop = aktOszlop + iranyOszlop;
                nincsEllenfel = false;
            }

            if (nincsEllenfel || aktSor < 0 || aktSor > 7 || aktOszlop < 0 || aktOszlop > 7 || t[aktSor, aktOszlop] != jatekos)
            {
                return false;
            }
            return true;
        }
        public bool szabalyose(char jatekos, int sor, int oszlop)
        {
            if (t[sor,oszlop] == '#')
            {
                if (VanForditas(jatekos, sor, oszlop, 0, -1) || VanForditas(jatekos, sor, oszlop, 0, 1) || VanForditas(jatekos, sor, oszlop, -1, -1) || VanForditas(jatekos, sor, oszlop, -1, 0) || VanForditas(jatekos, sor, oszlop, -1, 1) || VanForditas(jatekos, sor, oszlop, 1, -1) || VanForditas(jatekos, sor, oszlop, 1, 0) || VanForditas(jatekos, sor, oszlop, 1, 1)) return true;
            }
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tabla T = new Tabla("allas.txt");
            Console.WriteLine("5. feladat: A betöltött tábla");
            T.Megjelenit();
            Console.WriteLine("6. feladat: Összegzés");
            T.Stat("Kék korongok száma", 'K');
            T.Stat("Fehér korongok száma", 'F');
            T.Stat("Üres mezők száma", '#');
            Console.WriteLine("8. feladat: [jatekos;sor;oszlop;iranySor;iranyOszlop] = F,4,1,0,1");
            string f8 = "F;4;1;0;1";
            Console.WriteLine(T.VanForditas('F',4,1,0,1)?"Van fordítás":"Nincs fordítás");
            string f9 = "K;1;3";
            Console.WriteLine(T.szabalyose('K',1,3)?"Szabályos lépés!":"Nem szabályos lépés!");
            

            Console.ReadKey();
        }
    }
}
