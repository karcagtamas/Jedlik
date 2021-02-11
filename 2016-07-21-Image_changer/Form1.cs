using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace image_changer
{
    public partial class Form1 : Form
    {
        string sforr;
        string célform;
        string scél;
        public Form1()
        {
            InitializeComponent();
            sforr = @"C:\Users\karcagtamas\Pictures\10A\Korcsolyázás_2015\Nitss\";
            scél = @"C:\Users\karcagtamas\Pictures\10A\Korcsolyázás_2015\Nits\";
            célform = ".jpg";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(sforr);
            FileInfo[] fi = di.GetFiles();
            for (int i = 0; i < fi.Length; i++)
            {
                string[] a = fi[i].Name.Split('.');
                if (a[1] != "db" && a[1] != célform)
                {
                    //fi[i].CopyTo(a[0] + célform, true);
                    //fi[i].Name = a[0] + célform;
                    File.Copy(sforr + fi[i].Name, scél + a[0] + célform,true);
                    //MessageBox.Show(fi[i].Name);
                }
            }
        }
    }
}
