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
        private int R { get; set; }
        public Kör(int x, int y, int ssz, int r, SolidColorBrush szín, Window ablak, KoordinátaTengely kt) : base(x, y, ssz, szín, ablak, kt)
        {
            R = r;
        }
        protected override Geometry Rajzol()
        {
            GeometryGroup gg = new GeometryGroup();
            EllipseGeometry eg = new EllipseGeometry(new Point(X+deltaX,-Y+deltaY), R, R);
            eg.Freeze();
            gg.Children.Add(eg);

            
            gg.Children.Add(base.Rajzol());
            gg.Freeze();

            return gg;
        }
    }
}
