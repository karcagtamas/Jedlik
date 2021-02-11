using System;
using System.Collections.Generic;
using System.IO;
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
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Utónevek
{
    public enum Nem
    {
        Férfi = 1,
        Női = 2
    }

    public class Utónév:INotifyPropertyChanged
    {
        private string név;
        private DateTime? névnap; //a kérdőjeles változó felveheti a null értéket is
        private string eredet;
        private string jelentés;
        private Nem? nem;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Név
        {
            get
            {
                return név;
            }

            set
            {
                név = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Név"));
            }
        }
        public DateTime? Névnap
        {
            get
            {
                return névnap;
            }

            set
            {
                névnap = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Névnap"));
            }
        }
        public string Eredet
        {
            get
            {
                return eredet;
            }

            set
            {
                eredet = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Eredet"));
            }
        }
        public string Jelentés
        {
            get
            {
                return jelentés;
            }

            set
            {
                jelentés = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Jelentés"));
            }
        }
        public Nem? Nem
        {
            get
            {
                return nem;
            }

            set
            {
                nem = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Nem"));
                    PropertyChanged(this, new PropertyChangedEventArgs("NemSzín"));
                }
            }
        }
        public Brush NemSzín
        {
            get
            {
                return this.Nem == Utónevek.Nem.Férfi ? Brushes.Blue : Brushes.Pink;
            }
        }

        public Utónév(string sor)
        {
            string[] oszlopok = sor.Split(';');
            this.Név = oszlopok[0];
            if (oszlopok[1] != "") this.Névnap = new DateTime(1, Convert.ToInt32(oszlopok[1]), Convert.ToInt32(oszlopok[2]));
            this.Eredet = oszlopok[3];
            this.Jelentés = oszlopok[4];
            if (oszlopok[5] != "") this.Nem = (Nem)(Convert.ToInt32(oszlopok[5]));
        }

        public static List<Utónév> LoadFromFile(string filename)
        {
            List<Utónév> segéd = new List<Utónév>();
            foreach (string sor in File.ReadAllLines(filename, Encoding.UTF8))
            {
                segéd.Add(new Utónév(sor));
            }
            return segéd;
        }

        public override string ToString()
        {
            return this.Név;
        }
        
    }
    

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Utónév> utónevek;
        public ObservableCollection<Utónév> Utónevek
        {
            get
            {
                return utónevek;
            }

            set
            {
                utónevek = value;
            }
        }

        public MainWindow()
        {            
            InitializeComponent();

            this.Keresés.Focus();

            foreach (var item in Enum.GetValues(typeof(Nem)))
            {
                this.nNem.Items.Add(item);
            }

            this.Utónevek = new ObservableCollection<Utónév>(Utónév.LoadFromFile("Utónevek.csv"));
            this.lstNevek.ItemsSource = this.utónevek;    
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Utónevek[lstNevek.SelectedIndex].Név = "megszentségteleníthetetlenségeskedéseitekért";
            this.Utónevek[lstNevek.SelectedIndex].Eredet = "elkelkáposztásításotokért";
            this.Utónevek[lstNevek.SelectedIndex].Jelentés = "földönfutó, paraszt";
            this.Utónevek[lstNevek.SelectedIndex].Nem = Nem.Női;
        }

        private void Keresés_KeyUp(object sender, KeyEventArgs e)
        {
            this.lstNevek.ItemsSource = this.utónevek.Where(x => x.Név.ToLower().Contains(this.Keresés.Text.Trim().ToLower()) ||
            x.Jelentés.ToLower().Contains(this.Keresés.Text.Trim()) ||
            x.Eredet.ToLower().Contains(this.Keresés.Text.Trim()) ||
            x.Nem.ToString().ToLower().Contains(this.Keresés.Text.Trim()) ||
            x.Névnap.ToString().ToLower().Contains(this.Keresés.Text.Trim()));
        }
    }
}
