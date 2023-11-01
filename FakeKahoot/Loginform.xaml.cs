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

namespace FakeKahoot
{
    /// <summary>
    /// Interaction logic for Loginform.xaml
    /// </summary>
    public partial class Loginform : UserControl
    {
        manageAccounts manageAccounts = new manageAccounts();
        bool created = false;
        bool loggedin = false;

        public Loginform()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string email = tbEmail.Text;
            string pass = tbPass.Text;

            if (email != "" && pass != "")
            {

                manageAccounts.CreateAccount(email, pass, ref created);

                if (created)
                {
                    tbEmail.Text = "";
                    tbPass.Text = "";
                    lblAccountCreated.Content = "Account created";
                }
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = tbEmail.Text;
            string pass = tbPass.Text;

            manageAccounts.LoginAccount(email, pass, ref loggedin);
            if (loggedin)
            {
                quiz quizform = new quiz();
                quizform.Show();

                Window.GetWindow(this).Close();
            }
        }
    }
}
