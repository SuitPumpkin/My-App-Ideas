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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Calculator
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            StartAnimations();
        }
        private void StartAnimations()
        {
            DoubleAnimation Open1 = new DoubleAnimation
            {
                From = -1,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(800),
                BeginTime = TimeSpan.FromSeconds(2),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };
            DoubleAnimation Open2 = new DoubleAnimation
            {
                From = -280,
                To = -10,
                Duration = TimeSpan.FromMilliseconds(800),
                BeginTime = TimeSpan.FromSeconds(2),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };
            DoubleAnimation HideCredits = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromMilliseconds(400),
                BeginTime = TimeSpan.FromSeconds(2),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };
            DoubleAnimation Close1 = new DoubleAnimation
            {
                From = 1,
                To = -1,
                Duration = TimeSpan.FromMilliseconds(800),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseIn }
            };
            DoubleAnimation Close2 = new DoubleAnimation
            {
                From = -10,
                To = -280,
                Duration = TimeSpan.FromMilliseconds(800),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseIn }
            };

            Credits.BeginAnimation(OpacityProperty, HideCredits);
            ScaleCover.BeginAnimation(ScaleTransform.ScaleXProperty, Open1);
            TranslateCover.BeginAnimation(TranslateTransform.XProperty, Open2);
            DispatcherTimer Timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2.5) };

            Timer.Tick += (s, args) =>
            {
                Timer.Stop();
                Panel.SetZIndex(Cover, -1);
                ScaleCover.BeginAnimation(ScaleTransform.ScaleXProperty, Close1);
                TranslateCover.BeginAnimation(TranslateTransform.XProperty, Close2);
            };
            Close1.Completed += (s, e) =>
            {
                Panel.SetZIndex(Cover, 1);
                Cover.Visibility = Visibility.Collapsed;
            };
            Timer.Start();
        }
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (Display.Text == "0")
            {
                Display.Text = button.Content.ToString();
            }
            else
            {
                Display.Text += button.Content.ToString();
            }
        }
        private void OnClearClick(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            MiniDisplay.Text = "0";
        }
        private void OnEqualClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MiniDisplay.Text != "0" && Calculate(MiniDisplay.Text) == Display.Text)
                {
                    MiniDisplay.Text = Display.Text + IterableOperation(MiniDisplay.Text);
                    Display.Text = Calculate(MiniDisplay.Text);
                }
                else
                {
                    MiniDisplay.Text = Display.Text;
                    Display.Text = Calculate(Display.Text);
                }
            }
            catch (Exception)
            {
                Display.Text = "0";
                MiniDisplay.Text = "Error";
            }
        }
        private string IterableOperation(string lastOperation)
        {
            int lastIndex = lastOperation.LastIndexOfAny(new char[] { '+', '-', 'x', '÷' });
            if (lastIndex != -1)
            {
                lastOperation = lastOperation.Substring(lastIndex);
                return lastOperation;
            }
            return string.Empty;
        }
        private string Calculate(string expression)
        {
            //Validaciones de los botones
            expression = expression.Replace("x", "*").Replace("÷", "/");

            //cambiar esto por una funcion propia que compute
            var result = new System.Data.DataTable().Compute(expression, null);
            return result.ToString();
        }
        private void OnClickInWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void OnCloseClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
