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
using lkPangilinan.RetailApp.Windows.Models;

namespace lkPangilinan.RetailApp.Windows.Customers
{
    /// <summary>
    /// Interaction logic for addCustomer.xaml
    /// </summary>
    public partial class addCustomer : Window
    {
        CstmerList myParentWindow = new CstmerList();
        public addCustomer(CstmerList parentWindow)
        {
            InitializeComponent();
            myParentWindow = parentWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            List<string> errors = new List<string>();
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errors.Add("First Name is required.");
            };

            if (string.IsNullOrEmpty(txtBillAddresss.Text))
            {
                errors.Add("Billing Address is required.");
            };

            if (string.IsNullOrEmpty(txtPNumber.Text))
            {
                errors.Add("Password is required.");
            };

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errors.Add("Email is required.");
            };

            if (string.IsNullOrEmpty(txtShipAddress.Text))
            {
                errors.Add("Shipping Address is required.");
            };

            var message = string.Join(Environment.NewLine, errors);

            if (errors.Count > 0)

            {
                MessageBox.Show(message);
            }


            var op = CustomerBLL.Add(new Customer()
            {
                Id = Guid.NewGuid(),
                CustomerName = txtName.Text,
                Customer_ContactNumber = txtPNumber.Text,
                Customer_EmailAddress = txtEmail.Text,
                BillingAddress = txtBillAddresss.Text,
                Default_ShippingAddress = txtShipAddress.Text

            });

            if (op.Code != "200")
            {
                MessageBox.Show("Error : " + op.Message);
            }
            else
            {
                MessageBox.Show("Employee is successfully added to table");
            }

            myParentWindow.showData();
            this.Close();
        }


    }
}
