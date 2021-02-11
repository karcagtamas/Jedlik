using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Globalization;

namespace WPFalkalmazás
{
    class MyPont : Shape
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Ssz { get; private set; }
        public Brush Szín { get; private set; }

        public MyPont(int x, int y, Brush szín, int ssz)
        {
            Ssz = ssz;
            X = x;
            Y = y;
            Szín = szín;
            Stroke = Szín;
            StrokeThickness = 1;
        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                GeometryGroup gg = new GeometryGroup();

                //Kereszt: 
                LineGeometry l1 = new LineGeometry();
                l1.StartPoint = new Point(X - 5, Y - 5);
                l1.EndPoint = new Point(X + 5, Y + 5);
                gg.Children.Add(l1);
                LineGeometry l2 = new LineGeometry();
                l2.StartPoint = new Point(X - 5, Y + 5);
                l2.EndPoint = new Point(X + 5, Y - 5);
                gg.Children.Add(l2);

                //Sorszám:
                FormattedText ft = new FormattedText(
                    Ssz.ToString(), //Kiirandó szöveg
                    CultureInfo.CurrentUICulture, //nyelv
                    FlowDirection.LeftToRight, //írás iránya
                    new Typeface("Arial"), //betűtípus
                    10.0, //betű mérete
                    Brushes.Black); //betű színe
                Geometry gssz = ft.BuildGeometry(new Point(X+5, Y+5));
                gg.Children.Add(gssz);

                return gg;
            }
        }
    }
}
