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
    public enum Sort
    {
        Asc,
        Desc
    }
    /// <summary>
    /// Логика взаимодействия для CustomerGoodsWindow.xaml
    /// </summary>
    public partial class CustomerGoodsWindow : Window
    {
        Sort sort;
        Pr4Entities pr4Entities;
        private List<GOOD> Goods { get; set; }
        private List<CATEGORY> Categories { get; set; }
        private List<ListOfGoods> ListOfGoods { get; set; }
        public CustomerGoodsWindow(CUSTOMER currentCustomer)
        {
            pr4Entities = new Pr4Entities();
            InitializeComponent();
            Goods = pr4Entities.GOOD.ToList<GOOD>();
            Categories = pr4Entities.CATEGORY.ToList<CATEGORY>();
            GoodsDataGrid.ItemsSource = GoodsSelection();
        }

        private void GoodName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListOfGoods = GoodsSelection();
            GoodsDataGrid.ItemsSource = ListOfGoods.Where(g => g.GoodName.ToLower().Contains(GoodName.Text.ToLower()));
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            GoodsDataGrid.ItemsSource = GoodsSelection();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private List<ListOfGoods> GoodsSelection()
        {
            ListOfGoods = (from good in Goods
                          join category in Categories on good.CATEGORY equals category.ID
                          select new ListOfGoods()
                          {
                              GoodName = good.NAME,
                              CategoryName = category.NAME
                          }).ToList<ListOfGoods>();
            return ListOfGoods;
        }
    }
}
