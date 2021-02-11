using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mono
{
    class terület
    {
        string név;

        public string Név
        {
            get { return név; }
            set { név = value; }
        }
        int vételár;

        public int Vételár
        {
            get { return vételár; }
            set { vételár = value; }
        }
        int fizetendőár;

        public int Fizetendőár
        {
            get { return fizetendőár; }
            set { fizetendőár = value; }
        }
        string birtokos = "bank";

        public string Birtokos
        {
            get { return birtokos; }
            set { birtokos = value; }
        }
        bool megvehetőe;

        public terület(string a, int b,int c, bool e)
        {
            this.név = a;
            this.vételár = b;
            this.fizetendőár = c;
            this.megvehetőe = e;
        }
    }
}
