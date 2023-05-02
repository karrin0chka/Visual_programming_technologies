using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Лаба3
{
    internal class Stripe
    {
        Rectangle rect;
        Color col;


        public Stripe(int x, int y, int w, int h)
        {
            rect = new Rectangle(x, y, w, h);
            col = Color.LemonChiffon;
        }

        internal void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(col), rect);
            g.DrawRectangle(Pens.Black, rect);
        }

        internal bool Inside(int x, int y)
        {
            if (x < rect.Left || x > rect.Right)
                return false;
            if (y < rect.Top || y > rect.Bottom)
                return false;
            return true;
        }

        internal bool Intersect(Stripe s)
        {
            return rect.IntersectsWith(s.rect);
        }

        internal void SetColor(Color color)
        {
            col = color;
        }
    }
}
