using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Threading;

namespace WPFalkalmazás
{
    class MyWpfApplication : Application
    {
        private Window Ablak;
        private Canvas Canv;
        private DispatcherTimer Timer;
        private Random R;
        public MyWpfApplication()
        {
            Ablak = new Window();
            Ablak.Title = "IzéBizé";
            Ablak.KeyDown += new KeyEventHandler(Ablak_KeyDown);
            Ablak.Loaded += new RoutedEventHandler(Ablak_Loaded);
            Ablak.MouseDown += new MouseButtonEventHandler(Ablak_MouseDown);
            Ablak.Background = Brushes.Aquamarine;
            Ablak.WindowStyle = WindowStyle.None;
            Ablak.ResizeMode = ResizeMode.NoResize;
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            Canv = new Canvas();
            Ablak.Content = Canv;
            R = new Random();
            base.Run(Ablak);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (object current in Canv.Children)
            {
                Izébizé IB = current as Izébizé;
                IB.Mozgat(R.Next(-10, 12), R.Next(-10, 12));
                IB.InvalidateVisual();
            }
        }
        private void Ablak_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 100; i <= 109; i++)
            {
                int n = R.Next(60, 120);
                Izébizé IB = new Izébizé(n + R.Next(0, (int)Canv.ActualWidth - 2 * n), n + R.Next(0, (int)Canv.ActualHeight - 2 * n), Brushes.Red, i, n, Canv);
                Canv.Children.Add(IB);
            }
            Timer.Start();
        }
        private void Ablak_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }
        private void Ablak_KeyDown(object sender, KeyEventArgs e)
        {
            bool feltétel = e.Key == Key.Escape;
            if (feltétel) Ablak.Close();
        }
    }
}
