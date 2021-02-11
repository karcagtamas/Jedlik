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

namespace Számológép
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string X { get; set; }
        List<string> l = new List<string>();
        int Művelet { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Művelet = -1;
            X = "0";
        }
        private void Szám_Click(object sender, RoutedEventArgs e)
        {
            Button Gomb = (Button)sender;
            //MessageBox.Show((string)Gomb.Content);
            string text = (string)Gomb.Content;
            if (X == "0") X = text;
            else
            {
                bool feltétel = true;

                if (text == "," && X.Contains(",")) feltétel = false;
                if (feltétel) X += text;
            }
            if (X == ",") X = "0,";
            Label.Content = X;
        }
        private void Művelet_Click(object sender, RoutedEventArgs e)
        {
            Button Gomb = (Button)sender;
            //MessageBox.Show((string)Gomb.Content);
            string text = (string)Gomb.Content;
            if (Művelet != -1)
            {
                X = Mű(l[l.Count - 1], X);
                Label.Content = X;
            }
            switch (text)
            {
                case "=": Művelet = -1; break;
                case "+": Művelet = 1; break;
                case "-": Művelet = 2; break;
                case "*": Művelet = 3; break;
                case "/": Művelet = 4; break;
            }
            l.Add(X);
            X = "0";

          
        }
        private string Mű(string régi, string új)
        {
            double x = double.Parse(régi);
            double y = double.Parse(új);
            double z = 0;
            switch (Művelet)
            {
                case 1: z = x + y; break;
                case 2: z = x - y; break;
                case 3: z = x * y; break;
                case 4: z = x / y; break;
            }
            l.Add(új);
            return z.ToString();
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            l.Clear();
            X = "0";
            Label.Content = X;
        }

        private void PluszMínusz_Click(object sender, RoutedEventArgs e)
        {
            if (X[0] == '-') X.Remove(0, 1);
            else X.Insert(0,"-");
            Label.Content = X;
        }
    }
}
