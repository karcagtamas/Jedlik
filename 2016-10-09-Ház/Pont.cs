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
    class Pont : Shape
    {
        public int X { get; set; }
        public int Y { get; set; }

        public SolidColorBrush Szín { get; set; }
        public int Ssz { get; set; }

        private Window Ablak;
        private Grid Rács;

        public Pont(int x, int y, int ssz, SolidColorBrush szin, Window ablak)
        {
            X = x;
            Y = y;
            Ssz = ssz;
            Szín = szin;
            Ablak = ablak;
            Rács = (Grid)ablak.Content;

        }

        public bool Rajzolhatoe
        {
            get
            {
                if (X > -Ablak.Width / 2 && X < Ablak.Width / 2 && Y > -Ablak.Height / 2 && Y < Ablak.Height / 2) return true;
                else return false;
            }
        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Rajzol()
        {
            if (Rajzolhatoe)
            {
                double w = Ablak.Width / 2;
                double h = Ablak.Height / 2;
                Line l1 = new Line();
                l1.X1 = X - 10 + w;
                l1.Y1 = Y - 10 + h;
                l1.X2 = X + 10 + w;
                l1.Y2 = Y + 10 + h;
                l1.StrokeThickness = 5;
                l1.Stroke = Szín;

                Rács.Children.Add(l1);

                Line l2 = new Line();
                l2.X1 = X + 10 + w;
                l2.Y1 = Y - 10 + h;
                l2.X2 = X - 10 + w;
                l2.Y2 = Y + 10 + h;
                l2.StrokeThickness = 5;
                l2.Stroke = Szín;

                Rács.Children.Add(l2);
                return true;
            }
            else return false;
        }
    }
}
//kiirás