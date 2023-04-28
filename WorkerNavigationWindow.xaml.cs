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
    /// Логика взаимодействия для WorkerNavigationWindow.xaml
    /// </summary>
    public partial class WorkerNavigationWindow : Window
    {
        public WorkerNavigationWindow()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            WorkerGoodsWindow workerGoodsWindow = new WorkerGoodsWindow();
            workerGoodsWindow.Show();
            this.Close();
        }

        private void OrdersWindow_Click(object sender, RoutedEventArgs e)
        {
            WorkerOrdersWindow workerOrdersWindow = new WorkerOrdersWindow();
            workerOrdersWindow.Show();
            this.Close();
        }
    }
}
