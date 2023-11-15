using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace FakeKahoot
{
    /// <summary>
    /// Interaction logic for quiz.xaml
    /// </summary>
    public partial class quiz : Window
    {

        public quiz()
        {
            InitializeComponent();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string category = button.Content.ToString();

            indvQuiz indvQuiz = new indvQuiz(category)
            {
                ResizeMode = ResizeMode.NoResize,
                Owner = Window.GetWindow(this),
            };
            indvQuiz.Show();

        }

    }
}
