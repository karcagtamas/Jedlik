using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aknakereső
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button[,] M = new Button[15, 20];
        private int[,] AknaKereső = new int[15, 20];

        public MainWindow()
        {
            InitializeComponent();
            this.Terület.Rows = 15;
            this.Terület.Columns = 20;
            Random r = new Random();
            for (int i = 0; i < this.Terület.Rows; i++)
            {
                for (int j = 0; j < this.Terület.Columns; j++)
                {
                    if (r.Next(100) > 90) AknaKereső[i, j] = 1;
                    else AknaKereső[i, j] = 0;
                }
            }
        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            this.Terület.Children.Clear();
            
            for (int sor = 0; sor < this.Terület.Rows ; sor++)
            {
                for (int oszlop = 0; oszlop < this.Terület.Columns; oszlop++)
                {
                    Button b = new Button();
                    b.Click += Katt;
                    b.MouseRightButtonDown += ZászlóKlikk;
                    b.Tag = sor * this.Terület.Columns + oszlop;
                    
                    this.M[sor, oszlop] = b;
                    this.Terület.Children.Add(b);
                }
            }
        }

        private void ZászlóKlikk(object sender, MouseButtonEventArgs e)
        {
            Button gomb = sender as Button;
            //gomb.Background = Brushes.Pink;
            //gomb.IsEnabled = false;
        }

        private void Katt(object sender, RoutedEventArgs e)
        {
            Button gomb = sender as Button;
            gomb.Background = Brushes.Pink;
            gomb.IsEnabled = false;

            int sor = (int)(gomb.Tag) / this.Terület.Columns;
            int oszlop = (int)(gomb.Tag) % this.Terület.Columns;
            if (this.AknaKereső[sor, oszlop] != 1)
            {

                List<Button> környezet = new List<Button>();
                if (sor > 0 && oszlop > 0) környezet.Add(M[sor - 1, oszlop - 1]);
                if (sor > 0) környezet.Add(M[sor - 1, oszlop]);
                if (sor > 0 && oszlop < this.Terület.Columns - 1) környezet.Add(M[sor - 1, oszlop + 1]);
                if (oszlop > 0) környezet.Add(M[sor, oszlop - 1]);
                if (oszlop < this.Terület.Columns - 1) környezet.Add(M[sor, oszlop + 1]);
                if (sor < this.Terület.Rows - 1 && oszlop > 0) környezet.Add(M[sor + 1, oszlop - 1]);
                if (sor < this.Terület.Rows - 1) környezet.Add(M[sor + 1, oszlop]);
                if (sor < this.Terület.Rows - 1 && oszlop < this.Terület.Columns - 1) környezet.Add(M[sor + 1, oszlop + 1]);

                int aknákszáma = 0;

                foreach (var i in környezet)
                {
                    int sor2 = (int)(i.Tag) / this.Terület.Columns;
                    int oszlop2 = (int)(i.Tag) % this.Terület.Columns;
                    if (AknaKereső[sor2, oszlop2] == 1)
                    {
                        aknákszáma++;
                    }
                }
                if (aknákszáma != 0) gomb.Content = aknákszáma;
                foreach (var i in környezet)
                {
                    if (aknákszáma == 0)
                    {
                        if (i.IsEnabled)
                            this.Katt(i, new RoutedEventArgs());
                    }
                }
            }
            else
            {
                MessageBox.Show("Meghaltál!");
                this.Gomb_Click(Gomb, new RoutedEventArgs());
            }



            //MessageBox.Show(sor + "-" + oszlop);
            //MessageBox.Show(gomb.Tag.ToString());
        }
    }
}
