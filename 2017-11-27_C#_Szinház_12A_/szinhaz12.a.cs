using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Szinház_12A
{
    class Hely
    {
        public bool foglalte { get; set; }
        public int ár { get; set; }

        public Hely(bool f, int x)
        {
            foglalte = f;
            ár = x;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Hely[,] m = new Hely[17, 20];
            string[] a1 = File.ReadAllLines("f.txt");
            string[] a2 = File.ReadAllLines("k.txt");

            for (int i = 0; i < a1.Length; i++)
            {
                for (int j = 0; j < a1[0].Length; j++)
                {
                    bool f;
                    if (a1[i][j] == 'o') f = false;
                    else f = true;

                    int x = int.Parse(a2[i][j].ToString());
                    Hely h = new Hely(f,x);
                    m[i, j] = h;
                }
            }


            Console.Write("Adjon meg egy sor és egy szék számot [sor,szék]: ");
            string b = Console.ReadLine();
            Console.WriteLine(m[int.Parse(b.Split(',')[0]) - 1, int.Parse(b.Split(',')[1]) - 1].foglalte? "A hely foglalt" : "A hely szabad");

            int sum = 0;
            int[] t = new int[5];
            foreach (var i in m)
            {
                if (i.foglalte)
                {
                    sum++;
                    t[i.ár - 1]++;
                }
            }

            double avg = sum / (double)m.Length;
            Console.WriteLine($"Az előadásra eddig {sum} jegyet adtak el, ez a nézőtér {avg * 100:#} %-a.");

            int kat = 0;
            int max = t[kat];
            for (int i = 1; i < t.Length; i++)
            {
                if (t[i] > max) { kat = i; max = t[kat]; }
            }
            Console.WriteLine($"A legtöbb jegyet a(z) {kat + 1}. árkategóriában értékesítették.");

            int bev = t[0] * 5000 + t[1] * 4000 + t[2] * 3000 + t[3] * 2000 + t[4] * 1500;
            

            Console.WriteLine($"Bevétel: {bev}Ft");
            Console.ReadKey();
        }
    }
}
