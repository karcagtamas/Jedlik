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

namespace Wpfgyakorlás3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //if (ballistbox.HasItems == false) jobbravisz.IsEnabled = false;
            //if (jobblistbox.HasItems == false) balravisz.IsEnabled = false;
        }

        private void balhozzáad_Click(object sender, RoutedEventArgs e)
        {
            if (baltextbox.Text != "")
            {
                ballistbox.Items.Add(baltextbox.Text);
                baltextbox.Text = "";
                //jobbravisz.IsEnabled = true;
            }
        }

        private void jobbhozzáad_Click(object sender, RoutedEventArgs e)
        {
            if (jobbtextbox.Text != "")
            {
                jobblistbox.Items.Add(jobbtextbox.Text);
                jobbtextbox.Text = "";
                //balravisz.IsEnabled = true;
            }
        }

        private void baltöröl_Click(object sender, RoutedEventArgs e)
        {
            ballistbox.Items.Remove(ballistbox.SelectedItem);
        }

        private void jobbtöröl_Click(object sender, RoutedEventArgs e)
        {
            jobblistbox.Items.Remove(jobblistbox.SelectedItem);
        }

        private void jobbravisz_Click(object sender, RoutedEventArgs e)
        {
            if (ballistbox.HasItems)
            {
                jobblistbox.Items.Add(ballistbox.SelectedItem);
                ballistbox.Items.Remove(ballistbox.SelectedItem);
            }
            else MessageBox.Show("Nem lehet mit átvinni!");
        }

        private void balravisz_Click(object sender, RoutedEventArgs e)
        {
            if (jobblistbox.HasItems)
            {
                ballistbox.Items.Add(jobblistbox.SelectedItem);
                jobblistbox.Items.Remove(jobblistbox.SelectedItem);
            }
            else MessageBox.Show("Nem lehet mit átvinni!");
        }

        private void jobbraviszmind_Click(object sender, RoutedEventArgs e)
        {
            if (ballistbox.HasItems)
            {
                foreach (var item in ballistbox.Items)
                {
                    jobblistbox.Items.Add(item);
                }
            }
        }


    }
}
