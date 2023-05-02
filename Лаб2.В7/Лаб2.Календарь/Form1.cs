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

namespace Лаб2.Календарь
{
    public partial class Form1 : Form
    {
        Calendar calendar1;
        int day_now = 1;
        int month_now = 0;
        int year_now = 2000;
        int flag_d = 0;
        int flag_m = 0;
        int flag_y = 0;


        public Form1()
        {
            InitializeComponent();

            
            this.Width = 550;
            this.Height = 800;
            this.BackColor = Color.LightSteelBlue;

            Graphics gr = this.CreateGraphics();
            calendar1 = new Calendar(gr, this);

            this.MouseWheel += new MouseEventHandler(this_MouseWeel);     
        }

        private void this_MouseWeel(object sender, MouseEventArgs e)
        {            
            if (e.Delta > 0 && flag_d == 1)
            {
                if(day_now < 31)
                    day_now += 1;
                calendar1.Draw_Day(day_now);
                calendar1.Draw_list_day(day_now);
            }
            if (e.Delta < 0 && flag_d == 1)
            {
                if(day_now > 1)
                    day_now -= 1;
                calendar1.Draw_Day(day_now);
                calendar1.Draw_list_day(day_now);
            }

            if (e.Delta > 0 && flag_m == 1)
            {
                if (month_now < 11)
                    month_now++;
                calendar1.Draw_Month(month_now);
                calendar1.Draw_list_month(month_now);
            }
            if (e.Delta < 0 && flag_m == 1)
            {
                if (month_now > 0)
                    month_now -= 1;
                calendar1.Draw_Month(month_now);
                calendar1.Draw_list_month(month_now);
            }

            if (e.Delta > 0 && flag_y == 1)
            {
                if (year_now < 2030)
                    year_now++;
                calendar1.Draw_Year(year_now);
                calendar1.Draw_list_year(year_now);
            }
            if (e.Delta < 0 && flag_y == 1)
            {
                if (year_now > 2000)
                    year_now--;
                calendar1.Draw_Year(year_now);
                calendar1.Draw_list_year(year_now);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            calendar1.Draw_Day(day_now);
            calendar1.Draw_Month(month_now);
            calendar1.Draw_Year(year_now);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >= 50 && e.X <= 110 && e.Y >= 50 && e.Y <= 95)
            {
                calendar1.Draw_list_day(day_now);
                flag_d = 1;
            }
            else
            {
                calendar1.Draw_Clear(50, 100, 30 * 2, 45 * 13);
                flag_d = 0;
            }

            if (e.X >= 130 && e.X <= 310 && e.Y >= 50 && e.Y <= 95)
            {
                calendar1.Draw_list_month(month_now);
                flag_m = 1;
            }
            else
            {
                calendar1.Draw_Clear(130, 100, 30 * 7, 45 * 13);
                flag_m = 0;
            }

            if (e.X >= 360 && e.X <= 480 && e.Y >= 50 && e.Y <= 95)
            {
                calendar1.Draw_list_year(year_now);
                flag_y = 1;
            }
            else
            {
                calendar1.Draw_Clear(360, 100, 60, 45 * 13);
                flag_y = 0;
            }
        }
    }
}
