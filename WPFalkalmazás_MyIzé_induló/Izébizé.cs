using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Globalization;
using System.Windows.Shapes;

namespace WPFalkalmazás
{
    class Izébizé : Shape
    {
            
            public int Ssz { get; set; }
            public int R { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            private Canvas C;

            protected override Geometry DefiningGeometry
            {
                get
                {
                    GeometryGroup geo = new GeometryGroup();
                    PathFigure path = new PathFigure();
                    path.StartPoint = new Point(X, (Y - R));

                    double n = 0.78539816339744828;

                    for (int i = 1; i <= 4; i++)
                    {
                        Point pont = default(Point);
                        pont.X = X + R * Math.Sin(i * n);
                        pont.Y = Y - R * Math.Cos(i * n);
                        path.Segments.Add(new LineSegment(pont, true));
                    }

                    path.Segments.Add(new LineSegment(new Point((X - R), (Y + R)), true));
                    path.Segments.Add(new LineSegment(new Point((X - R), (Y - R)), true));
                    path.Segments.Add(new LineSegment(new Point(X, (Y - R)), true));

                    PathGeometry pgeo = new PathGeometry();
                    pgeo.Figures.Add(path);
                    pgeo.Freeze();

                    geo.Children.Add(pgeo);

                    EllipseGeometry e1 = new EllipseGeometry(new Point(X, Y), 3, 3);
                    geo.Children.Add(e1);

                    EllipseGeometry e2 = new EllipseGeometry(new Point(X, Y), R, R);
                    geo.Children.Add(e2);

                    FormattedText formattedText = new FormattedText(Ssz.ToString(), CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, new Typeface("Tahoma"), 70.0, Brushes.Beige);
                    Geometry e3 = formattedText.BuildGeometry(new Point(X - formattedText.Width / 2, Y - formattedText.Height / 2));

                    geo.Children.Add(e3);

                    return geo;
                }
            }
            public Izébizé(int x, int y, Brush szín, int ssz, int r, Canvas c)
            {
                Ssz = ssz;
                X = x;
                Y = y;
                Stroke = szín;
                StrokeThickness = 1;
                R = r;
                C = c;
            }
            public void Mozgat(int dx, int dy)
            {
                int z = X + dx;
                int z2 = Y + dy;
                bool feltétel = z >= R && z2 >= R && z <= C.ActualWidth - R && z2 <= C.ActualHeight - R;
                if (feltétel)
                {
                    this.X = z;
                    this.Y = z2;
                }
            }
        }
    }