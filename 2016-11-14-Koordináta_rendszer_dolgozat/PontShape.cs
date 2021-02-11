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
    class PontShape : Shape
    {
        double X { get; set; }
        double Y { get; set; }

        protected override Geometry DefiningGeometry
        {
            get
            {
                GeometryGroup gg = new GeometryGroup(); //Összetett alakzathoz használjuk
                gg.Children.Add(RajzolPont()); //Pont
                return gg;
            }
        }

        public PontShape(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        protected Geometry RajzolPont()
        {
            PathFigure Pont1 = new PathFigure();
            //Pont1.StartPoint = new Point(X - 10, Y - 10);
            //Pont1.Segments.Add(new LineSegment(new Point(X + 10, Y + 10), true));
            Pont1.StartPoint = new Point(100, 100);
            Pont1.Segments.Add(new LineSegment(new Point(110, 110), true));

            PathFigure Pont2 = new PathFigure();
            //Pont2.StartPoint = new Point(X + 10, Y - 10);
            //Pont2.Segments.Add(new LineSegment(new Point(X - 10, Y + 10), true));
            Pont2.StartPoint = new Point(110, 100);
            Pont2.Segments.Add(new LineSegment(new Point(100, 110), true));

            PathGeometry geom = new PathGeometry();
            geom.Figures.Add(Pont1);
            geom.Figures.Add(Pont2);
            geom.Freeze();
            return geom;
        }

    }
}
