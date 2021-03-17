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

namespace Zmeika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int X = 150;
        int Y = 150;
        int direction;
        int lenght = 4;
        Point lastSegment;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Ellipse ellipse = CreateEllipse(new Point(X,Y), Brushes.Red );
            CanvasMap.Children.Insert(0, ellipse);

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            switch (direction)
            {
                case 1:
                    X -= 16;
                    break;
                case 2:
                    Y -= 16;
                    break;
                case 3:
                    X += 16;
                    break;
                case 4:
                    Y += 16;
                    break;
                default:
                    break;
            }

            //Изменения для master

            Ellipse ellipse = CreateEllipse(new Point(X, Y), Brushes.Red);
            CanvasMap.Children.Insert(0, ellipse);

            //Rectangle rectangle= CreateSquare(new Point(X, Y), Brushes.Red);
            //CanvasMap.Children.Insert(0, rectangle);
        }

        private Ellipse CreateEllipse(Point point, Brush brush)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = 16;
            ellipse.Height = 16;
            ellipse.Fill = brush;
            Canvas.SetLeft(ellipse, point.X);
            Canvas.SetTop(ellipse, point.Y);
            return ellipse;
        }

        private Rectangle CreateSquare (Point point, Brush brush)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 16;
            rectangle.Height = 16;
            rectangle.Fill = brush;
            Canvas.SetLeft(rectangle, point.X);
            Canvas.SetTop(rectangle, point.Y);
            return rectangle;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    direction = 1;                    
                    break;
                case Key.Up:
                    direction = 2;
                    break;
                case Key.Right:
                    direction = 3;
                    break;
                case Key.Down:
                    direction = 4;
                    break;
                default:
                    break;
            }
        }
    }
}
