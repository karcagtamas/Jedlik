using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_Hétfő
{
    class Autók
    {
        string rendszám;

        public string Rendszám
        {
            get { return rendszám; }
            set { rendszám = value; }
        }
        int kényelem;

        public int Kényelem
        {
            get { return kényelem; }
            set { kényelem = value; }
        }
        double fogyasztás;

        public double Fogyasztás
        {
            get { return fogyasztás; }
            set { fogyasztás = value; }
        }
        int tanktelj;

        public int Tanktelj
        {
            get { return tanktelj; }
            set { tanktelj = value; }
        }
        int tankakt;

        public int Tankakt
        {
            get { return tankakt; }
            set { tankakt = value; }
        }
        int személyek;

        public int Személyek
        {
            get { return személyek; }
            set { személyek = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Autók> l = new List<Autók>();
            List<Autók> al = new List<Autók>();
            StreamReader sr = new StreamReader("autóválasztás - A.csv");
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] t = s.Split(';');
                Autók a = new Autók();
                a.Rendszám = t[0];
                a.Kényelem = int.Parse(t[1]);
                if (t[2].Length >= 2) t[2] = t[2].Remove(t[2].IndexOf(','), 1);
                if (t[2].Length == 1) { int x = int.Parse(t[2]); a.Fogyasztás = x; }
                else if (t[2].Length == 2) { int x = int.Parse(t[2]); a.Fogyasztás = (double)x / 10; }
                else { int x = int.Parse(t[2]); a.Fogyasztás = (double)x / 100; }
                a.Tanktelj = int.Parse(t[3]);
                a.Tankakt = int.Parse(t[4]);
                a.Személyek = int.Parse(t[5]);
                l.Add(a);
            }
            Console.WriteLine("Add meg a km-t!");
            int km = int.Parse(Console.ReadLine());
            Console.WriteLine("Add meg az emberek számát!");
            int ember = int.Parse(Console.ReadLine()) ;

            foreach (Autók i in l)
            {
                double megtehetőtáv = i.Tankakt / i.Fogyasztás * 100;
                if (megtehetőtáv >= km && i.Személyek >= ember) al.Add(i);
            }
            foreach (Autók i in l)
            {
                 double megtehetőtáv = i.Tankakt / i.Fogyasztás * 100;
                 double szükséges = (km - megtehetőtáv) * i.Fogyasztás * i.Tankakt / 100;
                if (i.Tankakt + szükséges <= i.Tanktelj && i.Személyek >= ember) al.Add(i);
            }
            foreach (Autók i in l)
            {
                double megtehetőtáv = i.Tankakt / i.Fogyasztás * 100;
                double szükséges = (km - megtehetőtáv) * i.Fogyasztás * i.Tankakt / 100;
                if (i.Tankakt + szükséges > i.Tanktelj && i.Személyek >= ember) al.Add(i);
            }
            foreach (Autók i in al)
            {
                Console.WriteLine(i.Rendszám);
            }
            Console.ReadKey();
        }
    }
}
