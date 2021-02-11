using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace WPFWindow
{
    class Ház : Shape
    {
        Window Ablak;
        Grid Rács;
        int Magasság { get; set; }
        int Szintek { get; set; }
        int X { get; set; }
        int Y { get; set; }

        protected override Geometry DefiningGeometry
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Ház(int m, int sz, Window a, int x, int y)
        {
            Magasság = m;
            Szintek = sz;
            X = x;
            Y = y;
            Ablak = a;
            Rács = (Grid)Ablak.Content;
            this.RajzBlokkok();
            //Pont p = new Pont(X,Y,1,Brushes.Red,Ablak);
            //p.Rajzol();
        }
        public void RajzBlokkok()
        {
            int x = X;
            int y = Y;
            for (int i = 0; i < Szintek; i++)
            {
                Rectangle r = new Rectangle();
                r.Width = Magasság;
                r.Height = Magasság;
                r.StrokeThickness = 2;
                r.Stroke = Brushes.White;
                r.Margin = new Thickness(x, y, 0, 0);
                Rács.Children.Add(r);
                if (i == 0) Ajtó(x, y);
                else Ablakok(x, y);
                y -= Magasság * 2;

            }
            Tető(x,y);
        }
        public void Ablakok(int x, int y)
        {
            Rectangle r1 = new Rectangle();
            r1.Width = Magasság / 6;
            r1.Height = Magasság / 3;
            r1.StrokeThickness = 2;
            r1.Stroke = Brushes.White;
            r1.Margin = new Thickness(x + Magasság / 6, y, 0, 0);
            Rács.Children.Add(r1);

            Rectangle r2 = new Rectangle();
            r2.Width = Magasság / 6;
            r2.Height = Magasság / 3;
            r2.StrokeThickness = 2;
            r2.Stroke = Brushes.White;
            r2.Margin = new Thickness(x - Magasság / 6, y, 0, 0);
            Rács.Children.Add(r2);
        }
        public void Ajtó(int x, int y)
        {
            Rectangle r = new Rectangle();
            r.Width = Magasság / 3;
            r.Height = (Magasság / 3) * 2;
            r.StrokeThickness = 2;
            r.Stroke = Brushes.White;
            r.Margin = new Thickness(x, y + Magasság /3, 0, 0);
            Rács.Children.Add(r);
        }
        public void Tető(int x, double y)
        {
            Line l1 = new Line();
            int h = (int)Ablak.Height / 2;
            int w = (int)Ablak.Width / 2;
            x += w;
            y += h;
            y += Magasság * Szintek;
            y -= Magasság * 1.5;
            l1.X1 = x - Magasság / 2;
            l1.X2 = x;
            l1.Y1 = y + Magasság * 2;
            l1.Y2 = y + Magasság;
            l1.Stroke = Brushes.White;
            l1.StrokeThickness = 2;

            Line l2 = new Line();
            l2.X1 = x + Magasság / 2;
            l2.X2 = x;
            l2.Y1 = y + Magasság * 2;
            l2.Y2 = y + Magasság;
            l2.Stroke = Brushes.White;
            l2.StrokeThickness = 2;

            Rács.Children.Add(l1);
            Rács.Children.Add(l2);
        }
    }
    class MyWPFWindow
    {
        public Window Ablak { get; set; }
        public Application App { get; set; }
        public Grid Rács { get; set; }

        public MyWPFWindow(int százalék)
        {
            int maxX = (int)SystemParameters.PrimaryScreenWidth;
            int maxY = (int)SystemParameters.PrimaryScreenHeight;
            int winWidth = (int)(maxX * százalék / 100.0);
            int winHeight = (int)(maxY * százalék / 100.0);
            int winLeft = (maxX - winWidth) / 2;
            int winTop = (maxY - winHeight) / 2;

            Ablak = new Window();
            Ablak.Left = winLeft;
            Ablak.Top = winTop;
            Ablak.Width = winWidth;
            Ablak.Height = winHeight;
            Ablak.ResizeMode = ResizeMode.NoResize;
            Ablak.WindowStyle = WindowStyle.None;
            Ablak.Background = Brushes.Black;
            Rács = new Grid();

            Ablak.Content = Rács;
            Ablak.KeyDown += Ablak_KeyDown;
            Ablak.Loaded += Ablak_Loaded;
            App = new Application();
            App.Run(Ablak);

        }
        private void Ablak_Loaded(object sender, RoutedEventArgs e)
        {
            //Pont myPont = new Pont(0, 0, 1, Brushes.Red, Ablak);
            //myPont.Rajzol();
            //Torta t = new Torta(20,5,3,100,10,0,0, Ablak);
            //t.Rajzol(Brushes.Red)
            Ház h = new Ház(50,4,Ablak,0,0);
        }

        private void Ablak_KeyDown(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            switch (e.Key)
            {
                case Key.Escape: Ablak.Close(); break;
            }
        }
    }
}
