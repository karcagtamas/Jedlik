using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Globalization;
using System;

namespace WPFalkalmazás
{
    class MyCsillag : Shape
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Ssz { get; private set; }
        public Brush Szín { get; private set; }
        public int N { get; private set; } //csúcsok száma
        public int R1 { get; private set; }
        public int R2 { get; private set; }

        public MyCsillag(int x, int y, Brush szín, int ssz, int n, int r1, int r2)
        {
            Ssz = ssz;
            X = x;
            Y = y;
            Szín = szín;
            Stroke = Szín;
            StrokeThickness = 1;
            N = n;
            R1 = r1;
            R2 = r2;
        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                PathFigure pf = new PathFigure();
                pf.StartPoint = new Point(X, Y - R2); //első külső csúcs
                double Alfa = 2 * Math.PI / N;
                double AlfaFél = Alfa / 2;
                
                for (int i = 1; i <= N; i++)
                {
                    Point iCsúcsB = new Point(); 
                    iCsúcsB.X = X + R1 * Math.Sin(i * Alfa - AlfaFél);
                    iCsúcsB.Y = Y - R1 * Math.Cos(i * Alfa - AlfaFél);
                    pf.Segments.Add(new LineSegment(iCsúcsB, true));

                    Point iCsúcsK = new Point();
                    iCsúcsK.X = X + R2 * Math.Sin(i * Alfa);
                    iCsúcsK.Y = Y - R2 * Math.Cos(i * Alfa);
                    pf.Segments.Add(new LineSegment(iCsúcsK, true));
                }

                PathGeometry geom = new PathGeometry();
                geom.Figures.Add(pf);
                geom.Freeze();
                return geom;
            }
        }

    }
}
