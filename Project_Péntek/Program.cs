using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_Péntek
{
    class Balátok
    {
        string név;

        public string Név
        {
            get { return név; }
            set { név = value; }
        }
        string szüldátum;

        public string Szüldátum
        {
            get { return szüldátum; }
            set { szüldátum = value; }
        }
        string nem;

        public string Nem
        {
            get { return nem; }
            set { nem = value; }
        }
        int bulizásihajlam;

        public int Bulizásihajlam
        {
            get { return bulizásihajlam; }
            set { bulizásihajlam = value; }
        }
        string település;

        public string Település
        {
            get { return település; }
            set { település = value; }
        }

        string cím;

        public string Cím
        {
            get { return cím; }
            set { cím = value; }
        }
    }
    class Program
    {
        static bool ell(string[] t)
        {
            string[] m = t[4].Split('.');
            if (2016 - int.Parse(m[0]) > 20 && int.Parse(t[6]) >= 5) return true;
            return false;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("barátaink.csv",Encoding.UTF7);
            sr.ReadLine();
            List<Balátok> l = new List<Balátok>();
            List<Balátok> buli = new List<Balátok>();
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] t = s.Split('|');
                Balátok b = new Balátok();
                b.Név = t[1];
                b.Település = t[2];
                b.Cím = t[3];
                b.Szüldátum = t[4];
                b.Nem = t[5];
                if(t[6] != "")
                b.Bulizásihajlam = int.Parse(t[6]);
                l.Add(b);
                if (ell(t)) buli.Add(b);
            }
            foreach (Balátok i in l)
            {
                Console.Write("Név: {0} ",i.Név);
                Console.Write("Település: {0} ",i.Település);
                Console.Write("Cím: {0} ", i.Cím);
                Console.Write("Születési Dátum: {0} ",i.Szüldátum);
                Console.Write("Nem: {0} ",i.Nem == "N"?"Nő":"Férfi");
                Console.Write("Bulizási hajlam: {0} ",i.Bulizásihajlam);
                Console.WriteLine();
            }
            Console.WriteLine("Barátok akik tudnának jönni a bulira:");
            foreach (Balátok i in buli)
            {
                Console.WriteLine(i.Név);
            }
            Console.ReadKey();
        }
    }
}
