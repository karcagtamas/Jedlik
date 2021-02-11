using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random r;
        bool balra = true;
        bool fel = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            r = new Random();
            Color ez = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
            BackColor = ez;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
            if (balra && fel) 
            { 
                Location = new Point(Location.X - r.Next(1, 3), Location.Y - r.Next(-1, 3)); 
            }
            else if (balra) 
            { 
                Location = new Point(Location.X - r.Next(1, 3), Location.Y + r.Next(-1, 3)); 
            }
            else if (fel) 
            { 
                Location = new Point(Location.X + r.Next(1, 3), Location.Y - r.Next(-1, 3)); 
            }
            else 
            { 
                Location = new Point(Location.X + r.Next(1, 3), Location.Y + r.Next(-1, 3)); 
            }
            if (Location.X < -100 || Location.Y < 0 || Location.Y > Screen.PrimaryScreen.Bounds.Height || Location.X > Screen.PrimaryScreen.Bounds.Width)
            {
                if (balra) { balra = false; }
                if (Location.Y < -100) { fel = false; }
                if (Location.Y > Screen.PrimaryScreen.Bounds.Height) { fel = true; }
                if (Location.X > Screen.PrimaryScreen.Bounds.Width) { balra = true; }
            }
        }
    }
}
