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
        Rectangle r;
        Window Ablak;
        Grid Rács;
        SolidColorBrush B { get; set; }
        int X { get; set; }
        int Y { get; set; }

        protected override Geometry DefiningGeometry
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Ütő(Window ablak,SolidColorBrush b, int sx, int sy)
        {
            Ablak = ablak;
            Rács = (Grid)Ablak.Content;
            r = new Rectangle();
            B = b;
            X = sx;
            Y = sy;
            this.Tulajdonsag();
            Rács.Children.Add(r);
        }
        public void Tulajdonsag()
        {
            r.Height = 160;
            r.Width =30;
            r.Fill = B;
            r.Stroke = r.Fill;
            r.Margin = new Thickness(X, Y, 0, 0);
        }
    }
}
