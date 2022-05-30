using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Index1 : Form
    {
        public Index1()
        {
            InitializeComponent();
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (pictureBox1.Location.X < 480)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X+5, pictureBox1.Location.Y); 
                
            }
            else
            {
                timer1.Stop();
                Index index = new Index();
                this.Hide();
                index.Show();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            login info = new login();
            this.Hide();
            info.Show();          
        }
    }
}
