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
using System.Threading;
using System.Timers;


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
        int pont1 = 0;
        int pont2 = 0;
        System.Windows.Threading.DispatcherTimer t;
        int H { get; set; }
        int W { get; set; }

        int irány = 0;
        //int szög = 45;
        int seb = 10;

        public Játék(Window ablak)
        {
            Ablak = ablak;
            Rács = (Grid)Ablak.Content;
            Ablak.KeyDown += Ablak_KeyDown;
            Folyamat();
            this.t = new System.Windows.Threading.DispatcherTimer();
            this.t.Tick += OnTimedEvent;
            this.t.Interval = new TimeSpan(0,0,0,0,10);
            t.IsEnabled = true;
            H = (int)Ablak.Height;
            W = (int)Ablak.Width;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Folyamat()
        {
            Rács.Children.RemoveRange(0, 3);
            Ütő ütő1 = new Ütő();
            ütő1.r = ütő1.Tulajdonsag(ü1X, ü1Y, Brushes.Red);
            Ütő ütő2 = new Ütő();
            ütő2.r = ütő2.Tulajdonsag(ü2X, ü2Y, Brushes.Blue);
            Labda labda = new Labda();
            labda.e = labda.Tulajdonsag(lX, lY, Brushes.Orange);
            //Label l = new Label();
            //l.Content = pont2.ToString() + " : " + pont1.ToString();
            //l.Margin = new Thickness(0, 0, 0, 0);
            //l.FontSize = 5;
            //l.Foreground = Brushes.Snow;
            Rács.Children.Add(ütő1.r);
            Rács.Children.Add(ütő2.r);
            Rács.Children.Add(labda.e);
            //Rács.Children.Add(l);

        }
        public void Mozgás()
        {
            //Thread.Sleep(1000);
            //labdaút();
            Folyamat();
            //Mozgás();
        }
        public void labdaút()
        {
            if (labdakint((int)Ablak.Height / 2, (int)Ablak.Width / 2))
            {
                int h = (int)Ablak.Height;
                int w = (int)Ablak.Width;
                if (lY < -h)
                {
                    if (irány == 0) irány = 1;
                    if (irány == 3) irány = 2;
                }
                if (lY > h)
                {
                    if (irány == 1) irány = 0;
                    if (irány == 2) irány = 3;
                }
                if (lX < -w)
                {
                    pont2++;
                    lX = 0;
                    lY = 0;
                }
                if (lX > w)
                {
                    pont1++;
                    lX = 0;
                    lY = 0;
                }
                if (lX + 15 > ü1X - 20 && lY + 15 < ü1Y + 80 && lY - 15 > ü1Y - 80)
                {
                    if (irány == 0) irány = 2;
                    if (irány == 1) irány = 3;
                }
                if (lX - 15 > ü1X + 20 && lY + 15 < ü1Y + 80 && lY - 15 > ü1Y - 80)
                {
                    if (irány == 2) irány = 0;
                    if (irány == 3) irány = 1;
                }
            }
            újlabdaút();
        }
        public bool labdakint(int H, int W)
        {
            int h = H;
            int w = W;
            if (lY < -h || lY > h || lX < -w || lX > w) return true;
            return true;
        }
        public void újlabdaút()
        {
            if (irány == 0)
            {
                lX += (int)Math.Sqrt(Math.Pow(seb, 2) / 2);
                lY -= (int)Math.Sqrt(Math.Pow(seb, 2) / 2);
            }
            if (irány == 1)
            {
                lX += (int)Math.Sqrt(Math.Pow(seb, 2) / 2);
                lY += (int)Math.Sqrt(Math.Pow(seb, 2) / 2);
            }
            if (irány == 2)
            {
                lX -= (int)Math.Sqrt(Math.Pow(seb, 2) / 2);
                lY += (int)Math.Sqrt(Math.Pow(seb, 2) / 2);
            }
            if (irány == 3)
            {
                lX -= (int)Math.Sqrt(Math.Pow(seb, 2) / 2);
                lY -= (int)Math.Sqrt(Math.Pow(seb, 2) / 2);
            }
        }
        public void Ablak_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    Ablak.Close();
                    break;
                case Key.Down:
                    ü1Y += 20; Folyamat(); break;
                case Key.Up:
                    ü1Y -= 20; Folyamat(); break;
                    //case Key.Space:
                    //    Mozgás(); break;
                    //case Key.W:
                    //    Billentyű2(e.Key); break;
                    //case Key.S:
                    //    Billentyű2(e.Key); break;
            }
        }
        public void OnTimedEvent(object sender, EventArgs e)
        {
            this.t.IsEnabled = false;
            try
            {
                int h1 = H;
                int w1 = W;
                if (labdakint(h1, w1))
                {
                    int h = h1;
                    int w = w1;
                    if (lY < -h)
                    {
                        if (irány == 0) irány = 1;
                        if (irány == 3) irány = 2;
                    }
                    if (lY > h)
                    {
                        if (irány == 1) irány = 0;
                        if (irány == 2) irány = 3;
                    }
                    if (lX < -w)
                    {
                        pont2++;
                        lX = 0;
                        lY = 0;
                    }
                    if (lX > w)
                    {
                        pont1++;
                        lX = 0;
                        lY = 0;
                    }
                    if (lX + 15 > ü1X - 20 && lY + 15 < ü1Y + 80 && lY - 15 > ü1Y - 80)
                    {
                        if (irány == 0) irány = 2;
                        if (irány == 1) irány = 3;
                    }
                    if (lX - 15 > ü1X + 20 && lY + 15 < ü1Y + 80 && lY - 15 > ü1Y - 80)
                    {
                        if (irány == 2) irány = 0;
                        if (irány == 3) irány = 1;
                    }
                }
                újlabdaút();
                //Rács.Children.RemoveAt(2);
                //Labda labda = new Labda();
                //labda.e = labda.Tulajdonsag(lX, lY, Brushes.Orange);
                //Rács.Children.Add(labda.e);
                Folyamat();
            }
            catch { }
            this.t.IsEnabled = true; 
        }
    }
}
