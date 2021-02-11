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

        int ü1X = 1000; //Bal oldali ütő X koordináta
        int ü1Y = 0; //Bal oldali ütő Y koordináta
        int ü2X = -1000; //Jobb oldali ütő X koordináta
        int ü2Y = 0; //Jobb oldali ütő Y koordináta
        int lX = 0; //Labda X koordináta
        int lY = 0; //Labda Y koordináta

        int pont1 = 0; //Bal oldali játékos pont száma
        int pont2 = 0; //Jobb oldali játékos pont száma

        System.Windows.Threading.DispatcherTimer t; //Timer a labda mozgásához

        int H { get; set; } //Pálya magasság
        int W { get; set; } //Pálya szélesség 

        int irány = 0; //Labda iránya (0-jobbfel, 1-jobble, 2-balle, 3-balfel)
        int szög { get; set; } //Visszaütődés szöge
        int seb = 15; //Labda sebessége

        public Játék(Window ablak)
        {
            Ablak = ablak;
            Rács = (Grid)Ablak.Content;
            H = (int)Ablak.Height;
            W = (int)Ablak.Width;
            pálya();
            Ablak.KeyDown += Ablak_KeyDown; //Gomb figyelés
            Folyamat();
            this.t = new System.Windows.Threading.DispatcherTimer(); //Timer
            this.t.Tick += OnTimedEvent; //Timer esemény hozzáadása
            this.t.Interval = new TimeSpan(0,0,0,0,10); //Timer idő intervallum
            this.t.IsEnabled = false; //Timer leállítása
            Random r = new Random();
            szög = r.Next(0, 121) - 60;
            
        }
        private void T_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public void pálya() //Pálya legenerálása
        {
            Rectangle r = new Rectangle(); //Külső keret
            r.Width = this.W - 40;
            r.Height = this.H - 20;
            r.Stroke = Brushes.Snow;
            r.StrokeThickness = 2;
            Rács.Children.Add(r);
            this.H = (int)r.Height;
            this.W = (int)r.Width;
            ü1X = W - 160;
            ü2X = -W + 160;


            Line l = new Line(); //Térfél elválasztó vonal
            l.X1 = this.W / 2 + 20;
            l.X2 = this.W / 2 + 20;
            l.Y1 = this.H + 10;
            l.Y2 = -this.H - 10;
            l.Stroke = Brushes.Snow;
            l.StrokeThickness = 2;
            Rács.Children.Add(l);

            Ellipse e = new Ellipse(); //Középső kör
            e.Height = 150;
            e.Width = 150;
            e.Stroke = Brushes.Snow;
            e.StrokeThickness = 2;
            e.Margin = new Thickness(0, 0, 0, 0);
            Rács.Children.Add(e);

        }
        public void start() //Timer inditás
        {
            this.ThemeSong();
            t.IsEnabled = true;
        }
        public void Folyamat()
        {
            Rács.Children.RemoveRange(3, 4);
            Ütő ütő1 = new Ütő(); //Ütők
            ütő1.r = ütő1.Tulajdonsag(ü1X, ü1Y, Brushes.Red, true);
            Ütő ütő2 = new Ütő();
            ütő2.r = ütő2.Tulajdonsag(ü2X, ü2Y, Brushes.Blue, false);

            Labda labda = new Labda(); //Labda
            labda.e = labda.Tulajdonsag(lX, lY, Brushes.Orange);

            Label l = new Label(); //Pontokat kiiró szövegdoboz
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
        public bool labdakint(int H, int W) //Labda figyelés
        {
            int h = this.H;
            int w = this.W;
            if (this.lY - 25 < -h || this.lY + 25 > h || this.lX - 25 < -w || this.lX + 25 > w) return true;
            return true;
        }
        public void újlabdaút() //Labdának az új X és Y koorsinátáinak meghatározás
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
        public void Ablak_KeyDown(object sender, KeyEventArgs e) //Billentyűk figyelése
        {
            switch (e.Key)
            {
                case Key.Escape:
                    this.Ablak.Close(); break; //Kilépés
                case Key.Down:
                    this.ütők(ref this.ü1Y, true, 25); this.Folyamat(); break; //Ütő mozgása lefele
                case Key.Up:
                    this.ütők(ref this.ü1Y, false, 25); this.Folyamat(); break; //Ütő mozgása felfele
                case Key.Space:
                    if (!t.IsEnabled) this.start(); break; //Játék kezdete
            }
        }
        public void ütők(ref int ü, bool felt, int seb) //Ütő mozgatása
        {
            if (felt)
            {
                if (ü + seb > this.H) ü = this.H; //felfele
                else ü += seb;
            }
            else
            {
                if (ü - seb < -this.H) ü = -this.H; //lefele
                else ü -= seb;
            }
        }
        public void bot() //Robot mozgásának meghatározása
        {
            if (this.irány == 2 || this.irány == 3)
            {
                if (this.lY > this.ü2Y) this.ütők(ref this.ü2Y, true, 8);
                if (this.lY < this.ü2Y) this.ütők(ref this.ü2Y, false, 8);
            }
            if (this.irány == 0 || this.irány == 1)
            {
                if (0 > this.ü2Y) this.ütők(ref this.ü2Y, true, 3);
                if (0 < this.ü2Y) this.ütők(ref this.ü2Y, false, 3);
            }
        }
        public void OnTimedEvent(object sender, EventArgs e)
        {
            
            this.t.IsEnabled = false; //Timer leállítása
            try
            {
                int h = this.H;
                int w = this.W;
                bool felt1 = true;
                bool felt2 = true;

                if (labdakint(h, w))
                {
                    if (this.lY - 25 < -h) //Ha lefele kimegy
                    {
                        if (this.irány == 0) this.irány = 1;
                        if (this.irány == 3) this.irány = 2;
                    }
                    if (this.lY + 25 > h) //Ha felfele kimegy
                    {
                        if (this.irány == 1) this.irány = 0;
                        if (this.irány == 2) this.irány = 3;
                    }
                    if (this.lX - 25 < -w) //Ha balra kimegy
                    {
                        this.pont2++;
                        this.lX = 0;
                        this.lY = 0;
                        this.ü1Y = 0;
                        this.ü2Y = 0;
                        Random r = new Random();
                        irány = r.Next(0, 2);
                    }
                    if (this.lX + 25 > w) //Ha jobbra kimegy
                    {
                        this.pont1++;
                        this.lX = 0;
                        this.lY = 0;
                        this.ü1Y = 0;
                        this.ü2Y = 0;
                        Random r = new Random();
                        irány = r.Next(2, 4);

                    }
                    if (this.lX + 15 < this.ü1X - 60 && this.lX - 15 > this.ü2X + 60) { felt1 = true; felt2 = true; } //Ha a két ütő között van
                    if (this.lX + 25 >= this.ü1X - 60 && this.lX - 25 <= this.ü1X + 60 && this.lY + 25 > this.ü1Y + 160 && this.lY - 25 < this.ü1Y - 160) felt1 = false; //Ha a baloldali ütő felett vagy alatt van
                    if (this.lX - 25 <= this.ü2X + 60 && this.lX + 25 >= this.ü2X - 60 && this.lY + 25 > this.ü2Y + 160 && this.lY - 25 < this.ü2Y - 160) felt2 = false; //Ha a jobboldali ütő felett vagy alatt van
                    if (felt1)
                    {
                        if (this.lX + 25 >= this.ü1X - 60 && this.lX - 25 <= this.ü1X + 60 && this.lY + 25 <= this.ü1Y + 160 && this.lY - 25 >= this.ü1Y - 160) //Ha érinti a baloldai ütőt
                        {
                                if (this.irány == 0) this.irány = 3;
                                if (this.irány == 1) this.irány = 2;
                        }
                    }
                    if (felt2)
                    {
                        if (this.lX - 25 <= this.ü2X + 60 && this.lX + 25 >= this.ü2X - 60 && this.lY + 25 <= this.ü2Y + 160 && this.lY - 25 >= this.ü2Y - 160) //Ha érinti a jobb oldali ütőt
                        {
                            if (this.irány == 3) this.irány = 0;
                            if (this.irány == 2) this.irány = 1;
                        }
                    }
                    
                }
                this.újlabdaút();
                this.bot();
                this.Folyamat();
            }
            catch { }
            this.t.IsEnabled = true; //Timer elinditása
        }
        public void ThemeSong()
        {
                Console.Beep(440, 500);
                Console.Beep(440, 500);
                Console.Beep(440, 500);
                Console.Beep(349, 350);
                Console.Beep(523, 150);
                Console.Beep(440, 500);
                Console.Beep(349, 350);
                Console.Beep(523, 150);
                Console.Beep(440, 1000);
                Console.Beep(659, 500);
                Console.Beep(659, 500);
                Console.Beep(659, 500);
                Console.Beep(698, 350);
                Console.Beep(523, 150);
                Console.Beep(415, 500);
                Console.Beep(349, 350);
                Console.Beep(523, 150);
                Console.Beep(440, 1000);
         }
    }
}

