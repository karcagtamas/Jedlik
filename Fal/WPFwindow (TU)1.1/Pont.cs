using System;
using System.Collections.Generic;
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
        public int Ssz {get;set;}

        private Window Ablak;
        protected Grid Rács;
        protected KoordinátaTengely Kt;
        protected int deltaX;
        protected int deltaY;

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
            deltaX = (int)Kt.Pole.X;
            deltaY = (int)Kt.Pole.Y;
        }

        public bool Rajzolható //Ezt javítani kell!!
        {
            get
            {
                if (Kt.Pole.X + X < Ablak.Width &&
                    Kt.Pole.X+X>0 &&
                    Kt.Pole.Y+Y<Ablak.Height &&
                    Kt.Pole.Y+Y>0)
                {
                    return true;
                }
                else return false;
            }
        }

        protected virtual Geometry Rajzol() //Leszármazott osztályokban felül fogjuk írni
        {
            const int size = 5;
            PathFigure kereszt = new PathFigure();
            kereszt.StartPoint = new Point(X -size + deltaX, -Y - size + deltaY); //bal felső pontra "ugrunk"
            kereszt.Segments.Add(new LineSegment(new Point(X + size + deltaX, -Y + size + deltaY), true)); //jobb alsóig vonalat húzunk
            kereszt.Segments.Add(new LineSegment(new Point(X + size + deltaX, -Y - size + deltaY), false)); //jobb felsőbe "ugrunk" false->vonalhúzás nélkül
            kereszt.Segments.Add(new LineSegment(new Point(X -size + deltaX, -Y + size + deltaY), true)); //bal alsó sarokig vonalat húzunk

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
                if (Rajzolható==true) gg.Children.Add(Rajzol()); //Kereszt
                return gg;
            }
        }

        //bool RajzolOld()
        //{
        //    if (Rajzolható)
        //    {
        //        // "\"
        //        Line l1 = new Line();
        //        l1.X1 = X - 5 + Ablak.Width / 2;
        //        l1.Y1 = Y - 5 + Ablak.Height / 2;
        //        l1.X2 = X + 5 + Ablak.Width / 2;
        //        l1.Y2 = Y + 5 + Ablak.Height / 2;
        //        l1.StrokeThickness = 1;
        //        l1.Stroke = Szín;
        //        Rács.Children.Add(l1);

        //        // "/"
        //        Line l2 = new Line();
        //        l2.X1 = X + 5 + Ablak.Width / 2;
        //        l2.Y1 = Y - 5 + Ablak.Height / 2;
        //        l2.X2 = X - 5 + Ablak.Width / 2;
        //        l2.Y2 = Y + 5 + Ablak.Height / 2;
        //        l2.StrokeThickness = 1;
        //        l2.Stroke = Szín;
        //        Rács.Children.Add(l2);


        //        return true;
        //    }
        //    else return false;
        //}
    }
}
