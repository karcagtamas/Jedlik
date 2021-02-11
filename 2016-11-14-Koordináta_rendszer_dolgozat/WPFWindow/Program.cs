using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

//dll: PresentationCore, PresentationFramework, System.Xaml, WindowsBase

namespace WPFWindow
{
    class Program
    {
        [STAThread] //WPF grafikák
        static void Main(string[] args)
        {
            MyWPFWindow w = new MyWPFWindow(80);
            //w.Ablak.ShowDialog();
            
        }
    }
}
