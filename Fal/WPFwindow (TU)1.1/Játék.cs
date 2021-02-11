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
    class Játék : Shape
    {
        protected override Geometry DefiningGeometry
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        Window Ablak;
        Grid Rács;
        int ü1X = 1000;
        int ü1Y = 0;
        int ü2X = -1000;
        int ü2Y = 0;
        int lX = 0;
        int lY = 0;

        public Játék(Window ablak)
        {
            Ablak = ablak;
            Rács = (Grid)Ablak.Content;
            Ablak.KeyDown += Ablak_KeyDown;
            Folyamat();
        }
        private void Folyamat()
        {
            Rács.Children.RemoveRange(1, 2);
            Rács.Children.RemoveRange(1, 2);
            Ütő ütő1 = new Ütő();
            ütő1.r = ütő1.Tulajdonsag(ü1X,ü1Y,Brushes.Red);
            Ütő ütő2 = new Ütő();
            ütő2.r = ütő2.Tulajdonsag(ü2X, ü2Y, Brushes.Blue);
            Labda labda = new Labda();
            labda.e = labda.Tulajdonsag(lX, lY, Brushes.Orange);
            Rács.Children.Add(labda.e);
            Rács.Children.Add(ütő1.r);
            Rács.Children.Add(ütő2.r);
        }
        private void Ablak_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    Ablak.Close();
                    break;
                    case Key.Down:
                        ü1Y += 20;  Folyamat(); break;
                    case Key.Up:
                        ü1Y -= 20;  Folyamat(); break;
                    //case Key.W:
                    //    Billentyű2(e.Key); break;
                    //case Key.S:
                    //    Billentyű2(e.Key); break;
            }
        }
    }
}
