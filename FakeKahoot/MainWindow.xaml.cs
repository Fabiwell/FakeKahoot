using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FakeKahoot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Loginform userControl;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("button Login clicked");

            Trace.WriteLine("button register clicked");

            Window window = new Window
            {
                Title = "Login Form",
                Content = new Loginform(),
                Width = 350,
                Height = 414,
                SizeToContent = SizeToContent.Width,
                ResizeMode = ResizeMode.NoResize,
                Owner = Window.GetWindow(this),

            };
            window.ShowDialog();

            this.Close();
        }
    }
}
