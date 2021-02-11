using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_Kedd_2
{
    class Tanulók
    {
        string név;

        public string Név
        {
            get { return név; }
            set { név = value; }
        }
        byte ötös;

        public byte Ötös
        {
            get { return ötös; }
            set { ötös = value; }
        }
        byte négyes;

        public byte Négyes
        {
            get { return négyes; }
            set { négyes = value; }
        }
        byte hármas;

        public byte Hármas
        {
            get { return hármas; }
            set { hármas = value; }
        }
        byte kettes;

        public byte Kettes
        {
            get { return kettes; }
            set { kettes = value; }
        }
        byte egyes;

        public byte Egyes
        {
            get { return egyes; }
            set { egyes = value; }
        }

        int pont;

        public int Pont
        {
            get { return pont; }
            set { pont = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("enaplo.txt");
            List<Tanulók> l = new List<Tanulók>();
            List<Tanulók> lm = new List<Tanulók>();
            string[] m = new string[11];
            byte változó = 0;
            int max = 0;
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                m[változó] = s;
                string[] t = s.Split(' ');
                Tanulók T = new Tanulók();
                T.Név = t[0] + " " + t[1];
                T.Ötös = (byte)int.Parse(t[2]);
                T.Négyes = (byte)int.Parse(t[3]);
                T.Hármas = (byte)int.Parse(t[4]);
                T.Kettes = (byte)int.Parse(t[5]);
                T.Egyes = (byte)int.Parse(t[6]);
                T.Pont = T.Ötös * 3 + T.Négyes * 2 + T.Kettes * -1 + T.Egyes * -2;
                if (T.Pont > max) max = T.Pont;
                l.Add(T);
                változó++;
            }

            Console.WriteLine("3. feladat:");
            Console.Write("A pontszámok: ");
            for (int i = 0; i < l.Count; i++)
            {
                if (i == l.Count - 1) Console.Write(l[i].Pont);
                else Console.Write(l[i].Pont + ", ");
            }
            Console.WriteLine();
            Console.WriteLine("4. feladat:");
            double átlag;
            int összeg = 0;
            foreach (Tanulók i in l)
            {
                összeg += i.Pont;
            }
            átlag = (double)összeg / l.Count;
            Console.WriteLine("A pontszámok átlaga: {0}",átlag);
            Console.WriteLine("5. feladat:");
            foreach (Tanulók i in l)
            {
                if (i.Pont > átlag) Console.WriteLine(i.Név);
            }
            Console.WriteLine("6. feladat");
            foreach (Tanulók i in l)
            {
                if (i.Pont == max) { lm.Add(i); Console.WriteLine(i.Név); }
            }
            Console.ReadKey();
        }
    }
}
