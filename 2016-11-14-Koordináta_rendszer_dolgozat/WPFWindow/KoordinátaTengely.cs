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
    class KoordinátaTengely : Shape
    {
        private Grid GridRef;
        private int Xlp;
        private int Ylp;
        private int Oxp;
        private int Oyp;
        private string Xd;
        private string Yd;
        private Point StartX;
        private Point StartY;
        private Point EndX;
        private Point EndY;
        //private FormattedText Felirat;

        public Point Pole
        {
            get
            {
                double FullWidth = GridRef.RenderSize.Width;
                double FullHeight = GridRef.RenderSize.Height;
                return new Point(FullWidth * Oxp / 100.0, FullHeight * Oyp / 100.0);
            }
        }

       
        protected Geometry RajzolTengelyek()
        {

            double FullWidth = GridRef.RenderSize.Width;
            double FullHeight = GridRef.RenderSize.Height;
            double XaxisWidth = FullWidth * Xlp / 100.0;
            double YaxisHeight = FullHeight * Ylp / 100.0;
            StartX = new Point(Pole.X - XaxisWidth / 2, Pole.Y);
            EndX = new Point(Pole.X + XaxisWidth / 2, Pole.Y);
            EndY = new Point(Pole.X, Pole.Y - YaxisHeight / 2);
            StartY = new Point(Pole.X, Pole.Y + YaxisHeight / 2);

            PathFigure tengelyX = new PathFigure();
            tengelyX.StartPoint = StartX; 
            tengelyX.Segments.Add(new LineSegment(EndX, true));

            PathFigure arrowX = new PathFigure();
            arrowX.StartPoint = new Point(EndX.X - 10, EndX.Y - 5);
            arrowX.Segments.Add(new LineSegment(EndX, true));
            arrowX.Segments.Add(new LineSegment(new Point(EndX.X - 10, EndX.Y + 5), true));


            PathFigure tengelyY = new PathFigure();
            tengelyY.StartPoint = StartY;
            tengelyY.Segments.Add(new LineSegment(EndY, true));

            PathFigure arrowY = new PathFigure();
            arrowY.StartPoint = new Point(EndY.X - 5, EndY.Y + 10);
            arrowY.Segments.Add(new LineSegment(EndY, true));
            arrowY.Segments.Add(new LineSegment(new Point(EndY.X + 5, EndY.Y + 10), true));

            PathGeometry geom = new PathGeometry();
            geom.Figures.Add(tengelyX);
            geom.Figures.Add(arrowX);
            geom.Figures.Add(tengelyY);
            geom.Figures.Add(arrowY);
            geom.Freeze(); //Geometria lezárása - Javasolt!
            return geom;

        }

        protected Geometry KiírFelirat(Point pos, string sign)
        {
            FormattedText Felirat = new FormattedText(sign, //Kiiradó szöveg
                    CultureInfo.CurrentUICulture, //Nyelv beálítása
                    FlowDirection.LeftToRight, //Balról-jobbra
                    new Typeface("Serif"), //Betű típusa
                    12.0, //Betű mérete
                    this.Stroke); //Rajzoló ecset
            return Felirat.BuildGeometry(pos);

        }

    protected override Geometry DefiningGeometry
        {
            get
            {
                GeometryGroup gg = new GeometryGroup(); //Összetett alakzathoz használjuk
                gg.Children.Add(RajzolTengelyek()); //Tengelyek
                gg.Children.Add(KiírFelirat(EndX,"x")); //Tengelyfeliratok
                gg.Children.Add(KiírFelirat(new Point(EndY.X-10,EndY.Y-5), "y")); //Tengelyfeliratok
                return gg;
            }
        }

        public KoordinátaTengely(int oxp, int oyp, int xlp, int ylp, string xd, string yd, SolidColorBrush color, Grid gridRef)
        {
            GridRef = gridRef;
            Oxp = oxp;
            Oyp = oyp;
            Xlp = xlp;
            Ylp = ylp;
            Xd = xd;
            Yd = yd;
            this.Stroke = color;
        }
    }
}
