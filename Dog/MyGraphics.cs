using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Dog
{
    internal class MyGraphics : Canvas
    {
        public MyObjects MyObjects = new MyObjects();

        protected override void OnRender(DrawingContext dc)
        {
            MyObjects.DrawObjects(dc);
        }

        public void ReDraw()
        {
            InvalidateVisual();
        }
    }

    class MyObjects
    {
        System.Drawing.Image Image;

        int SpriteIndex;
        System.Drawing.Rectangle[] SpriteOffset;
        System.Windows.Point Pos;
        System.Windows.Size Size;
        int GoXStep;

        public void LoadImages()
        {
            string pathImage = "dog_run.png";
            Image = System.Drawing.Image.FromFile(pathImage);

            SpriteIndex = 0;
            SpriteOffset = new System.Drawing.Rectangle[]
            {
                new System.Drawing.Rectangle(244, 3, 57, 42),
                new System.Drawing.Rectangle(304, 4, 54, 39),
                new System.Drawing.Rectangle(363, 4, 57, 38),
                new System.Drawing.Rectangle(420, 1, 55, 40),
                new System.Drawing.Rectangle(483, 4, 57, 36),
                new System.Drawing.Rectangle(542, 4, 57, 38)
            };

            Pos = new System.Windows.Point(10, 15);
            Size = new System.Windows.Size(50, 50);
            GoXStep = 5;
        }

        public void DrawPartImage(DrawingContext drawingContext, System.Windows.Point pos, System.Drawing.Image image, System.Drawing.Rectangle part)
        {
            Bitmap bmpPart = new Bitmap(part.Width, part.Height);

            using (Graphics g = Graphics.FromImage(bmpPart))
            {
                g.DrawImage(image, new System.Drawing.Rectangle(0, 0, part.Width, part.Height), part.X, part.Y, part.Width, part.Height, GraphicsUnit.Pixel);

                //Memory Stream
                MemoryStream ms = new MemoryStream();
                bmpPart.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                BitmapImage bmpImage = new BitmapImage();
                bmpImage.BeginInit();
                ms.Seek(0, SeekOrigin.Begin);
                bmpImage.StreamSource = ms;
                bmpImage.EndInit();

                //Draw
                System.Windows.Size size = new System.Windows.Size(part.Width, part.Height);
                drawingContext.DrawImage(bmpImage, new System.Windows.Rect(pos, size));
            }
        }

        public void DrawObjects(DrawingContext drawingContext)
        {
            if (SpriteIndex < 0 || SpriteIndex > SpriteOffset.Length)
                SpriteIndex = 0;
            System.Drawing.Rectangle rect = SpriteOffset[SpriteIndex];
            DrawPartImage(drawingContext, Pos, Image, rect);
            SpriteIndex++;
        }

        public void MoveObjects()
        {
            Pos.X += GoXStep;
        }
    }
}
