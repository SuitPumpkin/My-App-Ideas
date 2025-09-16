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
                MiniDisplay.Text = Display.Text;
                Display.Text = Calculate(Display.Text);
            }
            catch (Exception)
            {
                Display.Text = "0";
                MiniDisplay.Text = "Error";
            }
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
