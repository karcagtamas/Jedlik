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

namespace Dolgozat_2017._04._03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] hónapok = { "január", "február", "március", "április", "május", "június", "július", "augusztus", "szeptember", "október", "november", "december" };
        public MainWindow()
        {
            InitializeComponent();
            Lista.Items.Add("Lista");
        }
        private void Gomb1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Szöveg.Text);
        }

        private void Gomb2_Click(object sender, RoutedEventArgs e)
        {
            Gomb4.Background = Brushes.Red;
        }

        private void Gomb3_Click(object sender, RoutedEventArgs e)
        {
            Lista.Items.Add(DateTime.Now.Year +". " +  hónapok[DateTime.Now.Month - 1] + " " + DateTime.Now.Day + ".");
        }

        private void Gomb4_Click(object sender, RoutedEventArgs e)
        {
            Jelölőnégyzet.IsChecked = true;
        }
    }
}
