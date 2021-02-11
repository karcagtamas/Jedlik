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
        string name;
        string scél;
        public Form1()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader(@"C:\Users\karcagtamas\Documents\sw.txt");
            int x = 1;
            while (!sr.EndOfStream)
            {
                if (x == 1) textBox2.Text = sr.ReadLine();
                else textBox3.Text = sr.ReadLine();
                x++;
            }
            sr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text[textBox2.Text.Length - 1] != '\\') textBox2.Text = textBox2.Text.Insert(textBox2.Text.Length, "\\");
            if (textBox3.Text[textBox3.Text.Length - 1] != '\\') textBox3.Text = textBox3.Text.Insert(textBox3.Text.Length, "\\");
            sforr = @textBox2.Text;
            scél = @textBox3.Text;
            name = textBox1.Text;
            if (sforr == scél)
            {
                MessageBox.Show("Nem egyezhet meg a forrás és cél könyvtár!");
            }
            else
            {
                if (name == "")
                {
                    MessageBox.Show("Adjon meg nevet a fájlokhoz!");
                }
                else
                {
                    progressBar1.Visible = true;
                    DirectoryInfo di = new DirectoryInfo(sforr);
                    FileInfo[] fi = di.GetFiles();
                    progressBar1.Maximum = fi.Length;
                    progressBar1.Step = 1;
                    for (int i = 0; i < fi.Length; i++)
                    {
                        string[] a = fi[i].Name.Split('.');
                        a[1] = a[1].Insert(0,".");
                        string szám = (i + 1).ToString();
                        if (szám.Length == 1) szám = szám.Insert(0, "00");
                        if (szám.Length == 2) szám = szám.Insert(0, "0");
                        File.Copy(sforr + fi[i].Name, scél + name + szám + a[1], true);
                        progressBar1.PerformStep();
                    }
                    progressBar1.Visible = false;
                    MessageBox.Show("Az átalakítás kész!");
                    StreamWriter sw = new StreamWriter(@"C:\Users\karcagtamas\Documents\sw.txt", true);
                    sw.WriteLine(sforr);
                    sw.WriteLine(scél);
                    sw.Flush();
                    sw.Close();
                }
            }
        }



    }
}
