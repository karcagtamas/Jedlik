using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFwindow
{
    class Pont : Shape
    {
        public int X { get; set; }
        public int Y { get; set; }

        public SolidColorBrush Szín { get; set; }
        public int Ssz { get; set; }

        protected Window Ablak;
        private Grid Rács;
        protected KoordinátaTengely Kt;


        public Pont(int x, int y, int ssz, SolidColorBrush szín, Window ablak, KoordinátaTengely kt)
        {
            X = x;
            Y = y;
            Ssz = ssz;
            Szín = szín;
            Ablak = ablak;
            Rács = (Grid)Ablak.Content;
            Stroke = szín; //Nincs alapértelmezett "fekete" !!!!
            Kt = kt;
        }

        public virtual bool Rajzolható //Ezt javítani kell!!
        {
            get
            {
                if (Kt.Pole.X + X < Ablak.Width &&
                    Kt.Pole.X + X > 0 &&
                    Kt.Pole.Y + Y < Ablak.Height &&
                    Kt.Pole.Y + Y > 0)
                {
                    return true;
                }
                else return false;
            }
        }

        private Geometry Sorszám()
        {
            int deltaX = (int)Kt.Pole.X;
            int deltaY = (int)Kt.Pole.Y;
            FormattedText Szám = new FormattedText(Ssz.ToString(), //Kiiradó szöveg
                    CultureInfo.CurrentUICulture, //Nyelv beálítása
                    FlowDirection.LeftToRight, //Balról-jobbra
                    new Typeface("Serif"), //Betű típusa
                    10.0, //Betű mérete
                    this.Stroke); //Rajzoló ecset
            return Szám.BuildGeometry(new Point(X + 5 + deltaX, -Y + 5 + deltaY));
        }


        protected virtual Geometry Rajzol() //Leszármazott osztályokban felül fogjuk írni
        {
            int deltaX = (int)Kt.Pole.X;
            int deltaY = (int)Kt.Pole.Y;
            const int size = 5;
            PathFigure kereszt = new PathFigure();
            kereszt.StartPoint = new Point(X - size + deltaX, -Y - size + deltaY); //bal felső pontra "ugrunk"
            kereszt.Segments.Add(new LineSegment(new Point(X + size + deltaX, -Y + size + deltaY), true)); //jobb alsóig vonalat húzunk
            kereszt.Segments.Add(new LineSegment(new Point(X + size + deltaX, -Y - size + deltaY), false)); //jobb felsőbe "ugrunk" false->vonalhúzás nélkül
            kereszt.Segments.Add(new LineSegment(new Point(X - size + deltaX, -Y + size + deltaY), true)); //bal alsó sarokig vonalat húzunk

            PathGeometry geom = new PathGeometry();
            geom.Figures.Add(kereszt);
            geom.Freeze(); //Geometria lezárása - Javasolt!
            return geom;
        }


        protected override Geometry DefiningGeometry
        {
            get
            {
                GeometryGroup gg = new GeometryGroup(); //Összetett alakzathoz használjuk
                if (Rajzolható)
                {
                    gg.Children.Add(Rajzol()); //Kereszt
                    gg.Children.Add(Sorszám()); //Sorszám
                }
                return gg;
            }
        }
    }
}
