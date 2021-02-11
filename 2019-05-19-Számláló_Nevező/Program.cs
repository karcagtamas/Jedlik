using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karcag_Tamás
{
    class Program
    {
        static void Main(string[] args)//Program:
        {
            Console.Write("Számláló: ");//Ki:”Számláló: ”
            int sz;//Változó sz: Egész
            sz = int.Parse(Console.ReadLine());//Be: sz
            int esz = sz;//Eredeti számláló //Változó esz: Egész [Eredeti számláló];esz:=sz
            int n = 0;//Változó n: Egész
            do//Ciklus
            {
                Console.Write("Nevező: ");//Ki:”Nevező: ”
                n = int.Parse(Console.ReadLine());//Be:n
            } while (n == 0);// amíg n=0; Ciklus vége
            int en = n;//Eredeti nevező //Változó en: Egész [Eredeti nevező];en:=n
            int maradék = 0;//Változó maradek: Egész
            while (n != 0)//Ciklus amíg n<>0
            {
                maradék = sz % n;//maradek:=sz mod n
                sz = n;//sz:=n
                n = maradék;//n:=maradek
            }//Ciklus vége
            int lnko = 0;//Változó lnko: Egész
            if (sz > n)//Ha sz>n akkor 
            {
                lnko = sz;//lnko:=sz
            }
            else//különben 
            {
                lnko = n;//lnko:=n
            }
            Console.WriteLine("Eredeti tört:{0}/{1}", esz, en);//Pl.: Eredeti tört: 4/12 //Ki:”Eredeti tört: ”,esz,”/”,en [Pl.: Eredeti tört: 4/12]
            if (lnko == 1)//Ha lnko=1 akkor 
            {
                Console.WriteLine("Tovább nem egyszerűsíthető");//Ki:”Tovább nem egyszerűsíthető”
            }
            else //különben
            {
                if (en == lnko)//Ha en=lnko akkor
                {
                    Console.WriteLine("Az egész szám:{0}", esz / (double)lnko);//Ki:”Az egész szám: ”, esz div lnko
                }
                else //különben
                {
                    Console.WriteLine("Egyszerüsitve: {0}/{1}", esz / (double)lnko, en / (double)lnko);//pl.: Egyszerűsítve: 1/3 //Ki:”Egyszerűsítve: ”;Ki:esz div lnko, ”/”, en div lnko [pl.: Egyszerűsítve: 1/3]
                }//Elágazás vége
            }//Elágazás vége
            Console.ReadKey();
        }//Program vége.
    }
}
