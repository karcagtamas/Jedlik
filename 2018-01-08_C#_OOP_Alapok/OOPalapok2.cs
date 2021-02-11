//1. OOP jelentése? Objektum Orientált Programozás
//2. OOP tulajdonságai (elvei)
//1. Adat és kód kombinációja (objektum = adat + kód)
//2. Öröklés (mezők, metódusokat)
//3. Zártság (objektum saját tagjai legyenek az elsődlegesek,
//            amit a virtuális tagok biztosítanak)
//4. Többalakúság ( new ws. override)
//3. Osztály fogalma? OOP programozás alapvető adattípusa (definíció)
//   Tagjai segítségével univerzális, sokoldalú eszköz a programozó "kezében".
//4. Osztálytagok típusai?
//Adattagok:
//1. Mezők (field) --> objektum adatainak tárolása
//2. Jellemzők (property) --> speciális mező --> "kívülről" mező, "belülről" metódus
//   metódusokkal felügyeljük az írást és olvasást
//3. Indexerek --> Indexelhető jellemzők (tömbök-höz hasonlóak)
//4. Konstansok --> mint a mezők, de nem módosíthatóak
//5. Beágyazott típusok --> (nested types) 

//Kódtagok:
//6. Metódusok (alprogramok, eljárások és fg.-ek) --> Osztály viselkedése (kód)
//7. Konstruktorok --> speciális metódus, objektumpéldányt készíti fel 
//                     a használatra (inicializál)
//8. Destruktorok --> Speciális metódus,
//                    Objektumok megszűnésével kapnak szerepet        
//9. Operátorok --> Meglévő operátoraink új jelentést kapnak
//10. Események --> objektummal történő esemény (pl.: OnClick)

