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


namespace WPFwindow
{
    class MyWpfWindow
    {
        public Window Ablak { get; set; }
        public Application App { get; set; }
        public Grid Rács { get; set; }

        int Z1 = 0;
        int Z2 = 0;
        public MyWpfWindow(int százalék)
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
            Ablak.Background = Brushes.White;
            Rács = new Grid();
            Ablak.Content = Rács;
            Ablak.KeyDown += Ablak_KeyDown;
            Ablak.Loaded += Ablak_Loaded;
            App = new Application();
            App.Run(Ablak);
        }

        private void Ablak_Loaded(object sender, RoutedEventArgs e)
        {
            /*KoordinátaTengely kt = new KoordinátaTengely(50, 50, 100, 100, "x", "y", Brushes.White, Rács);
            Pont myPont = new Pont(-10, -10, 1, Brushes.Red, Ablak, kt);
            Rács.Children.Add(kt);
            Rács.Children.Add(myPont);
            Kör MyKör = new Kör(20,20,2,100, Brushes.OrangeRed, Ablak, kt);
            Rács.Children.Add(MyKör);*/

            Ütő ü1 = new Ütő(Ablak, Brushes.Cyan, 500, 0);
            Ütő ü2 = new Ütő(Ablak, Brushes.Red, -500, 0);
            //Rács.Children.RemoveRange(0,2);
        }
        private void Ütő()
        {
            Rács.Children.RemoveRange(0, 2);
            Ütő ü1 = new Ütő(Ablak, Brushes.Cyan, 500, Z1);
            Ütő ü2 = new Ütő(Ablak, Brushes.Red, -500, Z2);
        }
        private void Billentyű1(Key c)
        {
            if (c == Key.Down)
            {
                Z1 += 40;
            }
            if (c == Key.Up)
            {
                Z1 -= 40;
            }
            Ütő();
        }
        private void Billentyű2(Key c)
        {
            if (c == Key.S)
            {
                Z2 += 40;
            }
            if (c == Key.W)
            {
                Z2 -= 40;
            }
            Ütő();
        }
        private void Ablak_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    Ablak.Close();
                    break;
                case Key.Down:
                    Billentyű1(e.Key); break;
                case Key.Up:
                    Billentyű1(e.Key); break;
                case Key.W:
                    Billentyű2(e.Key); break;
                case Key.S:
                    Billentyű2(e.Key); break;
            }
        }
    }
}
