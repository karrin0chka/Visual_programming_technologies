using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба3
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int h = 50, w = 250;
        int count_stripes = 20, n = 2, level = 1, ms = 1000;

        List<Stripe> stripes;

        public Form1()
        {
            InitializeComponent();
            stripes = new List<Stripe>();

            Add_stripes(n);
            timer.Interval = ms;
            timer.Start();
            timer.Tick += Timer_Tick1;
            
        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            Add_stripes(1);
            Invalidate();
            n++;
            if (n > count_stripes)
            {
                timer.Stop();
                MessageBox.Show("Уровень не пройден!");
                this.Close();
            }

        }

   


        private void Add_stripes(int n)
        {
            while (n-- > 0)
{
                int x = random.Next(this.ClientSize.Width - w - 5);
                int y = random.Next(this.ClientSize.Height - h - 5);

                Stripe s = new Stripe(x, y, w, h);
                int r = random.Next(256);
                int g = random.Next(256);
                int b = random.Next(256);

                s.SetColor(Color.FromArgb(r, g, b));
                stripes.Add(s);
            }
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            foreach (Stripe x in stripes)
            {
                x.Draw(g);
            }
        }


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = stripes.Count - 1; i >= 0; i--)
            {
                if (stripes[i].Inside(e.X, e.Y))
                {
                    bool ok = true;
                    for (int j = i + 1; j < stripes.Count; j++)
                    {
                        if (stripes[j].Intersect(stripes[i]))
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (ok)
                    {
                        stripes.RemoveAt(i);
                        Invalidate();
                        n--;
                        break;
                    }
                }
            }

            if (n == 0)
            {
                timer.Stop();
                MessageBox.Show("Уровень пройден!");

                level++;
                ms = ms - 10;
                count_stripes = count_stripes - 1;
                n = level;
                h = h - 3;
                w = w + 3;

                New_level(ms);
            }
        }

        private void New_level(int ms)
        {
            Add_stripes(n);
            timer.Interval = ms;
            timer.Start();
        }
           


        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
