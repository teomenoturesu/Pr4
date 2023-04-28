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
    /// Логика взаимодействия для WorkerOrdersWindow.xaml
    /// </summary>
    public partial class WorkerOrdersWindow : Window
    {
        private Pr4Entities1 pr4Entities;
        private List<ORDER> Orders { get; set; }
        public WorkerOrdersWindow()
        {
            pr4Entities = new Pr4Entities1();
            InitializeComponent();
            Orders = pr4Entities.ORDER.ToList();
            OrdersDataGrid.ItemsSource = Orders;
        }
    }
}
