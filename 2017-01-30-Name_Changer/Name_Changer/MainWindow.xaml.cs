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

namespace Name_Changer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pl { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            if (this.name() && this.path())
            {
                ButtonOK.Visibility = Visibility.Collapsed;
                Töltés.Visibility = Visibility.Visible;
                this.folyamat();
                ButtonCLS.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Sajnos hibás nevet vagy elérési útat adott meg!");
            }
        }
        private void folyamat()
        {
            if (Textbox2.Text[Textbox2.Text.Length - 1] != '\\') Textbox2.Text = Textbox2.Text.Insert(Textbox2.Text.Length, "\\");
            string p1 = @Textbox2.Text;
            string n1 = Textbox1.Text;
            DirectoryInfo di = new DirectoryInfo(p1);
            FileInfo[] fi = di.GetFiles();
            Töltés.Maximum = fi.Length;
            Töltés.Value = 1;
            for (int i = 0; i < fi.Length; i++)
            {
                string[] a = fi[i].Name.Split('.');
                a[1] = a[1].Insert(0, ".");
                string szám = (i + 1).ToString();
                if (szám.Length == 1) szám = szám.Insert(0, "00");
                if (szám.Length == 2) szám = szám.Insert(0, "0");
                File.Copy(p1 + fi[i].Name, p1 + n1 + szám + a[1], true);
                File.Delete(p1 + fi[i].Name);
                Töltés.Value++;
            }
            MessageBox.Show("Az átalakítás kész!");
            if (!Directory.Exists(@"C:\ProgramData\NameChanger")) Directory.CreateDirectory(@"C:\ProgramData\NameChanger");
            StreamWriter sw = new StreamWriter(@"C:\ProgramData\NameChanger\info.txt", true);
            sw.WriteLine(p1);
            sw.Flush();
            sw.Close();
        }
        private bool name()
        {
            if (Textbox1.Text == "" || Textbox1.Text == " ") return false;
            return true;
        }
        private bool path()
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(Textbox2.Text);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void ButtonCLS_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (!File.Exists(@"C:\ProgramData\NameChanger\info.txt")) File.Create(@"C:\ProgramData\NameChanger\info.txt");
            string[] s = File.ReadAllLines(@"C:\ProgramData\NameChanger\info.txt");
            if (s.Length != 0) this.pl = s[s.Length - 1];
            else this.pl = @"C:\";
            Textbox2.Text = pl;
        }
    }
}
