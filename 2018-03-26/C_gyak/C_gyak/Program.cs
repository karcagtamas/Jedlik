using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace C_gyak
{

    class Program
    {
        static void Main(string[] args)
        {
            List<string> sorok = File.ReadAllLines("Olimpiák.txt", Encoding.UTF8).Skip(1).ToList();
            StreamReader sr = new StreamReader("Olimpiák.txt", Encoding.UTF8);
            sr.ReadLine();
            int i = 0;
            while (!sr.EndOfStream)
            {
                i++;
                Console.WriteLine(i);
                string sor1 = sr.ReadLine();
                string sor2 = sr.ReadLine();
            }
            sr.Close();


            StreamWriter sw = new StreamWriter("újfál.txt", false, Encoding.UTF8);
            sw.WriteLine("asdasdasd");
            sw.Write("asd");
            sw.Flush();
            sw.Close();

            File.WriteAllLines("mibe.csv", sorok, Encoding.UTF8);
        }
    }
}
