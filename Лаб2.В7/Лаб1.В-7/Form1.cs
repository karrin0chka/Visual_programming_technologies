using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаб1.В_7
{
    public partial class Form1 : Form
    {
        Calendar calendar1;
        Calendar calendar2;

        public Form1()
        {
            InitializeComponent();

            this.Width = 1050;
            this.Height = 400;
            this.BackColor = Color.LightSteelBlue;
           
            Graphics gr = this.CreateGraphics();
           
            calendar1 = new Calendar(gr, this, 50, 150);
            calendar2 = new Calendar(gr, this, 550, 150);
            
            this.MouseWheel += new MouseEventHandler(this_MouseWheel);
        }

        private void this_MouseWheel(object sender, MouseEventArgs e)
        {
            calendar1.Mouse_Wheel(e.Delta);
            calendar2.Mouse_Wheel(e.Delta);
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            calendar1.Calendar_Paint();
            calendar2.Calendar_Paint();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            calendar1.Mouse_move(e.X, e.Y);
            calendar2.Mouse_move(e.X, e.Y);
        }
    }
}
