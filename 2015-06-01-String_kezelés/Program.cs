using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyakszi
{
    class Program
    {
        static void Main(string[] args)
        {
            string elsönév = "Karcag";
            string másodiknév = "Tamás";
            Console.WriteLine(elsönév.CompareTo(másodiknév));//összehasonlítja a két nevet ha true akkor 0 ha false akkor -1 a visszatérési érték
            Console.WriteLine(elsönév.Equals(másodiknév));//összehasonlítja a két nevet viszont true-val vagy false-szal tér vissza
            Console.WriteLine(elsönév.Contains("rc"));//megnézi hogy található-e benn "rc" ha igen akkor true ha nem akkor false a visszatérési érték
            Console.WriteLine(elsönév.EndsWith("g"));//megnézi hogy található-e a végén "g" ha igen akkor true ha nem akkor false
            Console.WriteLine(elsönév.StartsWith("K"));//megnézi hogy található-e az elején "K" ha igen akkor true ha nem akkor false
            Console.WriteLine(elsönév.IndexOf('a'));//kiirja az elsö 'a' indexét
            Console.WriteLine(elsönév.LastIndexOf('a'));//kiirja az utolsó 'a' indexét
            Console.WriteLine(elsönév.ToLower());//kisbetübe írja át a szöveget
            Console.WriteLine(elsönév.ToUpper());//nagybetübe írja át a szöveget
            Console.WriteLine(elsönév.Insert(2,"mivanitt"));//beszúrja a 2. betü után a szöveget
            Console.WriteLine(elsönév.Length);//kiirja a string hosszát
            Console.WriteLine(elsönév.Replace('a','w'));//kicseréli az 'a'-t 'w'-re
            Console.WriteLine(elsönév.Remove(2));//a második karakter után kitörli az összes karaktert
            Console.WriteLine(elsönév.Remove(2,2));//a második karakter után kitörli a megadott menyiségü karaktert
            Console.WriteLine(elsönév.Substring(2,2));//kitröli az utolsó és az elsö megadott menyiségü karaktereket
            string[] m = elsönév.Split('a');//szétvágja a stringet az 'a' betüknél
            Console.WriteLine(m[0]);
            Console.WriteLine(m[1]);
            Console.WriteLine(m[2]);
            Console.WriteLine(elsönév.ToCharArray());//a string karakter tömbé alakitása
            Console.WriteLine(elsönév.Trim());//kivágja az üres karaktereket
            Console.WriteLine(elsönév.Trim('a'));//kivágja az 'a' betüket
            Console.WriteLine(elsönév.TrimEnd('a', 'g', 'r'));//kivágja a megadott betüket
            Console.WriteLine(elsönév.TrimStart('K'));//kivágja a megadott betüt
            Console.WriteLine(elsönév.PadLeft(10,'x'));//kitolja a szöveget megfeleöen
            Console.WriteLine(elsönév.PadRight(10, 'x'));//kitolja a szöveget megfeleöen
            Console.ReadKey();
        }
    }
}