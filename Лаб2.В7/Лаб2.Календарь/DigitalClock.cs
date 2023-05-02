using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Лаб2.Календарь
{

    internal class Calendar
    {
        int[] day_m = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31};
        string[] month_m = new string[] {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};
        int[] year_m = new int[50];
        private int x, y, x_m, x_y;
        private int width, height;

        Graphics gr;

        public Calendar(Graphics gr, Form1 form1)
        {
            x = y = 50;
            width = 30;
            height = 45;
            x_m = x + width * 2 + 20;
            x_y = x_m + width * 7 + 20;

            this.gr = gr;
            
        }

        internal void Draw_Day(int day_now)
        {
            gr.FillRectangle(Brushes.White, x, y, width * 2, height);
            gr.DrawRectangle(Pens.Black, x, y, width * 2, height);
            gr.DrawString(day_now.ToString(), new Font("Arial", width), Brushes.Blue, x, y);
        }

        internal void Draw_list_day(int day_now)
        {
            int x_c = 50;
            int y_c = 100;
            gr.FillRectangle(Brushes.White, x_c, y_c, width * 2, height * 13);
            gr.DrawRectangle(Pens.Black, x_c, y_c, width * 2, height * 13);
            for (int i = 0; i < day_m.Length; i++)
            {
                if(day_now == day_m[i])
                    gr.DrawString(day_m[i].ToString(), new Font("Arial", 11), Brushes.Red, x_c, y_c);
                else
                    gr.DrawString(day_m[i].ToString(), new Font("Arial", 11), Brushes.Blue, x_c, y_c);
                y_c = y_c + 19;
            }
        }

        internal void Draw_Clear(int x1, int y1, int width1, int height1)
        {
            gr.FillRectangle(Brushes.LightSteelBlue, x1, y1, width1, height1);
            gr.DrawRectangle(Pens.LightSteelBlue, x1, y1, width1, height1);
        }

        internal void Draw_Month(int month_now)
        {
            gr.FillRectangle(Brushes.White, x_m, y, width * 7, height);
            gr.DrawRectangle(Pens.Black, x_m, y, width * 7, height);
            gr.DrawString(month_m[month_now], new Font("Arial", width), Brushes.Blue, x_m, y);
        }

        internal void Draw_list_month(int month_now)
        {
            int y_t = 100;
            gr.FillRectangle(Brushes.White, x_m, y_t, width * 3, height * 5);
            gr.DrawRectangle(Pens.Black, x_m, y_t, width * 3, height * 5);
            for (int i = 0; i < month_m.Length; i++)
            {
                if (month_m[month_now] == month_m[i])
                    gr.DrawString(month_m[i].ToString(), new Font("Arial", 11), Brushes.Red, x_m, y_t);
                else
                    gr.DrawString(month_m[i].ToString(), new Font("Arial", 11), Brushes.Blue, x_m, y_t);
                y_t = y_t + 19;
            }
        }

        internal void Draw_Year(int year_now)
        {
            gr.FillRectangle(Brushes.White, x_y, y, width * 4, height);
            gr.DrawRectangle(Pens.Black, x_y, y, width * 4, height);
            gr.DrawString(year_now.ToString(), new Font("Arial", width), Brushes.Blue, x_y, y);
            
        }

        internal void Draw_list_year(int year_now)
        {
            int y_c = 100;
            int x = 2000;
            for (int j = 0; j < 31; j++)
                year_m[j] = x++;            

            gr.FillRectangle(Brushes.White, x_y, y_c, width * 2, height * 13);
            gr.DrawRectangle(Pens.Black, x_y, y_c, width * 2, height * 13);
            for (int i = 0; i < day_m.Length; i++)
            {
                if (year_now == year_m[i])
                    gr.DrawString(year_m[i].ToString(), new Font("Arial", 11), Brushes.Red, x_y, y_c);
                else
                    gr.DrawString(year_m[i].ToString(), new Font("Arial", 11), Brushes.Blue, x_y, y_c);
                y_c = y_c + 19;
            }
        }
    }
}
