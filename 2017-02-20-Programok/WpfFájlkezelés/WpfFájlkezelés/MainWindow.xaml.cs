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
using System.IO;

namespace WpfFájlkezelés
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string elérésiút = bevitel.Text;

            if (File.Exists(elérésiút) == true)
            {
                //létezik-e
                létezik.Content = "Igen";

                //fájl név
                string[] elú = elérésiút.Split('\\');
                fájlnév.Content = elú.Last();

                //könyvtárnév
                könyvtárnév.Content = System.IO.Path.GetDirectoryName(System.IO.Path.GetFullPath(elérésiút));

                //sorszám
                StreamReader sr = new StreamReader(elérésiút);
                string[] összsor = File.ReadAllLines(elérésiút);
                hánysora.Content = összsor.Count();

                //első sor
                elsősor.Content = összsor.First();

                //utolsó sor
                utolsósor.Content = összsor.Last();

            }
            else
            {
                létezik.Content = "Nem létezik";
                fájlnév.Content = "Nem létezik";
                könyvtárnév.Content = "Nem létezik";
                hánysora.Content = "Nem létezik";
                elsősor.Content = "Nem létezik";
                utolsósor.Content = "Nem létezik";

            }

            
            
        }
    }
}
