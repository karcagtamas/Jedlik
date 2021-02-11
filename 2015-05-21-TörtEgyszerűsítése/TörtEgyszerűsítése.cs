/* Kódolja az alábbi algoritmust a választott programozási nyelven!
   Az algoritmus a számlálóval és nevezővel megadott törtet próbálja tovább egyszerűsíteni.
   A „div” az egészosztás, a „mod” a maradékképzés operátora. 
   A szögletes zárójelpárok között [ ] megjegyzéseket talál, ezeket is helyezze el a forráskódban!
    
   Program:
        Ki:”Számláló: ”
        Változó sz: Egész
        Be: sz
        Változó esz: Egész [Eredeti számláló]
        esz:=sz
        Változó n: Egész
        Ciklus
            Ki:”Nevező: ”
            Be:n
        amíg n=0
        Ciklus vége
        Változó en: Egész [Eredeti nevező]
        en:=n
        Változó maradek: Egész
        Ciklus amíg n<>0
            maradek:=sz mod n
            sz:=n
            n:=maradek
        Ciklus vége
        Változó lnko: Egész
        Ha sz>n akkor lnko:=sz különben lnko:=n
        Ki:”Eredeti tört: ”,esz,”/”,en [Pl.: Eredeti tört: 4/12]
        Ha lnko=0 akkor Ki:”Tovább nem egyszerűsíthető”
        különben
            Ha en=lnko akkor Ki:”Az egész szám: ”, esz div lnko
                különben
                    i:”Egyszerűsítve: ”
                    Ki:esz div lnko, ”/”, en div lnko [pl.: Egyszerűsítve: 1/3]
            Elágazás vége
        Elágazás vége
    Program vége. 

*/

using System;

namespace TörtEgyszerűsítése
{
    class TörtEgyszerűsítése
    {
        static void Main()
        {
            Console.Write("Számláló: "); //Ki:”Számláló: ”
            int sz; //Változó sz: Egész
            sz = int.Parse(Console.ReadLine()); //Be: sz
            int esz; //Eredeti számláló //Változó esz: Egész [Eredeti számláló]
            esz = sz; //esz:=sz
            int n; //Változó n: Egész
            do //Ciklus
            {
                Console.Write("Nevező: "); //Ki:”Nevező: ”
                n = int.Parse(Console.ReadLine()); // Be:n
            } while (n == 0); //amíg n = 0; Ciklus vége
            int en; // Eredeti nevező // Változó en: Egész [Eredeti nevező]
            en = n; //en:=n

            int maradek; //Változó maradek: Egész
            while (n != 0) //Ciklus amíg n<>0
            {
                maradek = sz % n; //maradek:=sz mod n
                sz = n; //sz:=n
                n = maradek; //n:=maradek
            } //Ciklus vége

            int lnko; //Változó lnko: Egész
            if (sz > n) lnko = sz; else lnko = n; //Ha sz>n akkor lnko:=sz különben lnko:=n
            Console.WriteLine("Az eredeti tört: {0}/{1}", esz, en); //Pl.: Eredeti tört: 4/12 // Ki:”Eredeti tört: ”,esz,”/”,en [Pl.: Eredeti tört: 4/12]
            if (lnko == 1) Console.WriteLine("Tovább nem egyszerűsíthető!"); //Ha lnko=0 akkor Ki:”Tovább nem egyszerűsíthető”
            else //különben
            {
                if (en == lnko) Console.WriteLine("Az egész szám: {0}", esz / lnko); //Ha en=lnko akkor Ki:”Az egész szám: ”, esz div lnko
                else //  különben
                    //  Ki:”Egyszerűsítve: ”; Ki:esz div lnko, ”/”, en div lnko [pl.: Egyszerűsítve: 1/3] ; Elágazás vége
                    Console.WriteLine("Egyszerűsítve: {0}/{1}", esz / lnko, en / lnko); //pl.: Egyszerűsítve: 1/3
                   
            } //Elágazás vége
            Console.ReadLine();
        }
    }
}
