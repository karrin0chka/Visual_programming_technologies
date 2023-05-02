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
using System.Windows.Media.Effects;
using System.Windows.Threading;

namespace Лаб4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        int counter = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(counter % 2 == 0)
            {
            //    oldBrush = 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DropShadowEffect drop = new DropShadowEffect();
            drop.Color = Colors.Blue;
            drop.BlurRadius = 10;
            drop.ShadowDepth = 10;
            label.Effect = new DropShadowEffect();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SetNewBrush();           
        }

        private void SetNewBrush()
        {
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.GradientStops.Add(new GradientStop(Colors.Aqua, 0.0));
            brush.GradientStops.Add(new GradientStop(Colors.White, 0.5));
            brush.GradientStops.Add(new GradientStop(Colors.Black, 1.0));
            brush.StartPoint = new Point(1, 0);
            brush.EndPoint = new Point(0, 1);
            rect1.Fill = brush;
        }
    }
}
