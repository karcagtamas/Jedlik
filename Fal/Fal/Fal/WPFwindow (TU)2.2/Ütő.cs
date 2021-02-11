using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
        public Rectangle Tulajdonsag(int X, int Y, SolidColorBrush B,bool felt)
        {
            r = new Rectangle();
            r.Height = 160;
            r.Width = 60;
            //r.Fill = Brushes.Snow;
            r.Stroke = B;
            r.StrokeThickness = 3;
            r.Margin = new Thickness(X, Y, 0, 0);
            if (felt) r.Fill = new ImageBrush(new BitmapImage(new Uri(@"F:\Fal\WPFwindow (TU)2.2\bin\Debug\vader.jpg")));
            else r.Fill = new ImageBrush(new BitmapImage(new Uri(@"F:\Fal\WPFwindow (TU)2.2\bin\Debug\emperor.jpg")));

            return r;
        }
    }
}
