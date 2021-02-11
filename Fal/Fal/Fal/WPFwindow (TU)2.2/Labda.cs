using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFwindow
{
    class Labda : Shape
    {
        public Ellipse e;
    
        protected override Geometry DefiningGeometry
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Ellipse Tulajdonsag(int X, int Y, SolidColorBrush B)
        {
            e = new Ellipse();
            e.Height = 50;
            e.Width = 50;
            //e.Fill = Brushes.Snow;
            e.Stroke = B;
            e.StrokeThickness = 0;
            e.Margin = new Thickness(X, Y, 0, 0);
            e.Fill = new ImageBrush(new BitmapImage(new Uri(@"F:\Fal\WPFwindow (TU)2.2\bin\Debug\ball.png")));
            return e;
        }
    }

}
