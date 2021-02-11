using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Globalization;

namespace WPFalkalmazás
{
    class MyTéglalap : Shape
    {
        public MyPont P1 { get; private set; } //bal felső
        public MyPont P2 { get; private set; } //jobb alsó
        public int Ssz { get; private set; } //sorszám

        public MyTéglalap(MyPont p1, MyPont p2, Brush szín, int ssz)
        {
            if (p1.X == p2.X || p1.Y == p2.Y)
                throw new Exception("Nem értelmezhető a téglalap!");
            P1 = new MyPont(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y), szín, ssz);
            P2 = new MyPont(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y), szín, ssz);
            Ssz = ssz;
            Stroke = szín;
            StrokeThickness = 1;
        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                Point p1 = new Point(P1.X, P1.Y); //MyPont -> Point
                Point p2 = new Point(P2.X, P2.Y); //MyPont -> Point
                RectangleGeometry rg = new RectangleGeometry(new Rect(p1, p2));
                return rg;
            }
        }
    }
}
