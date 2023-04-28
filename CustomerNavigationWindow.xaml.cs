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

namespace Pr4
{
    /// <summary>
    /// Логика взаимодействия для CustomerNavigationWindow.xaml
    /// </summary>
    public partial class CustomerNavigationWindow : Window
    {
        private CUSTOMER _customer;
        public CustomerNavigationWindow(CUSTOMER currentCustomer)
        {
            _customer = currentCustomer;
            InitializeComponent();
        }

        private void CatalogueHyperlink_Click(object sender, RoutedEventArgs e)
        {
            CustomerGoodsWindow customerGoodsWindow = new CustomerGoodsWindow(_customer);
            customerGoodsWindow.Show();
            this.Close();
        }

        private void OrdersHyperlink_Click(object sender, RoutedEventArgs e)
        {
            CustomerOrdersWindow customerOrdersWindow = new CustomerOrdersWindow(_customer);
            customerOrdersWindow.Show();
            this.Close();
        }

    }
}
