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
    /// Логика взаимодействия для CustomerGoodsWindow.xaml
    /// </summary>
    public partial class CustomerGoodsWindow : Window
    {
        Pr4Entities1 pr4Entities;
        private List<GOOD> Goods { get; set; }
        private List<CATEGORY> Categories { get; set; }
        private List<ListOfGoods> ListOfGoods { get; set; }
        private CUSTOMER _currentCustomer;
        public CustomerGoodsWindow(CUSTOMER currentCustomer)
        {
            _currentCustomer = currentCustomer;
            pr4Entities = new Pr4Entities1();
            InitializeComponent();
            Goods = pr4Entities.GOOD.ToList<GOOD>();
            Categories = pr4Entities.CATEGORY.ToList<CATEGORY>();
            GoodsSelection();
            GoodsDataGrid.ItemsSource = ListOfGoods;
            Categories.ForEach(c => CategoriesComboBox.Items.Add(c.NAME));
        }

        private void GoodName_TextChanged(object sender, TextChangedEventArgs e)
        {
            GoodsDataGrid.ItemsSource = ListOfGoods.Where(g => g.GoodName.ToLower().Contains(GoodName.Text.ToLower()));
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            GoodsDataGrid.ItemsSource = ListOfGoods;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)AscSort.IsChecked)
            {
                GoodsDataGrid.ItemsSource = ListOfGoods.OrderBy(g => g.GoodName);
            }
            else if ((bool)DescSort.IsChecked)
            {
                GoodsDataGrid.ItemsSource = ListOfGoods.OrderByDescending(g => g.GoodName);
            }
        }
        /// <summary>
        /// метод, в котором прописываем запрос выборки всех товаров с joinами для корректного отображения категорий
        /// </summary>
        /// <returns></returns>
        private void GoodsSelection()
        {
            ListOfGoods = (from good in Goods
                          join category in Categories on good.CATEGORY equals category.ID 
                          select new ListOfGoods() 
                          {
                              GoodName = good.NAME,
                              CategoryName = category.NAME,
                              Price = good.PRICE
                          }).ToList<ListOfGoods>();
        }

        private void CategoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GoodsDataGrid.ItemsSource = ListOfGoods.Where(g => g.CategoryName.Equals(CategoriesComboBox.SelectedItem));
        }

        private void EscapeButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerNavigationWindow customerNavigationWindow = new CustomerNavigationWindow(_currentCustomer);
            customerNavigationWindow.Show();
            this.Close();
        }
    }
}
