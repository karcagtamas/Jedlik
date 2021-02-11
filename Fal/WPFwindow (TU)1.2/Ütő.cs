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
    class Ütő : Shape
    {
        public Rectangle r;
        protected override Geometry DefiningGeometry
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public Rectangle Tulajdonsag(int X, int Y, SolidColorBrush B)
        {
            r = new Rectangle();
            r.Height = 160;
            r.Width = 30;
            r.Fill = Brushes.Snow;
            r.Stroke = B;
            r.StrokeThickness = 2;
            r.Margin = new Thickness(X, Y, 0, 0);
            return r;
        }
    }
}
