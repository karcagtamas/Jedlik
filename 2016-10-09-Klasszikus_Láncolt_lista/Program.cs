using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Klasszikus_Láncolt_lista
{
    class MyLinkedListNode
    {
        public int A { get;  set; } //Adattag

        public MyLinkedListNode K { get; set; } //Követő
        public MyLinkedListNode E { get; set; } //Előző

        public MyLinkedListNode(int adat)
        {
            A = adat;
            K = null;
            E = null;
        }

         ~MyLinkedListNode() //Destruktor 
        {
            System.Diagnostics.Trace.WriteLine("GC Dispose!");
        }
    }



    public class MyLinkedList
    {
        private MyLinkedListNode Első;
        private MyLinkedListNode Utolsó;

        public MyLinkedList()
        {
            Első = Utolsó = null;
        }

        public int Count
        {
            get
            {
                int db = 0;
                MyLinkedListNode akt = Első;
                while (akt != null)
                {
                    akt = akt.K;
                    db++;
                }
                return db;
            }
        }


        public void Beszúr(int adat)
        {
            MyLinkedListNode új = new MyLinkedListNode(adat);
            if (Első == null) //Ha üres a lánc
            {
                Első = Utolsó = új;
            }
            else
            {
                MyLinkedListNode akt = Első;
                while (akt != null && adat > akt.A) akt = akt.K; //Keressük a beszúrás helyét
                if (akt!=null) //Ha az aktuális elé kell beszúrni
                {
                    if (akt == Első) //A lánc elejére kell beszúrni
                    {
                        Első.E = új;
                        új.K = Első;
                        Első = új; //új Első
                    }
                    else  //"Közbenső" helyre kell beszúrni
                    {
                        //Sorrend!!!
                        //1.
                        új.K = akt;
                        új.E = akt.E;
                        //2.
                        akt.E.K = új;
                        akt.E = új;
                    }
                }
                else // Ha a lánc végére (aktuális után) kell beszúrni
                {
                    Utolsó.K = új;
                    új.E = Utolsó;
                    Utolsó = új;
                }
            }
        }

        public void TörölPáros()
        {
             MyLinkedListNode akt = Első;
             while (akt != null)
             {
                 if (akt.A % 2 == 0)
                 {
                     //MyLinkedListNode törlendő = akt;
                     if (akt.E != null && akt.K != null) //Közbenső elem
                     {
                         akt.E.K = akt.K;
                         akt.K.E = akt.E;
                         akt = akt.E;
                     }
                     else
                     {
                         if (akt == Első && akt == Utolsó)  //Utolsó elem
                         {
                             Első = null;
                             Utolsó = null;
                         }
                         if (akt == Első) //Elsőt kell töröölni
                         {
                             Első = Első.K;
                             Első.E = null;
                         } 
                         if (akt == Utolsó)
                         {
                             Utolsó = Utolsó.E;
                             Utolsó.K = null;
                         }
                     }
                 }
                 //Következő (ha van) elem vizsgálata (léptetés)
                 if (akt!=null) akt = akt.K;
             }

        }

        public void Kiír(bool visszafelé)
        {
            if (this.Első==null)
            {
                Console.WriteLine("A lista üres !");
            }
            else
            {
                MyLinkedListNode akt = visszafelé ? Utolsó : Első;
                while (akt != null)
                {
                    Console.Write(akt.A+ " ");
                    akt = visszafelé ? akt.E : akt.K;
                }
                Console.WriteLine(); 
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            MyLinkedList l = new MyLinkedList();

            while (l.Count < 10)
            {
                int vszám = r.Next(100, 1000);
                l.Beszúr(vszám);
            }

            l.Kiír(false);
            l.Kiír(true);
            l.TörölPáros();
            //GC.Collect();
            l.Kiír(false);
            l.Kiír(true);
            Console.ReadKey();
        }

    }
    
}
