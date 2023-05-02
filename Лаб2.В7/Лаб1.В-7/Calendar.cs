using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Лаб1.В_7
{
    internal class Calendar
    {
        private int xd, y, yd1, yd2, xm, xy;
        private int width, height;
        private int flag_d = 0, flag_m = 0, flag_y = 0;
        private int[] day_m = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
        private string[] month_m = new string[] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        private int day_now = 9, month_now = 2, year_now = 2022;

        Graphics gr;

        public Calendar(Graphics gr, Form1 form1, int X, int Y)
        {
            xd = X;
            y = Y;
            width = 30;
            height = 45;
            yd1 = y - 10 - 5 * 19;
            yd2 = y + height + 10;
            xm = xd + width * 2 + 15;
            xy = xd + width * 9 + 30;

            this.gr = gr;     
        }

        internal void Draw_Day(int day_now)
        {
            gr.FillRectangle(Brushes.White, xd, y, width * 2, height);
            gr.DrawRectangle(Pens.MediumBlue, xd, y, width * 2, height);
            gr.DrawString(day_now.ToString(), new Font("Arial", width), Brushes.Blue, xd, y);
        }

        internal void Draw_list_day(int day_now)
        {

            yd1 = y - 10 - 5 * 19;
            gr.FillRectangle(Brushes.White, xd, yd1, width, 5 * 19);

            if (day_now - 6 + 1 > 0)
            {
                for (int i = 6; i > 1; i--)
                {
                    gr.DrawString(day_m[day_now - i].ToString(), new Font("Arial", 11), Brushes.Blue, xd, yd1);
                    yd1 = yd1 + 19;
                }
            }
            else
            {
                Draw_Clear(xd, y - 10 - 5 * 19, width, 5 * 19);
                yd1 = y - 10 - (day_now - 1) * 19;
                gr.FillRectangle(Brushes.White, xd, yd1, width, (day_now - 1) * 19);


                for (int i = day_now; i > 1; i--)
                {
                    gr.DrawString(day_m[day_now - i].ToString(), new Font("Arial", 11), Brushes.Blue, xd, yd1);
                    yd1 = yd1 + 19;
                }
            }

            yd2 = y + height + 10;
            gr.FillRectangle(Brushes.White, xd, yd2, width, 5 * 19);

            if (day_now + 5 < 31)
            {
                for (int i = 0; i < 5; i++)
                {
                    gr.DrawString(day_m[day_now + i].ToString(), new Font("Arial", 11), Brushes.Blue, xd, yd2);
                    yd2 = yd2 + 19;
                }
            }
            else
            {
                Draw_Clear(xd, y + height + 10, width, 5 * 19);
                gr.FillRectangle(Brushes.White, xd, yd2, width, (31 - day_now) * 19);

                for (int i = 0; i < 31 - day_now; i++)
                {
                    gr.DrawString(day_m[day_now + i].ToString(), new Font("Arial", 11), Brushes.Blue, xd, yd2);
                    yd2 = yd2 + 19;
                }
            }

        }

        internal void Draw_Month(int month_now)
        {
            gr.FillRectangle(Brushes.White, xm, y, width * 7, height);
            gr.DrawRectangle(Pens.MediumBlue, xm, y, width * 7, height);
            gr.DrawString(month_m[month_now], new Font("Arial", width), Brushes.Blue, xm, y);
        }

        internal void Draw_list_Month(int month_now)
        {
            yd1 = y - 10 - 5 * 19;
            gr.FillRectangle(Brushes.White, xm, yd1, width * 5, 5 * 19);

            if (month_now - 4 > 0)
            {
                for (int i = 5; i > 0; i--)
                {
                    gr.DrawString(month_m[month_now - i], new Font("Arial", 11), Brushes.Blue, xm, yd1);
                    yd1 = yd1 + 19;
                }
            }
            else
            {
                Draw_Clear(xm, y - 10 - 5 * 19, width * 5, 5 * 19);
                yd1 = y - 10 - (month_now) * 19;
                gr.FillRectangle(Brushes.White, xm, yd1, width * 5, (month_now) * 19);


                for (int i = month_now; i > 0; i--)
                {
                    gr.DrawString(month_m[month_now - i], new Font("Arial", 11), Brushes.Blue, xm, yd1);
                    yd1 = yd1 + 19;
                }
            }

            yd2 = y + height + 10;
            gr.FillRectangle(Brushes.White, xm, yd2, width * 5, 5 * 19);

            if (month_now + 5 < 12)
            {
                for (int i = 1; i < 6; i++)
                {
                    gr.DrawString(month_m[month_now + i], new Font("Arial", 11), Brushes.Blue, xm, yd2);
                    yd2 = yd2 + 19;
                }
            }
            else
            {
                Draw_Clear(xm, y + height + 10, width * 5, 5 * 19);
                gr.FillRectangle(Brushes.White, xm, yd2, width * 5, (12 - month_now - 1) * 19);

                for (int i = 1; i < 12 - month_now; i++)
                {
                    gr.DrawString(month_m[month_now + i], new Font("Arial", 11), Brushes.Blue, xm, yd2);
                    yd2 = yd2 + 19;
                }
            }
        }

        internal void Draw_Year(int year_now)
        {
            gr.FillRectangle(Brushes.White, xy, y, width * 4, height);
            gr.DrawRectangle(Pens.MediumBlue, xy, y, width * 4, height);
            gr.DrawString(year_now.ToString(), new Font("Arial", width), Brushes.Blue, xy, y);

        }

        internal void Draw_list_Year(int year_now)
        {
            yd1 = y - 10 - 5 * 19;
            gr.FillRectangle(Brushes.White, xy, yd1, width * 2, 5 * 19);

            for(int i = year_now - 5; i < year_now; i++)
            {
                gr.DrawString(i.ToString(), new Font("Arial", 11), Brushes.Blue, xy, yd1);
                yd1 = yd1 + 19;
            }            

            yd2 = y + height + 10;
            gr.FillRectangle(Brushes.White, xy, yd2, width * 2, 5 * 19);

            for (int i = year_now + 1; i < year_now + 6; i++)
            {
                gr.DrawString(i.ToString(), new Font("Arial", 11), Brushes.Blue, xy, yd2);
                yd2 = yd2 + 19;
            }
        }

        internal void Draw_Clear(int x1, int y1, int width1, int height1)
        {
            gr.FillRectangle(Brushes.LightSteelBlue, x1, y1, width1, height1);
        }

        internal void Mouse_move(int X, int Y)
        {
            xm = xd + width * 2 + 15;
            xy = xd + width * 9 + 30;

            if (X >= xd && X <= xd + 2 * width && Y >= y && Y <= y + height)
            {
                Draw_list_day(day_now);
                flag_d = 1;
            }
            else
            {
                Draw_Clear(xd, y - 10 - 5 * 19,width, 5 * 19);
                Draw_Clear(xd, y + height + 10, width, 5 * 19);
                flag_d = 0;
            }

            if (X >= xm && X <= xm + 7 * width && Y >= y && Y <= y + height)
            {
                Draw_list_Month(month_now);
                flag_m = 1;
            }
            else
            {
                Draw_Clear(xm, y - 10 - 5 * 19, 5 * width, 5 * 19);
                Draw_Clear(xm, y + height + 10, 5 * width, 5 * 19);
                flag_m = 0;
            }

            if (X >= xy && X <= xy + 4 * width && Y >= y && Y <= y + height)
            {
                Draw_list_Year(year_now);
                flag_y = 1;
            }
            else
            {
                Draw_Clear(xy, y - 10 - 5 * 19, 2 * width, 5 * 19);
                Draw_Clear(xy, y + height + 10, 2 * width, 5 * 19);
                flag_y = 0;
            }
        }

        internal void Mouse_Wheel(int Delta)
        {
            if (Delta > 0 && flag_d == 1)
            {
                if (day_now < 31)
                    day_now += 1;
                Draw_Day(day_now);
                Draw_list_day(day_now);
            }
            if (Delta < 0 && flag_d == 1)
            {
                if (day_now > 1)
                    day_now -= 1;
                Draw_Day(day_now);
                Draw_list_day(day_now);
            }

            if (Delta > 0 && flag_m == 1)
            {
                if (month_now < 11)
                    month_now++;
                Draw_Month(month_now);
                Draw_list_Month(month_now);
            }
            if (Delta < 0 && flag_m == 1)
            {
                if (month_now > 0)
                    month_now -= 1;
                Draw_Month(month_now);
                Draw_list_Month(month_now);
            }

            if (Delta > 0 && flag_y == 1)
            {
                year_now++;
                Draw_Year(year_now);
                Draw_list_Year(year_now);
            }
            if (Delta < 0 && flag_y == 1)
            {
                year_now--;
                Draw_Year(year_now);
                Draw_list_Year(year_now);
            }
        }

        internal void Calendar_Paint()
        {
            Draw_Day(day_now);
            Draw_Month(month_now);
            Draw_Year(year_now);
        }
    }
}
