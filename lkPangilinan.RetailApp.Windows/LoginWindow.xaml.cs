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
using System.Windows.Shapes;
using lkPangilinan.RetailApp.Windows.BLL;

namespace lkPangilinan.RetailApp.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            lblErrors.Content = "";

            if (string.IsNullOrEmpty(txtEmailAddress.Text))
            {
                lblErrors.Content = "Invalid Login";
                return;
            };

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                lblErrors.Content = "Invalid Login";
                return;
            };

            var op = RetailUserBLL.Login(txtEmailAddress.Text, txtPassword.Text);

            if (op.Code == "200")
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                lblErrors.Content = "Invalid Login";
            }

        }

    }
}
