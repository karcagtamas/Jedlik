using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace autók
{
    class Program
    {
        struct autók
        {
            public string Típus;
            public string Felépítés;
            public int LE;
            public string Meghajtás;
            public int Ár;
        }
        static void minmax()
        {
            StreamReader sr = new StreamReader("Autók.csv");
            List<string> gyártók = new List<string>();
            sr.ReadLine();
            long max = 0,min = 0;
            bool feltétel;
            do
            {
                feltétel = false;
            try
            {
                Console.Write("Kérem a maximumot:");
                max = Convert.ToInt64(Console.ReadLine());
            }
            catch
            {
                feltétel = true;
            }
            }while(feltétel);
            do
            {
                feltétel = false;
                try
                {
                    Console.Write("Kérem a minimumot:");
                    min = Convert.ToInt64(Console.ReadLine());
                }
                catch
                {
                    feltétel = true;
                }
            } while (feltétel);
            while (!sr.EndOfStream)
            {
                string a = sr.ReadLine();
                string[] m = a.Split(';');
                string b = m[0].Substring(0, m[0].IndexOf(' '));
                int ár = 0;
                if (m[4] != "") ár = int.Parse(m[4]);
                if (ár < max && ár > min) gyártók.Add(b);
            }
            sr.Close();
            Console.WriteLine("Gyárók minimum és maximum között");
            foreach (var i in gyártók)
            {
                Console.WriteLine("{0}",i);
            }
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("Autók.csv");
            autók temp = new autók();
            List<autók> l = new List<autók>();
            List<string> terep = new List<string>();
            List<string> gyártó = new List<string>();
            sr.ReadLine();
            string olcs1 = "";
            long olcs2 = 10000000000;
            string a = "";
            string[] m;
            int audi = 0;
            long összeg = 0;
            int LOE = 0;
            while (!sr.EndOfStream)
            {
                a = sr.ReadLine();
                m = a.Split(';');
                temp = new autók();
                temp.Típus = m[0];
                temp.Felépítés = m[1];
                if (m[2] != "") temp.LE = Convert.ToInt32(m[2]);
                temp.Meghajtás = m[3];
                if (m[4] != "") temp.Ár = Convert.ToInt32(m[4]);
                l.Add(temp);
                if (temp.Típus.StartsWith("Audi")) audi++;
                összeg += temp.Ár;
                if (temp.LE > LOE) LOE = temp.LE;
                if (temp.Felépítés == "terepjáró")
                {
                    terep.Add(temp.Típus);
                    //string b = temp.Típus.Remove(temp.Típus.IndexOf(' '));
                    string b = temp.Típus.Substring(0, temp.Típus.IndexOf(' '));
                    if (!gyártó.Contains(b)) gyártó.Add(b);
                }
                if (temp.Ár < olcs2 && temp.Felépítés == "3-ajtós")
                {
                    olcs2 = temp.Ár;
                    olcs1 = temp.Típus;
                }
            }
            sr.Close();
            Console.WriteLine("Audik száma: {0}",audi);
            Console.WriteLine("Összeg átlaga: {0:F2}",(double)összeg / l.Count);
            Console.WriteLine("Legnagyobb Lóerő: {0} lóerő és legnagyobb teljesítmény: {1} KW",LOE,LOE * 0.74);
            foreach (var i in terep)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Gyártók: {0}", gyártó.Count);
            Console.WriteLine("A legolcsobb három ajtós: {0}", olcs1);
            Console.WriteLine("{0}", string.Join(", ", gyártó));
            minmax();
            Console.ReadLine();
        }
    }
}
