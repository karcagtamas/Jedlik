﻿using System;
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
            Ablak.Background = Brushes.CornflowerBlue;
            Rács = new Grid();
            Ablak.Content = Rács;
            Ablak.KeyDown += Ablak_KeyDown;
            Ablak.Loaded += Ablak_Loaded;
            App = new Application();
            App.Run(Ablak);

        }

        private void Ablak_Loaded(object sender, RoutedEventArgs e)
        {
            Pont myPont = new Pont(0, 0, 1, Brushes.Red, Ablak);
            myPont.Rajzol();
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
