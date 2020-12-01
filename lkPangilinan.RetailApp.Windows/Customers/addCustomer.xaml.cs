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
