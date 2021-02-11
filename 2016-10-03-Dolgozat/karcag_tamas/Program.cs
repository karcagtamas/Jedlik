using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace karcag_tamas
{
    class Tanuló
    {
        string Vnév;
        string[] Knév;
        bool koleszos;
        char neme;
        byte évfolyam;
        char osztály;
        public Tanuló(char nem, byte évfoly, char oszt)
        {
            this.TanulóNeme = nem;
            this.TanulóÉvfolyama = évfoly;
            this.TanulóOsztálya = oszt;
        }
        public string Vnév1
        {
            get
            {
                return Vnév;
            }

            set
            {
                Vnév = value;
            }
        }

        public string[] Knév1
        {
            get
            {
                return Knév;
            }

            set
            {
                Knév = value;
            }
        }

        public bool Koleszos
        {
            get
            {
                return koleszos;
            }

            set
            {
                koleszos = value;
            }
        }

        public char TanulóNeme
        {
            get
            {
                return neme;
            }

            set
            {
                if (value == 'F' || value == 'L') neme = value;
                else throw new Exception();
            }
        }

        public byte TanulóÉvfolyama
        {
            get
            {
                return évfolyam;
            }

            set
            {
                if (value >= 9 && value <= 14) évfolyam = value;
                else throw new Exception();
            }
        }

        public char TanulóOsztálya
        {
            get
            {
                return osztály;
            }

            set
            {
                if ((int)value >= 65 && (int)value <= 73) osztály = value;
                else throw new Exception();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] vezeték = new string[100];
            string[] lány = new string[100];
            string[] fiú = new string[100];
            List<Tanuló> l = new List<Tanuló>();
            StreamReader sr1 = new StreamReader("Vezetéknevek.txt");
            StreamReader sr2 = new StreamReader("Lányok.txt");
            StreamReader sr3 = new StreamReader("Fiúk.txt");
            int i = 0;
            while(!sr1.EndOfStream)
            {
                vezeték[i] = sr1.ReadLine();
                i++;
            }
            sr1.Close();
            i = 0;
            while (!sr2.EndOfStream)
            {
                lány[i] = sr2.ReadLine();
                i++;
            }
            sr2.Close();
            i = 0;
            while (!sr3.EndOfStream)
            {
                fiú[i] = sr3.ReadLine();
                i++;
            }
            sr3.Close();
            StreamReader sr4 = new StreamReader("feladat.txt");
            while (!sr4.EndOfStream)
            {
                string s = sr4.ReadLine();
                string[] t = s.Split();
                int lányok = int.Parse(t[2]);
                int fő = int.Parse(t[1]);
                int kolesz = int.Parse(t[3]);
                int év = int.Parse(t[0].Remove(t[0].Length - 1, 1));
                char oszt = t[0][t[0].Length - 1];
                double határ = fő * (double)(20 / 100);
                for (int j = 0; j < fő; j++)
                {
                    Thread.Sleep(15);
                    Random r = new Random();
                    bool leány = false;
                    if (lányok != 0)
                    {
                        lányok--;
                        leány = true;
                    }
                    try
                    {
                        Tanuló T = new Tanuló(leány ? 'L' : 'F', (byte)év, oszt);
                        if (kolesz != 0)
                        {
                            kolesz--;
                            T.Koleszos = true;
                        }
                        T.Vnév1 = vezeték[r.Next(vezeték.Length)];
                        if (j > határ)
                        {
                            T.Knév1 = new string[1];
                            if (leány)
                            {
                                T.Knév1[0] = lány[r.Next(lány.Length)];
                            }
                            else
                            {
                                T.Knév1[0] = fiú[r.Next(fiú.Length)];
                            }
                        }
                        else
                        {
                            T.Knév1 = new string[2];
                        if (leány)
                            {
                                T.Knév1[0] = lány[r.Next(lány.Length)];
                                bool jóe = false;
                                string a;
                                do
                                {
                                    jóe = false;
                                    a = lány[r.Next(lány.Length)];
                                    if (T.Knév1[0] == a) jóe = true;
                                } while (jóe);
                                T.Knév1[1] = a;
                            }
                            else
                            {
                                T.Knév1[0] = fiú[r.Next(fiú.Length)];
                                bool jóe = false;
                                string a;
                                do
                                {
                                    jóe = false;
                                    a = fiú[r.Next(fiú.Length)];
                                    if (T.Knév1[0] == a) jóe = true;
                                } while (jóe);
                                T.Knév1[1] = a;
                            }
                        }
                        l.Add(T);
                    }
                    catch
                    {
                        Console.WriteLine("Hibás adat!");
                    }
                }
                
            }
            sr4.Close();
            StreamWriter sw = new StreamWriter("JedlikesTanulók.txt");
            foreach (var k in l)
            {
                sw.Write(k.TanulóÉvfolyama.ToString() + k.TanulóOsztálya.ToString() + "#" + k.Vnév1 );
                foreach (var j in k.Knév1)
                {
                    sw.Write(" " + j);
                }
                string jel = k.Koleszos ? "k" : "b";
                sw.WriteLine("#"+k.TanulóNeme+"#"+ jel);
            }
            sw.Flush();
            sw.Close();
        }
    }
}
