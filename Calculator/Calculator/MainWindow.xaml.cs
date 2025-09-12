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
        private void OnNumberClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (Display.Text == "0" || Display.Text == "Error")
            {
                Display.Text = button.Content.ToString();
            }
            else
            {
                Display.Text += button.Content.ToString();
            }
        }
        private void OnOperatorClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Display.Text += button.Content.ToString();
        }
        private void OnClearClick(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
        }
        private void OnEqualClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //cambiar esto por una funcion propia que compute
                var result = new System.Data.DataTable().Compute(Display.Text, null);
                Display.Text = result.ToString();
            }
            catch (Exception)
            {
                Display.Text = "Error";
            }
        }
    }
}
