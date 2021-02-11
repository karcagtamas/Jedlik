using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPFwindow
{
    class Kör : Pont
    {
        private int R;
        public Kör(int x, int y, int r, int ssz, SolidColorBrush szín, Window ablak, KoordinátaTengely kt) : 
            base(x, y, ssz, szín, ablak, kt)
        {
            R = r;
        }

        public override bool Rajzolható //Ezt javítani kell!!
        {
            get
            {
                if (Kt.Pole.X + X + R < Ablak.Width &&
                    Kt.Pole.X + X - R > 0 &&
                    Kt.Pole.Y + Y + R < Ablak.Height &&
                    Kt.Pole.Y + Y - R > 0)
                {
                    return true;
                }
                else return false;
            }
        }

        protected override Geometry Rajzol() //Leszármazott osztályokban felül fogjuk írni
        {
            
            int deltaX = (int)Kt.Pole.X;
            int deltaY = (int)Kt.Pole.Y;

            GeometryGroup gg = new GeometryGroup(); //Középkereszthez
            EllipseGeometry eg = new EllipseGeometry(new Point(X + deltaX, -Y + deltaY), R, R);
            eg.Freeze();
            if (Rajzolható)
            {
                gg.Children.Add(base.Rajzol()); //Középpont 
                gg.Children.Add(eg); //Körív
            }
            return gg; //Kör

        }
    }
}
