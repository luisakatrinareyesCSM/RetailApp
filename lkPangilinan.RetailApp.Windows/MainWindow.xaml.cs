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
using lkPangilinan.RetailApp.Windows.DAL;

namespace lkPangilinan.RetailApp.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            Customers.CstmerList cstmrWindow = new Customers.CstmerList();
            cstmrWindow.Show();
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            Products.ProductList productWindow = new Products.ProductList();
            productWindow.Show();
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            RetailUsers.UserList userWindow = new RetailUsers.UserList();
            userWindow.Show();
        }

        private void btnOrderProducts_Click(object sender, RoutedEventArgs e)
        {
            OrderProducts.OrderProductsList opWindow = new OrderProducts.OrderProductsList();
            opWindow.Show();
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            Orders.OrderList orderWindow = new Orders.OrderList();
            orderWindow.Show();
        }
    }
}
