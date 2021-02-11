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
        int szög { get; set; }
        int seb = 15;

        public Játék(Window ablak)
        {
            Ablak = ablak;
            Rács = (Grid)Ablak.Content;
            H = (int)Ablak.Height;
            W = (int)Ablak.Width;
            pálya();
            Ablak.KeyDown += Ablak_KeyDown;
            Folyamat();
            this.t = new System.Windows.Threading.DispatcherTimer();
            this.t.Tick += OnTimedEvent;
            this.t.Interval = new TimeSpan(0,0,0,0,10);
            t.IsEnabled = true;
            Random r = new Random();
            szög = r.Next(0, 121) - 60;
            
        }

        private void T_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public void pálya()
        {
            Rectangle r = new Rectangle();
            r.Width = this.W - 40;
            r.Height = this.H - 20;
            r.Stroke = Brushes.Snow;
            r.StrokeThickness = 2;
            Rács.Children.Add(r);
            this.H = (int)r.Height;
            this.W = (int)r.Width;

            Line l = new Line();
            l.X1 = this.W / 2 + 20;
            l.X2 = this.W / 2 + 20;
            l.Y1 = this.H + 10;
            l.Y2 = -this.H - 10;
            l.Stroke = Brushes.Snow;
            l.StrokeThickness = 2;
            Rács.Children.Add(l);

            Ellipse e = new Ellipse();
            e.Height = 150;
            e.Width = 150;
            e.Stroke = Brushes.Snow;
            e.StrokeThickness = 2;
            e.Margin = new Thickness(0, 0, 0, 0);
            Rács.Children.Add(e);

        }
        public void start()
        {

        }
        public void Folyamat()
        {
            Rács.Children.RemoveRange(3, 4);
            Ütő ütő1 = new Ütő();
            ütő1.r = ütő1.Tulajdonsag(ü1X, ü1Y, Brushes.Red,true);
            Ütő ütő2 = new Ütő();
            ütő2.r = ütő2.Tulajdonsag(ü2X, ü2Y, Brushes.Blue, false);
            Labda labda = new Labda();
            labda.e = labda.Tulajdonsag(lX, lY, Brushes.Orange);
            Label l = new Label();
            if (pont1 >= 10) l.Content = pont1.ToString() + "   " + pont2.ToString();
            else l.Content = pont1.ToString() + "     " + pont2.ToString();
            l.FontSize = 50;
            l.Width = 130;
            l.Foreground = Brushes.Snow;
            Rács.Children.Add(ütő1.r);
            Rács.Children.Add(ütő2.r);
            Rács.Children.Add(labda.e);
            Rács.Children.Add(l);

        }
        public bool labdakint(int H, int W)
        {
            int h = this.H;
            int w = this.W;
            if (this.lY < -h || this.lY > h || this.lX < -w || this.lX > w) return true;
            return true;
        }
        public void újlabdaút()
        {
            if (this.irány == 0)
            {
                this.lX += (int)Math.Sqrt(Math.Pow(this.seb, 2) / 2);
                this.lY -= (int)Math.Sqrt(Math.Pow(this.seb, 2) / 2 + this.szög);
            }
            if (this.irány == 1)
            {
                this.lX += (int)Math.Sqrt(Math.Pow(this.seb, 2) / 2);
                this.lY += (int)Math.Sqrt(Math.Pow(this.seb, 2) / 2 + this.szög);
            }
            if (this.irány == 2)
            {
                this.lX -= (int)Math.Sqrt(Math.Pow(this.seb, 2) / 2);
                this.lY += (int)Math.Sqrt(Math.Pow(this.seb, 2) / 2 + this.szög);
            }
            if (this.irány == 3)
            {
                this.lX -= (int)Math.Sqrt(Math.Pow(this.seb, 2) / 2);
                this.lY -= (int)Math.Sqrt(Math.Pow(this.seb, 2) / 2 + this.szög);
            }
        }
        public void Ablak_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    this.Ablak.Close();
                    break;
                case Key.Down:
                    this.ütők(ref this.ü1Y, true, 30); this.Folyamat(); break;
                case Key.Up:
                    this.ütők(ref this.ü1Y, false, 30); this.Folyamat(); break;
            }
        }
        public void ütők(ref int ü, bool felt, int seb)
        {
            if (felt)
            {
                if (ü + 80 + seb > this.H) ü = this.H;
                else ü += seb;
            }
            else
            {
                if (ü - 80 - seb < -this.H) ü = -this.H;
                else ü -= seb;
            }
        }
        public void bot()
        {
            if (this.irány == 2 || this.irány == 3)
            {
                if (this.lY > this.ü2Y) this.ütők(ref this.ü2Y, true, 10);
                if (this.lY < this.ü2Y) this.ütők(ref this.ü2Y, false, 10);
            }
            if (this.irány == 0 || this.irány == 1)
            {
                if (0 > this.ü2Y) this.ütők(ref this.ü2Y, true, 3);
                if (0 < this.ü2Y) this.ütők(ref this.ü2Y, false, 3);
            }
        }
        public void OnTimedEvent(object sender, EventArgs e)
        {
            this.t.IsEnabled = false;
            try
            {
                int h1 = this.H;
                int w1 = this.W;
                if (labdakint(h1, w1))
                {
                    int h = h1;
                    int w = w1;
                    if (this.lY - 25 < -h)
                    {
                        if (this.irány == 0) this.irány = 1;
                        if (this.irány == 3) this.irány = 2;
                    }
                    if (this.lY + 25 > h)
                    {
                        if (this.irány == 1) this.irány = 0;
                        if (this.irány == 2) this.irány = 3;
                    }
                    if (this.lX - 25 < -w)
                    {
                        this.pont2++;
                        this.lX = 0;
                        this.lY = 0;
                        this.ü1Y = 0;
                        this.ü2Y = 0;
                        Random r = new Random();
                        irány = r.Next(0, 2);
                    }
                    if (this.lX + 25 > w)
                    {
                        this.pont1++;
                        this.lX = 0;
                        this.lY = 0;
                        this.ü1Y = 0;
                        this.ü2Y = 0;
                        Random r = new Random();
                        irány = r.Next(2, 4);

                    }
                    if (this.lX + 25 >= this.ü1X - 60 && this.lX - 25 <= this.ü1X + 60 && this.lY + 25 <= this.ü1Y + 160 && this.lY - 25 >= this.ü1Y - 160)
                    {
                        if (this.irány == 0) this.irány = 3;
                        if (this.irány == 1) this.irány = 2;
                    }
                    if (this.lX - 25 <= this.ü2X + 60 && this.lX + 25 >= this.ü2X - 60 && this.lY + 25 <= this.ü2Y + 160 && this.lY - 25 >= this.ü2Y - 160)
                    {
                        if (this.irány == 3) this.irány = 0;
                        if (this.irány == 2) this.irány = 1;
                    }
                }
                this.újlabdaút();
                this.bot();
                this.Folyamat();
            }
            catch { }
            this.t.IsEnabled = true;
        }
    }
}
