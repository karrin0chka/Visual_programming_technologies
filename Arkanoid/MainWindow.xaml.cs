using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Arkanoid
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        const int n = 10;
        int  num = 5, width_rect = 50, height_rect = 20, x_pl = 275, y_pl = 370, x_b = 290, y_b = 350, count = 0;
        int x0 = 40, y0 = 70, msec = 1, napravlenie_v = -1, napravlenie_g = 1, level = 1;
        int[,] array = new int[n, n];
        Rectangle rect_pl = new Rectangle();
        Ellipse ball = new Ellipse();
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            Fon();
            CreatRec(num, num);
            Ball();
            Player();           
        
            ball.MouseLeftButtonUp += Grid_MouseLeftButtonUp;
            timer.Tick += Timer_Tick;
            MessageBoxResult result = MessageBox.Show("Для начала игры нажмите на шарик", "Арканоид", MessageBoxButton.OK);
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            timer.Interval = TimeSpan.FromMilliseconds(msec);
            grid.MouseMove += Main_MouseMove;            
            timer.Start();
           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (level == 1)
            {
                y_b += 3 * napravlenie_v;
                x_b += 3 * napravlenie_g;
            }
            else
            {
                y_b += napravlenie_v + napravlenie_v * level / 5;
                x_b += napravlenie_g + napravlenie_g * level / 5;
            }
            grid.Children.Remove(ball);
            Ball();
            if (y_b + ball.Height == y_pl && x_b + ball.Width >= x_pl && x_b <= x_pl + rect_pl.Width)
                napravlenie_v = -1;
            if (y_b <= 0)
                napravlenie_v = 1;
            if (x_b <= 0)
                napravlenie_g = 1;
            if (x_b + ball.Width * 2 >= 600)
                napravlenie_g = -1;

            Delete();

            if (count == 0)
            {
                timer.Stop();
                num++;
                MessageBoxResult result = MessageBox.Show("Перейти к следующему уровню?", "Уровень пройден!", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.No:
                        MessageBoxResult result1 = MessageBox.Show("Действительно хотите выйти?", "Подтверждение действия", MessageBoxButton.YesNo);
                        switch (result1)
                        {
                            case MessageBoxResult.Yes:
                                this.Close();
                                break;
                            case MessageBoxResult.No:
                                Play();
                                grid.MouseMove -= Main_MouseMove;
                                break;
                        }
                        break;

                    case MessageBoxResult.Yes:
                        Play();
                        grid.MouseMove -= Main_MouseMove;
                        break;
                }
            }

            if (y_b + ball.Height > y_pl + 30)
            {
                timer.Stop();
                MessageBoxResult result = MessageBox.Show("Играть заново?", "Вы проиграли", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.No:
                        this.Close();
                        break;
                    case MessageBoxResult.Yes:
                        level = 0;
                        grid.Children.Remove(ball);
                        grid.Children.Remove(rect_pl);
                        grid.Children.Clear();
                        Play();
                        Ball();                        
                        grid.MouseMove -= Main_MouseMove;
                        Player();
                        break;
                }
            }
        }

        private void Play()
        {
         /*   if (level == 0)
                msec = 1;
            else
                msec += 10;
        */    napravlenie_v = -1;
            level++;
            count = 0;
            num = 4;
            grid.MouseMove -= Main_MouseMove;
            CreatRec(num, num);
            x_pl = 275;
            y_pl = 370;
            x_b = 290;
            y_b = 350;
            ball.Margin = new Thickness(x_b, y_b, 0, 0);
            rect_pl.Margin = new Thickness(x_pl, y_pl, 0, 0);
            
            ball.MouseLeftButtonUp += Grid_MouseLeftButtonUp;
        }

        private void Delete()
        {
            int i = -1;
            Rect rect1 = new Rect(ball.Margin.Left, ball.Margin.Top, ball.Width, ball.Height);
            while (++i <= count)
            {
                if (grid.Children[i] == ball || grid.Children[i] == rect_pl )
                    break;
                else
                {
                    Rectangle ri = (Rectangle)grid.Children[i];
                    Rect rect2 = new Rect(ri.Margin.Left, ri.Margin.Top, ri.Width, ri.Height);

                    if (rect1.IntersectsWith(rect2))
                    {
                        {
                            grid.Children.Remove(grid.Children[i]);
                            count--;
                        }
                        if (napravlenie_g == 1)
                            napravlenie_g = -1;
                        else
                            napravlenie_g = 1;
                        if (napravlenie_v == 1)
                            napravlenie_v = -1;
                        else
                            napravlenie_v = 1;
                        break;
                    }
                }
            }
        
        }

        private void Fon()
        {
            Rectangle fon = new Rectangle();

            fon.Width = 600;
            fon.Height = 450;

            fon.HorizontalAlignment = HorizontalAlignment.Left;
            fon.VerticalAlignment = VerticalAlignment.Top;
            fon.Margin = new Thickness(0, 0, 0, 0);
            grid.Children.Add(fon);
        }

        private void Ball()
        { 
            ball.Width = 20;
            ball.Height = 20;

            ball.Fill = new SolidColorBrush(Colors.Yellow);
            ball.Stroke = new SolidColorBrush(Colors.Black);

            ball.HorizontalAlignment = HorizontalAlignment.Left;
            ball.VerticalAlignment = VerticalAlignment.Top;


            ball.Margin = new Thickness(x_b, y_b, 0, 0);
            grid.Children.Add(ball);
        }

        private void CreatRec(int n, int m)
        {
            x0 = (600 - (width_rect + 5) * num) / 2;
            int x = x0;
            int y = y0;

            int black_rext = 5;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = random.Next(2);
                    if (array[i, j] == 1)
                        black_rext--;
                    if(black_rext <
                        0) 
                        array[i, j] = 2;
                }

            while (n-- > 0)
            {
                byte r = (byte)(random.Next(256));
                byte g = (byte)(random.Next(256));
                byte b = (byte)(random.Next(256));
                int k = m;
                while (k-- > 0)
                {
                    if (array[n, k] == 0)
                    {
                        Rectangle rect = new Rectangle();

                        rect.Width = width_rect;
                        rect.Height = height_rect;

                        rect.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));

                        rect.Stroke = new SolidColorBrush(Colors.Black);
                        rect.HorizontalAlignment = HorizontalAlignment.Left;
                        rect.VerticalAlignment = VerticalAlignment.Top;

                        rect.Margin = new Thickness(x, y, 0, 0);
                        grid.Children.Add(rect);
                        count++;
                    }

                   if(array[n, k] == 1)
                    {

                        Rectangle rect = new Rectangle();

                        rect.Width = width_rect;
                        rect.Height = height_rect;

                        rect.Fill = new SolidColorBrush(Colors.Black);

                        rect.Stroke = new SolidColorBrush(Colors.Black);
                        rect.HorizontalAlignment = HorizontalAlignment.Left;
                        rect.VerticalAlignment = VerticalAlignment.Top;

                        rect.Margin = new Thickness(x, y, 0, 0);
                        grid.Children.Add(rect);
                    }
                    x = x + width_rect + 5;
                }
                x = x0;
                y = y + height_rect + 5;
            }
        }

        private void Player()
        {
            rect_pl.Width = 50;
            rect_pl.Height = 7;

            rect_pl.Fill = new SolidColorBrush(Colors.Gray);
            rect_pl.Stroke = new SolidColorBrush(Colors.Black);

            rect_pl.HorizontalAlignment = HorizontalAlignment.Left;
            rect_pl.VerticalAlignment = VerticalAlignment.Top;

            rect_pl.Margin = new Thickness(x_pl, y_pl, 0, 0);
            grid.Children.Add(rect_pl);
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            var windowPosition = e.GetPosition(grid);
            x_pl = (int)windowPosition.X;
            if (x_pl + rect_pl.Width + 10 < 600)
            {
                grid.Children.Remove(rect_pl);
                Player();
            }
        }

    }
}
