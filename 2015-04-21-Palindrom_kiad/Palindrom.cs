/*
Kódolja az alábbi algoritmust a választott programozási nyelven!
Az algoritmus az ötjegyű palindrom (számjegyeit fordított sorrendben írva az eredeti
számot kapjuk vissza) négyzetszámokat keresi meg és írja ki a képernyőre.
A Hatvány(alap,kitevő), a Négyzetgyök(szám) és az Egészrész(szám) alprogramokat is
pszeudókóddal adtuk meg, kódolásuk (paraméterezésük) az Ön által tanult módon történjék!
A „div” az egészosztás, a „mod” a maradékképzés operátora. Beadandó a feladatot megoldó
program forráskódja! A feladat megoldásaként teljes, fordítható és futtatható kódot kérünk!

Függvény Negyzetszam(szam:Egész):Logikai
  Változó gyok:Egész
  gyok:=Egészrész(Négyzetgyök(szam))
  Negyzetszam:=Hatvány(gyok,2)=szam
Függvény vége

Program Palindrom:
  Konstans H:=5
  Változó elso:Logikai
  elso:=igaz
  Ciklus i:=Hatvány(10,H-1)-tól Hatvány(10,H)-1-ig +1 lépésközzel
      Változó szam:Egész
      Változó index:Egész
      Változó palindrom:Logikai
      Változó jegyek[0..H-1]:Egész elemű tömb [bájt típusú]
      szam:=i
      index:=0
      palindrom:=Igaz
      Ciklus
          jegyek[index]:= szam mod 10
          index:= index + 1
          szam := szam div 10
      amíg szam>0
      Ciklus vége
      Változó j:Egész
      j:=0
      Ciklus amíg j<(index div 2 +1) és palindrom
          Ha jegyek[j] <> jegyek[index – 1 – j] akkor palindrom := Hamis
          j:= j + 1
      Ciklus vége
      Ha palindrom és Négyzetszam(i) akkor
          Ha elso akkor elso := Hamis különben Ki: ”, ”
          Ki:i
      Elágazás vége
  Ciklus vége
Program vége.
*/

using System;

namespace Palindrom
{
    class Palindrom
    {
        static bool Negyzetszam(int szam)
        {
            int gyok = (int)Math.Sqrt(szam); //gyok:=Egészrész(Négyzetgyök(szam))
            return Math.Pow(gyok, 2) == szam; //Negyzetszam:=Hatvány(gyok,2)=szam
        }

        static void Main(string[] args)
        {
            const int H = 5; //Konstans H:=5
            bool elso = true; //Változó elso:Logikai; elso:=igaz
            for (int i = (int)Math.Pow(10,H-1); i <= (int)Math.Pow(10,H)-1; i++) //Ciklus i:=Hatvány(10,H-1)-tól Hatvány(10,H)-1-ig (+1 lépésközzel)
            {
                int szam = i; //Változó szam:Egész; szam:=i
                int index = 0; //Változó index:Egész; index:=0
                bool palindrom = true; //Változó palindrom:Logikai; palindrom:=Igaz
                byte[] jegyek = new byte[H]; //Változó jegyek[0..H-1]:Egész elemű tömb [bájt típusú]
                do //Ciklus
                {
                    jegyek[index] = (byte)(szam % 10); //jegyek[index]:= szam mod 10
                    index++; //index:= index + 1
                    szam = szam / 10; //szam := szam div 10
                } while (szam > 0); //amíg szam>0; Ciklus vége

                int j = 0; //Változó j:Egész; j:=0

                while (j < index / 2 + 1 && palindrom) //Ciklus amíg j<(index div 2 +1) és palindrom
                {
                    if (jegyek[j] != jegyek[index - 1 - j]) palindrom = false; //Ha jegyek[j] <> jegyek[index – 1 – j] akkor palindrom := Hamis
                    j++; //j:= j + 1
                }

                if (palindrom && Negyzetszam(i)) //Ha palindrom és Négyzetszam(szam) akkor
                {
                    if (elso) elso = false; else Console.Write(", "); //Ha elso akkor elso := Hamis különben Ki: ”, ”
                    Console.Write(i); //Ki:i
                }
            }
            Console.ReadKey();
        }
    }
}
