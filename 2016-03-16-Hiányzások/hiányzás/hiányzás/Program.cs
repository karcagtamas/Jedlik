using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hiányzás
{
    struct hiány
    {
        public string név;
        public string osztály;
        public string dátum;
        public string órák;
    }
    class Program
    {
        static int nap10(string dátum) 
        {
            
            return 0;
        }
        static void Main(string[] args)
        {
            string[] osztályok = { "9a", "9b", "9c", "9d", "10a", "10b", "10c", "10d", "11a", "11b", "11c", "11d", "12a", "12b", "12c", "12d" };
            int[] értékek = new int[osztályok.Length];
            int[] hiérték = new int[osztályok.Length];
            int[] évérték = new int[4];
            StreamReader sr = new StreamReader("Hiányzások.txt",Encoding.UTF8);
            sr.ReadLine();
            List<hiány> l = new List<hiány>();
            List<string> össz = new List<string>();
            List<string> hiányzók = new List<string>();
            string a;
            string[] m;
            while (!sr.EndOfStream)
            {
                hiány h = new hiány();
                a = sr.ReadLine();
                m = a.Split('	');
                h.név = m[0];
                h.osztály = m[1];
                h.dátum = m[2];
                h.órák = m[3];
                l.Add(h);
                //if (!össz.Contains(h.név)) össz.Add(h.név);
                //if (h.dátum == "2015.09.04") hiányzók.Add(h.név);
                
            }
            int nap10 = 0;
            int órák10c = 0;
            foreach (hiány i in l)
            {
                if (!össz.Contains(i.név)) össz.Add(i.név);
                if (i.dátum == "2015.09.04") hiányzók.Add(i.név);
                string[] t = i.dátum.Split('.');
                if (int.Parse(t[2]) >= 1 && int.Parse(t[2]) <= 10) nap10++;
                if (i.osztály == "10c") órák10c += int.Parse(i.órák);
                if (i.osztály[0] == '9') évérték[0] += int.Parse(i.órák);
                if (i.osztály[0] == '1')
                {
                    if (i.osztály[1] == '0')évérték[1] += int.Parse(i.órák);
                        if (i.osztály[1] == '1')évérték[2] += int.Parse(i.órák);
                        if (i.osztály[1] == '2') évérték[3] += int.Parse(i.órák);
                }
            }
            Console.WriteLine("Tanulók száma: {0}",össz.Count);
            Console.WriteLine("Hiányzók:");
            foreach (var i in hiányzók)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Az első 10 napon {0}fő hiányzik",nap10);
            Console.WriteLine("Átlag hiányzás a 10.c-ben: {0:F2}",(double)órák10c / 31);
            bool napok = false;
            for (int j = 0; j < 31; j++)
            {
                bool feltétel = true;
                foreach (hiány i in l)
                {
                    string[] t = i.dátum.Split('.');
                    if (int.Parse(t[2]) == j) feltétel = false;
                }
                if (feltétel) napok = true;
            }
            if (napok) Console.WriteLine("Igaz");
            else Console.WriteLine("Hamis");
            for(int i = 0; i < osztályok.Length;i++)
            {
                foreach (hiány j in l)
                {
                    if (osztályok[i] == j.osztály)
                    {
                        értékek[i] += int.Parse(j.órák);
                        hiérték[i]++;
                    }
                }
            }
            for (int i = 0; i < értékek.Length; i++)
            {
                if (értékek[i] != 0) Console.WriteLine("Az {0} osztálynak a hiányzása: {1}",osztályok[i],értékek[i]);
            }
            for (int i = 0; i < évérték.Length; i++)
            {
                Console.WriteLine("A {0}. évfolyam hiányzása: {1}",i + 9, évérték[i]);
            }
            for (int i = 0; i < értékek.Length; i++)
            {
                Console.WriteLine("Az {0} osztályból {1}fő egyszer sem hiányzott szeptemberben", osztályok[i], 31-hiérték[i]);
            }
            Console.ReadKey();
        }
    }
}
