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
    /// Interaction logic for updateCustomer.xaml
    /// </summary>
    public partial class updateCustomer : Window
    {
        CstmerList myParentWindow = new CstmerList();
        private Customer thisCustomer;
        public updateCustomer(Customer customer, CstmerList parentWindow)
        {
            InitializeComponent();
            myParentWindow = parentWindow;
            thisCustomer = customer;

            txtBillAddresss.Text = thisCustomer.BillingAddress;
            txtEmail.Text = thisCustomer.Customer_EmailAddress;
            txtName.Text = thisCustomer.CustomerName;
            txtPNumber.Text = thisCustomer.Customer_ContactNumber;
            txtShipAddress.Text = thisCustomer.Default_ShippingAddress;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var op = CustomerBLL.Update(new Customer()
            {
                Id = thisCustomer.Id,
                BillingAddress = txtBillAddresss.Text,
                CustomerName = txtName.Text,
                Default_ShippingAddress = txtShipAddress.Text,
                Customer_EmailAddress = txtEmail.Text,
                Customer_ContactNumber = txtPNumber.Text
            });

            if (op.Code != "200")
            {
                MessageBox.Show("Error : " + op.Message);
            }
            else
            {
                MessageBox.Show("Employee is successfully updated");
            }

            myParentWindow.showData();
            this.Close();
        }
    }
}