//5. Mire használjuk a mezőket?  Objektum adatainak tárolása.
//6. Mi jellemzi a jellemzőket? 
//   Speciális mezők --> "kívülről" mező, "belülről" metódus
//   Metódusokkal felügyeljük az írást és olvasást.
//7. Jellemző definíció általános alakja:
//   [láthatósági_szint] jell_típusa jell_azonosítója
//   {
//      get { ... return valami ...}
//      set { ... privát_mező = value; ... }
//   }
//8. Automatikus jellemzők:
//   public jell_típusa jell_azonosítója {get; private set;}
//9. Példa jellemző:
//   publuc int Kerület
//   {
//      get { return a+b+c;}
//      set { a=value/3.0; b=value/3.0; c=value/3.0; } 
//   }
//10. Láthatósági szintek fajtái, jellemzésük:
//      1. public - objektum példány "felöl" is elérhető
//      2. private (alapértelmezett) - csak az osztálytagok "látják"
//      3. protected - csak az osztálytagok és leszármazottaik "látják"
//11. Konstruktor fogalma, szerepe:
//  Speciális metódusok, objektumpéldányt készíti fel a használatra (inicializálnak)
//  Visszatérési értéke nem lehet (void sem)!
//  Hozzáférési szint 98%-ban public
//  Neve eggyezik az osztály nevével!
//  Egy osztálynak több konstruktora is lehet.
//  Konstruktor akkor is van, ha nem definiálunk:
//  Alapértelmezett konstruktor
//12. Objektum fogalma: Az osztálypéldányt objektumnak is nevezzük.
//13. Példányosítás általános alakja:
//  osztály_típusa objektum_azonosítója = new osztály_konstruktora([aktuális paraméterlista]);
//14. Formális és aktuális paraméterek
//    formális: public void Rajzol(char mit); mit -> formális paraméter
//    aktuális: if (a>0) Rajzol('a'); 'a' -> aktuális paraméter
//15. Késői kötés: Csak futtatáskor derül ki az objektum típusa, ezt késői kötésnek hívjuk.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPAlapok
{
    //OOP - Objektum Orientált Programozás
    //Osztály (class): 
    //OOP programozás alapvető összetett adattípusa.

    //Objektum (object):
    //Az osztály példányosításával nyert változó 
    //(osztálypéldány)

    //OOP elvei:
    //1. Adat és kód egysége -> Egységbezárás (encapsulation)
    //   (objektum = adat + kód)
    //2. Öröklés (inheritance) 
    //   (Saját tagokon kívül örökölhetnek is tagokat
    //   ős, leszármazott osztályok)
    //3. Zártság: 
    //   (Az objektum saját tagjai legyenek az elsődlegesek,
    //   amit a virtuális tagok biztosítanak csak maradéktalanul!)
    //4. Többalakúság (polymorphism)
    //   Polimorfizmus - Azonos nevű metódusok különböző tartalommal
    //   ( new vs. override)

    public enum Mértékegység { mm=1, cm=10, m=1000, km=1000000 }; // Osztálydefiníción kívűl kell elhelyezni

    //Az osztály definíciója:
    class Sokszög  //PascalCase -> OsztályNeve
    {
        //osztálytagok típusai: (10 féle)
        //Adattagok:
        //1. Mezők (field) --> osztály adatainak tárolása
        //2. Jellemzők (property) --> speciális mező --> 
        //   "kívülről" mező, 
        //   "belülről" metódus
        //    metódusokkal felügyeljük az írást és olvasást
        //3. Indexerek --> Indexelhető jellemzők 
        //   (tömbök-höz hasonlóak)
        //4. Konstansok --> mint a mezők, de nem módosíthatóak
        //5. Beágyazott típusok --> (nested types) 

        //Kódtagok:
        //6. Metódusok (alprogramok, eljárások és fg.-ek) --> Osztály "viselkedése" (kód)
        //7. Konstruktorok --> speciális metódus, objektumpéldányt készíti fel 
        //                     a használatra (inicializál)
        //8. Destruktorok --> Speciális metódus,
        //                    Objektumok megszűnésével kapnak szerepet        
        //9. Operátorok --> Meglévő operátoraink új jelentést kapnak
        //10. Események --> objektummal történő esemény (pl.: OnClick)

        //A tagok azonosítóinál is PascalCase névkonvenciót használunk!

        protected List<double> Oldalak; //mező (védett mező)
        protected Mértékegység Me; //mező az oldalhosszakhoz tartozó mértékegység


        //Hozzáférés módosítók (láthatósági szintek) (5 féle):
        //1. public - objektum példány felöl is elérhető
        //2. private (alapértelmezett) - csak az osztálytagok "látják"
        //3. protected - csak az osztálytagok és leszármazottaik "látják"
        //4. internal
        //5. protected internal


        public Sokszög(double[] oldalak, Mértékegység me) //Konstruktor
        //Visszatérési értéke nem lehet (void sem)!
        //Hozzáférési szint 98%-ban public
        //Neve egyezik az osztály nevével!
        //Egy osztálynak több konstruktora is lehet.
        {
            if (oldalak.Length < 3) throw new Exception("Kevés oldal!");
            //Ha kivételt dob, akkor nem jön létre osztálypéldány (null)
            Oldalak = new List<double>(oldalak.Length);

            //Az oldalak hosszát mm-ben tároljuk:
            foreach (var i in oldalak) Oldalak.Add(i * (int)me);
            if (!Szerkeszthető()) throw new Exception("Ez így nem szerkeszthető!");
            Me = me;
        }
        //Konstruktor akkor is van, ha nem definiálunk:
        //Alapértelmezett konstruktor: Mezőket "nullázza"
        //Alapértelmezett konstruktor hívása:
        //Sokszög ssz = new Sokszög();
        //new operátor - pédányosítás operátora

        public double Kerület //Jellemző 1.
        {
            get //olvasáskor lefutó kód
            {
                double kerület = 0;
                foreach (var i in Oldalak)
                {
                    kerület += i;
                }
                return kerület/(int)Me; //Átváltás a megadott mértékegységre
            }
            set //íráskor lefutó kód
            {  // value -> ebben a változóban van az új érték
                // set blokkban határozzuk meg az elfogadását (átalakítását)
                if (value <= 0) throw new Exception("A kerület nem lehet negatív vagy nulla!");
                double oldal = value / Oldalak.Count;
                for (int i = 0; i < Oldalak.Count; i++)
                {
                    Oldalak[i] = oldal * (int)Me;
                }
            }
        }

        
        virtual public double Terület() //Gyak teszt! A jellemzők is lehetnek virtuálisak, necsak a metódusok!
        {
           //Itt még nem tudjuk meghatározni
           return double.NaN;
        }

        //Metódusok:
        public bool Szerkeszthető() //Metódus 2.
        {
            foreach (var oldal in Oldalak)
            {
                if (oldal <= 0) return false;
            }
            if (Oldalak.Max() >= Kerület - Oldalak.Max()) return false;
            return true;
        }

        //virtual foglalt szó a többalakúságot és
        //a zártságot biztosítja:
        public void TerületKiír()
        {
            Console.WriteLine("T= {0} {1}2", Terület(), Me.ToString());
        }

        public override string ToString()
        {
            return string.Format("T={0} K={1}", Terület(), Kerület);
        }


    } //Class Sokszög



    class Háromszög : Sokszög  //class utód osztály : ősosztály
    {

        //Konstruktor
        public Háromszög(double[] oldalak, Mértékegység me) //Konstruktor
            : base(oldalak, me) //Ősosztály konstruktorát hívjuk, elhagyható
        {
            //:base(x)==> Meghívja az ősosztály konstruktorát, elhagyható
            if (oldalak.Length != 3) throw new Exception("A háromszögnek három oldala van!");
        }
        
        public bool DerékszögűHáromszög
        {
            get
            {
                //Oldalak rendezése
                Oldalak.Sort();
                double a = Oldalak[0];
                double b = Oldalak[1];
                double c = Oldalak[2];
                return Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2);
            }
        }

        //A virtuális metódusok újradefiniálásakor (többalakúság)
        //az override foglalt szót kell használni:

        override public double Terület()  //Többalakúság
        {
            double a = Oldalak[0];
            double b = Oldalak[1];
            double c = Oldalak[2];
            double s = (a+b+c) / 2;
            //Heron képlet a területhez:
            double T = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            double osztó = (int)Me;
            return T / (osztó*osztó);
        }
    } //class Háromszög def. vége



    class Alapok
    {
        static void Main(string[] args)
        {
            List<Sokszög> alakzatok = new List<Sokszög>();
            try
            {
                alakzatok.Add(new Sokszög(new double[] 
                    { 1.0, 2.0, 3.0, 4.0 }, Mértékegység.km));
                alakzatok.Add(new Háromszög(new double[] 
                    { 3.0, 4.0, 5.0 }, Mértékegység.km));
                //Hogyan adható egy Sokszög típusú listához
                //Háromszög típusú objektum????
                //Válasz: Az utód osztály kompatibilis az ősosztályal
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            foreach (var i in alakzatok)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();

        }
    }
}
