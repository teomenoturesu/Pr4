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
    /// Логика взаимодействия для CustomerOrdersWindow.xaml
    /// </summary>
    public partial class CustomerOrdersWindow : Window
    {
        private Pr4Entities1 pr4Entities;
        private CUSTOMER _currentCustomer;
        public CustomerOrdersWindow(CUSTOMER currentCustomer)
        {
            _currentCustomer = currentCustomer;
            pr4Entities = new Pr4Entities1();
            InitializeComponent();
            OrdersDataGrid.ItemsSource = pr4Entities.ORDER.Where(c => c.ID.Equals(currentCustomer.ID)).ToList();
        }

        private void EscapeButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerNavigationWindow customerNavigationWindow = new CustomerNavigationWindow(_currentCustomer);
            customerNavigationWindow.Show();
            this.Close();
        }
    }
}
